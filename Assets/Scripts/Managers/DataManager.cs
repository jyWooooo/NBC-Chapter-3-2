using System.Collections.Generic;
using UnityEngine;

public class DataManager : Singleton<DataManager>
{
    [SerializeField] private List<Item> _items;
    public List<Item> Items => _items;

    protected override bool Initialize()
    {
        if (!base.Initialize()) return false;

        _items = new List<Item>
        {
            new Item(0, "Knife", ResourceManager.Instance.Load<Sprite>("Knife.sprite")),
            new Item(1, "Leather Armor", ResourceManager.Instance.Load<Sprite>("Leather Armor.sprite")),
            new Item(2, "Iron Armor", ResourceManager.Instance.Load<Sprite>("Iron Armor.sprite")),
            new Item(3, "Golden Sword", ResourceManager.Instance.Load<Sprite>("Golden Sword.sprite")),
        };

        for (int i = 0; i < _items.Count; i++)
            GameManager.Instance.Player.Inventory.Add(_items[i].DeepCopy());

        return true;
    }
}