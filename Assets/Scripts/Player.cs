using UnityEngine;

public class Player : MonoBehaviour, IStatus
{
    [SerializeField] private StatusData _statusBase;
    [SerializeField] private string _name;
    [SerializeField] private Inventory _inventory;
    [SerializeField] private Equipment _equipment;

    public StatusData Status => _statusBase + ModifiersStatus;
    public StatusData BaseStatus => _statusBase;
    public StatusData ModifiersStatus => CalculateModifersStatus();

    public string PlayerName => _name;
    public Inventory Inventory => _inventory;
    public Equipment Equipment => _equipment;

    private void Awake()
    {
        _name = "PlayerName";
        _statusBase = ScriptableObject.CreateInstance<StatusData>();
        _inventory = new Inventory();
        _inventory.SetParent(this);
        _equipment = new Equipment();
        _equipment.SetParent(this);
    }

    public void SetStatus(StatusData status)
    {
        _statusBase = status;
    }

    private StatusData CalculateModifersStatus()
    {
        var res = ScriptableObject.CreateInstance<StatusData>();
        foreach (var equip in _equipment.EquipmentItems)
        {
            if (equip.Value != null)
                res += equip.Value.Status;
        }
        return res;
    }
}