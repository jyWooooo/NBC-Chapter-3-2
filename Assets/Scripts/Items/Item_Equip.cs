using UnityEngine;
using static Define;

public class Item_Equip : Item, IStatus
{
    private StatusData _status;
    public StatusData Status => _status;

    private ItemEquipSlot _equipSlot;
    public ItemEquipSlot EquipSlot => _equipSlot;

    public Item_Equip()
    {

    }

    public Item_Equip(int id, string name, Sprite icon, ItemEquipSlot slot, StatusData stat = null) : base(id, name, icon)
    {
        _equipSlot = slot;

        if (stat != null)
            _status = stat;
        else
            _status = ScriptableObject.CreateInstance<StatusData>();
    }

    public Item_Equip(Item_Equip reference) : base(reference)
    {
        _equipSlot = reference.EquipSlot;
        _status = reference.Status;
    }

    public override Item DeepCopy()
    {
        return new Item_Equip(this);
    }

    public override void Use(Player owner)
    {
        if (owner == null)
            return;

        if (!owner.Equipment.IsEquip(this))
            owner.Equipment.Equip(this);
        else
            owner.Equipment.UnEquip(_equipSlot);
    }

    public void SetStatus(StatusData status)
    {
        _status = status;
    }
}