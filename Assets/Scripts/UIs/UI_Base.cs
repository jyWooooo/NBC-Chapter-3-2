using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static Define;

public class UI_Base : MonoBehaviour
{
    private Dictionary<Type, UnityEngine.Object[]> _objects = new();
    private bool _isInitialized = false;

    private void Start()
    {
        Initialize();
    }

    public virtual bool Initialize()
    {
        if (_isInitialized) return false;
        _isInitialized = true;
        return true;
    }

    void Bind<T>(Type type) where T : UnityEngine.Object
    {
        string[] names = Enum.GetNames(type);
        var objs = new UnityEngine.Object[names.Length];
        _objects.Add(typeof(T), objs);

        for (int i = 0; i < names.Length; i++)
        {
            if (typeof(T) == typeof(GameObject))
                objs[i] = Utilities.FindChild(gameObject, names[i], true);
            else
                objs[i] = Utilities.FindChild<T>(gameObject, names[i], true);
            if (objs[i] == null)
                Debug.LogError($"[UI Base: {name}] Failed to bind: {names[i]}");

        }
    }

    protected void BindObject(Type type) => Bind<GameObject>(type);
    protected void BindImage(Type type) => Bind<Image>(type);
    protected void BindText(Type type) => Bind<TextMeshProUGUI>(type);
    protected void BindButton(Type type) => Bind<Button>(type);

    private T Get<T>(int idx) where T : UnityEngine.Object
    {
        if (!_objects.TryGetValue(typeof(T), out var objs))
            return null;
        return objs[idx] as T;
    }

    protected GameObject GetObject(int idx) => Get<GameObject>(idx);
    protected Image GetImage(int idx) => Get<Image>(idx);
    protected TextMeshProUGUI GetText(int idx) => Get<TextMeshProUGUI>(idx);
    protected Button GetButton(int idx) => Get<Button>(idx);

    public static void BindEvent(GameObject obj, Action action = null, EventTriggerType eventType = EventTriggerType.PointerClick, PointerEventData.InputButton? inputButton = PointerEventData.InputButton.Left)
    {
        UIEventHandler uIEventHandler = Utilities.GetOrAddComponent<UIEventHandler>(obj);

        if (inputButton.HasValue)
        {
            UIEventHandler.ButtonEntry entry = new();
            entry.eventID = eventType;
            entry.inputButton = inputButton.Value;
            entry.callback += x => action?.Invoke();
            uIEventHandler.triggers.Add(entry);
        }
        else
        {
            UIEventHandler.Entry entry = new();
            entry.eventID = eventType;
            entry.callback += x => action?.Invoke();
            uIEventHandler.triggers.Add(entry);
        }
    }

    public static void BindEvent(GameObject obj, Action<BaseEventData> action = null, EventTriggerType eventType = EventTriggerType.PointerClick, PointerEventData.InputButton? inputButton = PointerEventData.InputButton.Left)
    {
        UIEventHandler uIEventHandler = Utilities.GetOrAddComponent<UIEventHandler>(obj);

        if (inputButton.HasValue)
        {
            UIEventHandler.ButtonEntry entry = new();
            entry.eventID = eventType;
            entry.inputButton = inputButton.Value;
            entry.callback += action;
            uIEventHandler.triggers.Add(entry);
        }
        else
        {
            UIEventHandler.Entry entry = new();
            entry.eventID = eventType;
            entry.callback += action;
            uIEventHandler.triggers.Add(entry);
        }
    }
}