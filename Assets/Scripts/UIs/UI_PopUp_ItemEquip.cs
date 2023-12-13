using System;
using TMPro;
using UnityEngine.UI;

public class UI_PopUp_ItemEquip : UI_PopUp
{
    enum Objects
    {
        objItemSlot,
    }

    enum Texts
    {
        txtTitle,
        txtDescript,
    }

    enum Images
    {

    }

    enum Buttons
    {
        btnCancel,
        btnOK,
    }

    private UI_ItemSlot _slot;
    private Button _btnOK;
    private TextMeshProUGUI _txtDescript;

    public override bool Initialize()
    {
        if (!base.Initialize()) return false;

        BindObject(typeof(Objects));
        BindText(typeof(Texts));
        BindImage(typeof(Images));
        BindButton(typeof(Buttons));

        _slot = GetObject((int)Objects.objItemSlot).GetOrAddComponent<UI_ItemSlot>();
        _btnOK = GetButton((int)Buttons.btnOK);
        _btnOK.gameObject.BindEvent(ClosePopUpUI);
        _txtDescript = GetText((int)Texts.txtDescript);
        GetButton((int)Buttons.btnCancel).gameObject.BindEvent(ClosePopUpUI);

        return true;
    }

    public void SetPopUpInfo(Item_Equip item, bool isEquip = false, Action callback = null)
    {
        _slot.Initialize();
        _slot.SetSlot(item);
        _btnOK.gameObject.BindEvent(() => item.Use(GameManager.Instance.Player));
        _btnOK.gameObject.BindEvent(callback);
        if (isEquip)
        {
            _txtDescript.text = @"unequip this item?";
        }
        else
        {
            _txtDescript.text = @"equip this item?";
        }
    }
}