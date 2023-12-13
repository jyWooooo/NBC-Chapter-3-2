using System.Collections.Generic;
using UnityEngine;
using static Define;

public class DataManager : Singleton<DataManager>
{
    [SerializeField] private List<Item> _items;
    public List<Item> Items => _items;

    public override bool Initialize()
    {
        if (!base.Initialize()) return false;

        StatusData[] statusDatas = new StatusData[]
        {
            ScriptableObject.CreateInstance<StatusData>(),
            ScriptableObject.CreateInstance<StatusData>(),
            ScriptableObject.CreateInstance<StatusData>(),
            ScriptableObject.CreateInstance<StatusData>(),
        };

        statusDatas[0].Atk = 1f;
        statusDatas[1].Def = 1f;
        statusDatas[2].Def = 5f;
        statusDatas[3].Atk = 5f;

        _items = new List<Item>
        {
            new Item_Equip(0, "Knife",          ResourceManager.Instance.Load<Sprite>("Knife.sprite"),          ItemEquipSlot.Weapon,   statusDatas[0]),
            new Item_Equip(1, "Leather Armor",  ResourceManager.Instance.Load<Sprite>("Leather Armor.sprite"),  ItemEquipSlot.Armor,    statusDatas[1]),
            new Item_Equip(2, "Iron Armor",     ResourceManager.Instance.Load<Sprite>("Iron Armor.sprite"),     ItemEquipSlot.Armor,    statusDatas[2]),
            new Item_Equip(3, "Golden Sword",   ResourceManager.Instance.Load<Sprite>("Golden Sword.sprite"),   ItemEquipSlot.Weapon,   statusDatas[3]),
        };

        for (int i = 0; i < _items.Count; i++)
            GameManager.Instance.Player.Inventory.Add(_items[i].DeepCopy());

        return true;
    }
}