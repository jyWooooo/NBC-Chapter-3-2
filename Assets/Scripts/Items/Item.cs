using UnityEngine;

[System.Serializable]
public class Item
{
    [SerializeField] private int _id;
    [SerializeField] private string _name;
    [SerializeField] private Sprite _icon;

    public int ID => _id;
    public string ItemName => _name;
    public Sprite Icon => _icon;

    public Item()
    {

    }

    public Item(int id, string name, Sprite icon)
    {
        _id = id;
        _name = name;
        _icon = icon;
    }

    public Item(Item reference)
    {
        _id = reference._id;
        _name = reference._name;
        _icon = reference._icon;
    }

    public virtual Item DeepCopy()
    {
        return new Item(this);
    }
}
