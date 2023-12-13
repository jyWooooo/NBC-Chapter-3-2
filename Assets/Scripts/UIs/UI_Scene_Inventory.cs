using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UI_Scene_Inventory : UI_Scene
{
    enum Objects
    {
        Content,
    }

    private UI_ItemSlot[] _slots;
    private List<Item> _items;

    public override bool Initialize()
    {
        if (!base.Initialize()) return false;

        BindObject(typeof(Objects));
        _items = GameManager.Instance.Player.Inventory.Items;
        SlotInitialize();
        return true;
    }
    private void SlotInitialize()
    {
        var content = GetObject((int)Objects.Content);
        _slots = new UI_ItemSlot[content.transform.childCount];
        for (int i = 0; i < content.transform.childCount; i++)
        {
            _slots[i] = content.transform.GetChild(i).GetOrAddComponent<UI_ItemSlot>();
            _slots[i].Initialize();
        }
        RefreshSlots();
    }

    public void RefreshSlots()
    {
        for (int i = 0; i < _slots.Length; i++)
        {
            if (i < _items.Count)
                _slots[i].SetSlot(_items[i]);
            else
                _slots[i].SetSlot(null);
        }
    }
}