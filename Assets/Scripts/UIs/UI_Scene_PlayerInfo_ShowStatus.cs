using TMPro;
using UnityEngine;

public class UI_Scene_PlayerInfo_ShowStatus : UI_Scene
{
    enum Texts
    {
        txtValue_HP,
        txtValue_Atk,
        txtValue_Def,
    }

    private TextMeshProUGUI _txtValue_HP;
    private TextMeshProUGUI _txtValue_Atk;
    private TextMeshProUGUI _txtValue_Def;

    public override bool Initialize()
    {
        if (!base.Initialize()) return false;

        BindText(typeof(Texts));

        _txtValue_HP = GetText((int)Texts.txtValue_HP);
        _txtValue_Atk = GetText((int)Texts.txtValue_Atk);
        _txtValue_Def = GetText((int)Texts.txtValue_Def);

        return true;
    }

    private void OnEnable()
    {
        Initialize();
        var player = GameManager.Instance.Player;
        _txtValue_HP.text = $"{player.Status.MaxHP} + ({player.ModifiersStatus.MaxHP})";
        _txtValue_Atk.text = $"{player.Status.Atk} + ({player.ModifiersStatus.Atk})";
        _txtValue_Def.text = $"{player.Status.Def} + ({player.ModifiersStatus.Def})";
    }
}