using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using static Define;

public static class Extension
{
    public static T GetOrAddComponent<T>(this GameObject obj) where T : Component
    {
        return Utilities.GetOrAddComponent<T>(obj);
    }

    public static void BindEvent(this GameObject obj, Action action = null, EventTriggerType eventType = EventTriggerType.PointerClick, PointerEventData.InputButton? inputButton = PointerEventData.InputButton.Left)
    {
        UI_Base.BindEvent(obj, action, eventType, inputButton);
    }

    public static void BindEvent(this GameObject obj, Action<BaseEventData> action = null, EventTriggerType eventType = EventTriggerType.PointerClick, PointerEventData.InputButton? inputButton = PointerEventData.InputButton.Left)
    {
        UI_Base.BindEvent(obj, action, eventType, inputButton);
    }

    public static bool IsValid(this GameObject obj)
    {
        return obj != null && obj.activeSelf;
    }

    //public static bool IsValid(this Thing thing)
    //{
    //    return thing != null && thing.isActiveAndEnabled;
    //}
}