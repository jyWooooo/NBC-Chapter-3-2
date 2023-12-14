using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIEventHandler : EventTrigger
{
    new public class Entry
    {
        public EventTriggerType eventID = EventTriggerType.PointerClick;
        public Action<BaseEventData> callback;
    }

    public class ButtonEntry : Entry
    {
        public PointerEventData.InputButton inputButton = PointerEventData.InputButton.Left;
    }

    private List<Entry> _delegates;

    new public List<Entry> triggers
    {
        get
        {
            if (_delegates == null)
                _delegates = new List<Entry>();
            return _delegates;
        }
        set { _delegates = value; }
    }

    private void Execute(EventTriggerType id, BaseEventData eventData)
    {
        for (int i = 0; i < triggers.Count; ++i)
        {
            var ent = triggers[i];
            if (ent.eventID == id)
                ent.callback?.Invoke(eventData);
        }
    }

    private void Execute(EventTriggerType id, PointerEventData eventData)
    {
        for (int i = 0; i < triggers.Count; ++i)
        {
            if (triggers[i] is not ButtonEntry)
                continue;

            var ent = triggers[i] as ButtonEntry;
            if (ent.eventID == id && eventData.button == ent.inputButton)
                ent.callback?.Invoke(eventData);
        }
    }

    /// <summary>
    /// Called by the EventSystem when the pointer enters the object associated with this EventTrigger.
    /// </summary>
    public override void OnPointerEnter(PointerEventData eventData)
    {
        Execute(EventTriggerType.PointerEnter, eventData);
    }

    /// <summary>
    /// Called by the EventSystem when the pointer exits the object associated with this EventTrigger.
    /// </summary>
    public override void OnPointerExit(PointerEventData eventData)
    {
        Execute(EventTriggerType.PointerExit, eventData);
    }

    /// <summary>
    /// Called by the EventSystem every time the pointer is moved during dragging.
    /// </summary>
    public override void OnDrag(PointerEventData eventData)
    {
        Execute(EventTriggerType.Drag, eventData);
    }

    /// <summary>
    /// Called by the EventSystem when an object accepts a drop.
    /// </summary>
    public override void OnDrop(PointerEventData eventData)
    {
        Execute(EventTriggerType.Drop, eventData);
    }

    /// <summary>
    /// Called by the EventSystem when a PointerDown event occurs.
    /// </summary>
    public override void OnPointerDown(PointerEventData eventData)
    {
        Execute(EventTriggerType.PointerDown, eventData);
    }

    /// <summary>
    /// Called by the EventSystem when a PointerUp event occurs.
    /// </summary>
    public override void OnPointerUp(PointerEventData eventData)
    {
        Execute(EventTriggerType.PointerUp, eventData);
    }

    /// <summary>
    /// Called by the EventSystem when a Click event occurs.
    /// </summary>
    public override void OnPointerClick(PointerEventData eventData)
    {
        Execute(EventTriggerType.PointerClick, eventData);
    }

    /// <summary>
    /// Called by the EventSystem when a Select event occurs.
    /// </summary>
    public override void OnSelect(BaseEventData eventData)
    {
        Execute(EventTriggerType.Select, eventData);
    }

    /// <summary>
    /// Called by the EventSystem when a new object is being selected.
    /// </summary>
    public override void OnDeselect(BaseEventData eventData)
    {
        Execute(EventTriggerType.Deselect, eventData);
    }

    /// <summary>
    /// Called by the EventSystem when a new Scroll event occurs.
    /// </summary>
    public override void OnScroll(PointerEventData eventData)
    {
        Execute(EventTriggerType.Scroll, eventData);
    }

    /// <summary>
    /// Called by the EventSystem when a Move event occurs.
    /// </summary>
    public override void OnMove(AxisEventData eventData)
    {
        Execute(EventTriggerType.Move, eventData);
    }

    /// <summary>
    /// Called by the EventSystem when the object associated with this EventTrigger is updated.
    /// </summary>
    public override void OnUpdateSelected(BaseEventData eventData)
    {
        Execute(EventTriggerType.UpdateSelected, eventData);
    }

    /// <summary>
    /// Called by the EventSystem when a drag has been found, but before it is valid to begin the drag.
    /// </summary>
    public override void OnInitializePotentialDrag(PointerEventData eventData)
    {
        Execute(EventTriggerType.InitializePotentialDrag, eventData);
    }

    /// <summary>
    /// Called before a drag is started.
    /// </summary>
    public override void OnBeginDrag(PointerEventData eventData)
    {
        Execute(EventTriggerType.BeginDrag, eventData);
    }

    /// <summary>
    /// Called by the EventSystem once dragging ends.
    /// </summary>
    public override void OnEndDrag(PointerEventData eventData)
    {
        Execute(EventTriggerType.EndDrag, eventData);
    }

    /// <summary>
    /// Called by the EventSystem when a Submit event occurs.
    /// </summary>
    public override void OnSubmit(BaseEventData eventData)
    {
        Execute(EventTriggerType.Submit, eventData);
    }

    /// <summary>
    /// Called by the EventSystem when a Cancel event occurs.
    /// </summary>
    public override void OnCancel(BaseEventData eventData)
    {
        Execute(EventTriggerType.Cancel, eventData);
    }
}