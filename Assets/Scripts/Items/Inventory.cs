using System.Collections.Generic;

public class Inventory
{
    private List<Item> items = new();
    public List<Item> Items => items;

    public void Add(Item item)
    {
        items.Add(item);
    }

    public void Remove(Item item)
    {
        items.Remove(item);
    }


}