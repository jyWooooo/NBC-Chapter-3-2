using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UI_Scene_Inventory : UI_Scene
{
    enum Objects
    {
        Content,
    }

    private GameObject _content;
    private List<Item> _items;

    public override bool Initialize()
    {
        if (!base.Initialize()) return false;

        BindObject(typeof(Objects));
        _content = GetObject((int)Objects.Content);
        _items = GameManager.Instance.Player.Inventory.Items;
        SlotInitialize();
        return true;
    }

    private void SlotInitialize()
    {
        for (int i = 0; i < _content.transform.childCount; i++)
        {
            var slot = _content.transform.GetChild(i).GetOrAddComponent<UI_InventorySlot>();
            slot.Initialize();
            if (i < _items.Count)
                slot.SetSlot(_items[i]);
            else
                slot.SetSlot(null);
        }
    }
}