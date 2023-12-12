using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIEventHandler : MonoBehaviour, IPointerClickHandler, IDragHandler, IPointerDownHandler, IPointerUpHandler, IBeginDragHandler, IEndDragHandler
{
    public Action onClickHandler = null;
    public Action onPointerPressedHandler = null;
    public Action onLeftPointerDownHandler = null;
    public Action onLeftPointerUpHandler = null;
    public Action onRightPointerDownHandler = null;
    public Action onRightPointerUpHandler = null;
    public Action<BaseEventData> onDragHandler = null;
    public Action<BaseEventData> onBeginDragHandler = null;
    public Action<BaseEventData> onEndDragHandler = null;

    private bool pressed = false;

    private void Update()
    {
        if (pressed)
            onPointerPressedHandler?.Invoke();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
            onClickHandler?.Invoke();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            pressed = true;
            onLeftPointerDownHandler?.Invoke();
        }
        else if (eventData.button == PointerEventData.InputButton.Right)
            onRightPointerDownHandler?.Invoke();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            pressed = false;
            onLeftPointerUpHandler?.Invoke();
        }
        else if (eventData.button == PointerEventData.InputButton.Right)
            onRightPointerUpHandler?.Invoke();
    }

    public void OnDrag(PointerEventData eventData)
    {
        onDragHandler?.Invoke(eventData);
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        onBeginDragHandler?.Invoke(eventData);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        onEndDragHandler?.Invoke(eventData);
    }
}