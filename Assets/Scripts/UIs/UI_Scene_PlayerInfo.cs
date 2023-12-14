using TMPro;
using UnityEngine;

public class UI_Scene_PlayerInfo : UI_Scene
{
    enum Objects
    {
        objMainButtons,
        objShowStatus,
        objShowInventory,
    }

    enum Texts
    {
        txtPlayerName,
        txtPlayerLevel,
    }

    enum Images
    {   

    }

    enum Buttons
    {
        btnStatus,
        btnInventory,
        btnBack,
    }

    private GameObject _mainButtons;
    private GameObject _showStatus;
    private GameObject _ShowInventory;
    private GameObject _btnBack;

    public override bool Initialize()
    {
        if (!base.Initialize()) return false;

        BindObject(typeof(Objects));
        BindText(typeof(Texts));
        BindImage(typeof(Images));
        BindButton(typeof(Buttons));

        _mainButtons = GetObject((int)Objects.objMainButtons);
        _showStatus = GetObject((int)Objects.objShowStatus);
        _ShowInventory = GetObject((int)Objects.objShowInventory);

        GetText((int)Texts.txtPlayerName).text = GameManager.Instance.Player.PlayerName;
        GetText((int)Texts.txtPlayerLevel).text = $"Lv. {GameManager.Instance.Player.Status.Level}";

        _btnBack = GetButton((int)Buttons.btnBack)?.gameObject;
        _btnBack.BindEvent(() => { _mainButtons.SetActive(true); _ShowInventory.SetActive(false); _showStatus.SetActive(false); _btnBack.SetActive(false); });
        GetButton((int)Buttons.btnStatus)?.gameObject?.BindEvent(() => { _mainButtons.SetActive(false); _showStatus.SetActive(true); _btnBack.SetActive(true); });
        GetButton((int)Buttons.btnInventory)?.gameObject?.BindEvent(() => { _mainButtons.SetActive(false); _ShowInventory.SetActive(true); _btnBack.SetActive(true); });

        _showStatus.SetActive(false);
        _ShowInventory.SetActive(false);
        _btnBack.SetActive(false);

        _showStatus.AddComponent<UI_Scene_PlayerInfo_ShowStatus>();
        _ShowInventory.AddComponent<UI_Scene_Inventory>();

        return true;
    }
}