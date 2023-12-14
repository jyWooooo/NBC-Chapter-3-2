using System;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Inventory
{
    private Player _parent;
    [SerializeField] private List<Item> items = new();
    public List<Item> Items => items;

    public void Add(Item item)
    {
        items.Add(item);
    }

    public void Remove(Item item)
    {
        items.Remove(item);
    }

    public void SetParent(Player player)
    {
        if (player != null)
            _parent = player;
    }

    public void SwapIndex(int l, int r)
    {
        if (l < items.Count && r < items.Count)
        {
            Item temp = items[l];
            items[l] = items[r];
            items[r] = temp;
        }
    }
}