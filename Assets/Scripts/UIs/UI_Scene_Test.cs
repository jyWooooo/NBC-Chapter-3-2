using TMPro;
using UnityEngine;

public class UI_Scene_Test : UI_Scene
{
    enum Objects
    {

    }

    enum Texts
    {
        txtLapseTime,
    }

    enum Images
    {   

    }

    enum Buttons
    {
        btnPopUp,
    }

    private float lapseTime = 0f;
    private TextMeshProUGUI txtLapseTime;

    public override bool Initialize()
    {
        if (!base.Initialize()) return false;

        BindObject(typeof(Objects));
        BindText(typeof(Texts));
        BindImage(typeof(Images));
        BindButton(typeof(Buttons));

        GetButton((int)Buttons.btnPopUp).gameObject.BindEvent(OnPopUpButton);
        txtLapseTime = GetText((int)Texts.txtLapseTime);
        return true;
    }

    private void OnPopUpButton()
    {
        UIManager.Instance.ShowPopUpUI<UI_PopUp_Test>();
    }

    private void Update()
    {
        lapseTime += Time.deltaTime;
        txtLapseTime.text = $"{lapseTime:N2}";
    }
}