public class UI_PopUp_Test : UI_PopUp
{
    enum Objects
    {

    }

    enum Texts
    {
        txtTitle,
        txtCnt,
    }

    enum Images
    {

    }

    enum Buttons
    {
        btnClose,
    }

    public override bool Initialize()
    {
        if (!base.Initialize()) return false;

        BindObject(typeof(Objects));
        BindText(typeof(Texts));
        BindImage(typeof(Images));
        BindButton(typeof(Buttons));

        GetButton((int)Buttons.btnClose)?.gameObject?.BindEvent(ClosePopUpUI);

        return true;
    }

    private void OnEnable()
    {
        Initialize();
        GetText((int)Texts.txtCnt).text = UIManager.Instance.PopUpCount.ToString();
    }
}