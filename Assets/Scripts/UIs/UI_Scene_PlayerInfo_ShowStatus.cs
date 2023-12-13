using TMPro;

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
        if (!Initialize()) return;
        _txtValue_HP.text = GameManager.Instance.Player.Status.MaxHP.ToString();
        _txtValue_Atk.text = GameManager.Instance.Player.Status.Atk.ToString();
        _txtValue_Def.text = GameManager.Instance.Player.Status.Def.ToString();
    }
}