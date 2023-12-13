using System;
using System.Collections.Generic;
using System.Diagnostics;
using static Define;

[System.Serializable]
public class Equipment
{
    private Player _parent;
    private Dictionary<ItemEquipSlot, Item_Equip> _dict;

    public Dictionary<ItemEquipSlot, Item_Equip> EquipmentItems => _dict;

    public Equipment() 
    {
        _dict = new();
        for (int i = 0; i < Enum.GetValues(typeof(ItemEquipSlot)).Length; i++)
        {
            if ((ItemEquipSlot)i == ItemEquipSlot.None)
                continue;

            _dict.TryAdd((ItemEquipSlot)i, null);
        }
    }

    public bool IsEquip(Item_Equip item)
    {
        if (item.EquipSlot == ItemEquipSlot.None)
            return false;

        if (_dict[item.EquipSlot] == item)
            return true;
        else return false;
    }

    public void Equip(Item_Equip item)
    {
        if (!_dict.TryAdd(item.EquipSlot, item))
            _dict[item.EquipSlot] = item;
    }

    public void UnEquip(ItemEquipSlot slot)
    {
        _dict[slot] = null;
    }

    public void SetParent(Player player)
    {
        if (player != null)
            _parent = player;
    }
}