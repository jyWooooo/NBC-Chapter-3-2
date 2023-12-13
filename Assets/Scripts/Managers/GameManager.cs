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

    protected override void Initialize()
    {
        base.Initialize();
        GameLoad();
    }

    private void GameLoad()
    {
        ResourceLoad();
        CharacterLoad();
    }

    private void CharacterLoad()
    {
        _player = new GameObject("Player").AddComponent<Player>();
    }

    private void ResourceLoad()
    {
        ResourceManager.Instance.LoadAsync<GameObject>($"UI_Scene_PlayerInfo.prefab", res => { ShowSceneUI(); });
    }

    private void ShowSceneUI()
    {
        UIManager.Instance.ShowSceneUI<UI_Scene_PlayerInfo>();
    }
}