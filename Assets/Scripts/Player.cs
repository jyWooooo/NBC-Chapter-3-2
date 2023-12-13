using UnityEngine;

public class Player : MonoBehaviour, IStatus
{
    [SerializeField] private StatusData _statusBase;
    [SerializeField] private string _name;
    [SerializeField] private Inventory _inventory;
    [SerializeField] private Equipment _equipment;

    public StatusData Status => _statusBase;
    public string PlayerName => _name;
    public Inventory Inventory => _inventory;
    public Equipment Equipment => _equipment;

    private void Awake()
    {
        _name = "PlayerName";
        ResourceManager.Instance.LoadAsync<StatusData>("PlayerBaseStatus.asset", res => _statusBase = res);
        _inventory = new Inventory();
        _equipment = new Equipment();
    }
}