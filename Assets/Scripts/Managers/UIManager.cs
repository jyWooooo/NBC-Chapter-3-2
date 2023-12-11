using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager>
{
    private GameObject root;
    public GameObject Root
    {
        get
        {
            root = GameObject.Find("@UI_Root");
            if (root == null)
                root = new("@UI_Root");
            return root;
        }
    }

    private UI_Scene sceneUI;
    public UI_Scene SceneUI => sceneUI;

    private int popUpOrder = 10;
    private Stack<UI_PopUp> popUpStack = new();
    public int PopUpCount => popUpStack.Count;

    public void SetCanvas(GameObject obj, int? sortOrder = 0)
    {
        Canvas canvas = obj.GetOrAddComponent<Canvas>();
        canvas.renderMode = RenderMode.ScreenSpaceOverlay;
        canvas.overrideSorting = true;

        CanvasScaler scaler = obj.GetOrAddComponent<CanvasScaler>();
        scaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
        scaler.referenceResolution = new(Display.main.systemHeight, Display.main.systemWidth);

        obj.GetOrAddComponent<GraphicRaycaster>();

        if (!sortOrder.HasValue)
        {
            canvas.sortingOrder = popUpOrder;
            popUpOrder++;
        }
        else
            canvas.sortingOrder = sortOrder.Value;
    }

    protected override void Initialize()
    {
        root.SetActive(true);
        SetCanvas(root);
    }

    public T ShowSceneUI<T>(string name = null) where T : UI_Scene
    {
        if (string.IsNullOrEmpty(name))
            name = nameof(T);

        // TODO: 나중에 Addressable에서 Load한 프리팹으로 바꿔야함.
        GameObject obj = Resources.Load<GameObject>($"UI/{name}");
        obj = Instantiate(obj, Root.transform);

        //GameObject obj = ResourceManager.Instantiate($"{name}.prefab");
        //obj.transform.SetParent(Root.transform);

        sceneUI = obj.GetOrAddComponent<T>();
        return sceneUI as T;
    }

    public T ShowPopUpUI<T>(string name = null) where T : UI_PopUp
    {
        if (string.IsNullOrEmpty(name))
            name = nameof(T);

        // TODO: 나중에 Addressable에서 Load한 프리팹으로 바꿔야함.
        GameObject obj = Resources.Load<GameObject>($"UI/{name}");
        obj = Instantiate(obj, Root.transform);

        //GameObject obj = ResourceManager.Instantiate($"{name}.prefab");
        //obj.transform.SetParent(Root.transform);

        T popUp = obj.GetOrAddComponent<T>();
        popUpStack.Push(popUp);

        //RefreshTimeScale();

        return popUp;
    }

    public void ClosePopUp(UI_PopUp popUp)
    {
        if (popUpStack.Count == 0) return;
        if (popUpStack.Peek() != popUp)
        {
            Debug.LogError($"[UIManager] ClosePopUp({popUp.name}): Close pop up failed");
            return;
        }
        ClosePopUp();
    }

    public void ClosePopUp()
    {
        if (popUpStack.Count == 0) return;

        UI_PopUp popUp = popUpStack.Pop();
        // TODO: 나중에 ResourceManager에서 Destroy 시켜줘야함
        Destroy(popUp.gameObject);
        //ResourceManager.Destroy(popUp);
        popUpOrder--;
        //RefreshTimeScale();
    }

    public void CloseAllPopUp()
    {
        while (popUpStack.Count > 0)
            ClosePopUp();
    }
}