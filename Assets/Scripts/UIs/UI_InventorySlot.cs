using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static Define;

public class UI_InventorySlot : UI_Scene
{
    enum Objects
    {
        objEquipMark,
    }

    enum Images
    {
        imgItemIcon,
    }

    private GameObject _equipMark;
    private Image _itemIcon;
    private Item _refItem;
    private bool _isEquip;
    private UI_Scene_Inventory _inventoryUI;
    private bool _useBindEvent = false;
    public int slotNumber;

    public override bool Initialize()
    {
        if (!base.Initialize()) return false;

        BindObject(typeof(Objects));
        BindImage(typeof(Images));

        _equipMark = GetObject((int)Objects.objEquipMark);
        _itemIcon = GetImage((int)Images.imgItemIcon);
        _inventoryUI = transform.GetComponentInParent<UI_Scene_Inventory>();
        gameObject.BindEvent(UseItem);
        gameObject.BindEvent(BeginDrag, EventTriggerType.BeginDrag, PointerEventData.InputButton.Left);
        gameObject.BindEvent(Dragging, EventTriggerType.Drag, PointerEventData.InputButton.Left);
        gameObject.BindEvent(Drop, EventTriggerType.Drop, PointerEventData.InputButton.Left);
        gameObject.BindEvent(EndDrag, EventTriggerType.EndDrag, PointerEventData.InputButton.Left);

        return true;
    }

    private void BeginDrag()
    {
        _inventoryUI.dragSlot = this;
        _itemIcon.raycastTarget = false; 
        _itemIcon.rectTransform.SetParent(UIManager.Instance.Root.transform);
    }

    private void Dragging(BaseEventData data)
    {
        _itemIcon.rectTransform.position = (data as PointerEventData).position;
    }

    private void EndDrag()
    {
        _inventoryUI.dragSlot = null;
        _itemIcon.rectTransform.SetParent(gameObject.transform);
        _itemIcon.rectTransform.localPosition = Vector3.zero; 
        _itemIcon.raycastTarget = true;
    }

    private void Drop()
    {
        _inventoryUI.dropSlot = this;
        _inventoryUI.SwapSlot();
    }

    public void SetSlot(Item referenceItem, int number, bool useEvent = false)
    {
        _refItem = referenceItem;
        slotNumber = number;

        if (referenceItem != null)
        {
            _itemIcon.color = Color.white;
            _itemIcon.sprite = _refItem.Icon;
        }
        else
            _itemIcon.color = new(1f, 1f, 1f, 0f);

        if (_refItem is Item_Equip)
        {
            _isEquip = GameManager.Instance.Player.Equipment.IsEquip(_refItem as Item_Equip);
            _equipMark.SetActive(_isEquip);
        }
        else
            _equipMark.SetActive(false);

        _useBindEvent = useEvent;
    }

    void UseItem()
    {
        if (_refItem == null || !_useBindEvent)
            return;

        if (_refItem is Item_Equip)
        {
            var PopUp = UIManager.Instance.ShowPopUpUI<UI_PopUp_ItemEquip>();
            PopUp.Initialize();
            PopUp.SetPopUpInfo(_refItem as Item_Equip, _isEquip, _inventoryUI.RefreshSlots);
        }
    }
}