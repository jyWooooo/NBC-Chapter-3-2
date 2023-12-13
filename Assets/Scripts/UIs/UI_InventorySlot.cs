using UnityEngine;
using UnityEngine.UI;

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

    [SerializeField] private GameObject _equipMark;
    [SerializeField] private Image _itemIcon;
    [SerializeField] private Item _refItem;

    public override bool Initialize()
    {
        if (!base.Initialize()) return false;

        BindObject(typeof(Objects));
        BindImage(typeof(Images));

        _equipMark = GetObject((int)Objects.objEquipMark);
        _itemIcon = GetImage((int)Images.imgItemIcon);

        return true;
    }

    public void SetSlot(Item referenceItem)
    {
        _refItem = referenceItem;

        if (referenceItem != null)
        {
            _itemIcon.color = Color.white;
            _itemIcon.sprite = _refItem.Icon;
        }
        else
            _itemIcon.color = new(1f, 1f, 1f, 0f);

        // TODO: 장착여부 판단해서 active
        _equipMark.SetActive(false);
    }
}