using System;
using UnityEngine;
using UnityEngine.EventSystems;
using static Define;

public static class Extension
{
    public static T GetOrAddComponent<T>(this GameObject obj) where T : Component
    {
        return Utilities.GetOrAddComponent<T>(obj);
    }

    public static void BindEvent(this GameObject obj, Action action = null, Action<BaseEventData> dragAction = null, UIEvent type = UIEvent.Click)
    {
        UI_Base.BindEvent(obj, action, dragAction, type);
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