using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIEventHandler : MonoBehaviour, IPointerClickHandler, IDragHandler, IPointerDownHandler, IPointerUpHandler, IBeginDragHandler, IEndDragHandler
{
    public Action onClickHandler = null;
    public Action onPointerPressedHandler = null;
    public Action onPointerDownHandler = null;
    public Action onPointerUpHandler = null;
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
        onClickHandler?.Invoke();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        pressed = true;
        onPointerDownHandler?.Invoke();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        pressed = false;
        onPointerUpHandler?.Invoke();
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