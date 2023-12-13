using System.Collections.Generic;
using UnityEngine;

public class DataManager : Singleton<DataManager>
{
    [SerializeField] private List<Item> _items;
    public List<Item> Items => _items;

    protected override void Initialize()
    {
        base.Initialize();

        _items = new List<Item>
        {
            new Item(0, "Knife", ResourceManager.Instance.Load<Sprite>("Knife.sprite")),
            new Item(1, "Leather Armor", ResourceManager.Instance.Load<Sprite>("Leather Armor.sprite")),
            new Item(2, "Iron Armor", ResourceManager.Instance.Load<Sprite>("Iron Armor.sprite")),
            new Item(3, "Golden Sword", ResourceManager.Instance.Load<Sprite>("Golden Sword.sprite")),
        };
    }
}