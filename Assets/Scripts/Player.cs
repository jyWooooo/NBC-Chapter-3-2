using UnityEngine;

public class Player : MonoBehaviour, IStatus
{
    [SerializeField] private StatusData _statusBase;
    [SerializeField] private string _name;

    public StatusData Status => _statusBase;
    public string PlayerName => _name;

    private void Awake()
    {
        _name = "PlayerName";
        ResourceManager.Instance.LoadAsync<StatusData>("PlayerBaseStatus.asset", res => _statusBase = res);
    }
}