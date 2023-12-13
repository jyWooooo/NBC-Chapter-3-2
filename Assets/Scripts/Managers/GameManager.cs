using System;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    private Player _player;
    public Player Player
    {
        get
        {
            if (_player == null)
                _player = new GameObject("Player").AddComponent<Player>();
            return _player;
        }
    }

    public override bool Initialize()
    {
        if (!base.Initialize()) return false;
        GameLoad();
        return true;
    }

    private void GameLoad()
    {
        ResourceLoad();
        CharacterLoad();
    }

    private void CharacterLoad()
    {
        _player = new GameObject("Player").AddComponent<Player>();
        ResourceManager.Instance.LoadAsync<StatusData>("PlayerBaseStatus.asset", res => _player.SetStatus(res));
    }

    private void ResourceLoad()
    {
        ResourceManager.Instance.LoadAllAsync<Sprite>("ItemIcon", (key, cnt, length) =>
            {
                if (cnt == length)
                    DataManager.Instance.Initialize();
            });
        ResourceManager.Instance.LoadAsync<GameObject>($"UI_Scene_PlayerInfo.prefab", res => { ShowSceneUI(); });
        ResourceManager.Instance.LoadAsync<GameObject>($"UI_PopUp_ItemEquip.prefab");
    }

    private void ShowSceneUI()
    {
        UIManager.Instance.ShowSceneUI<UI_Scene_PlayerInfo>();
    }
}