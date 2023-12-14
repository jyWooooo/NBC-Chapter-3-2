using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UI_Scene_Inventory : UI_Scene
{
    enum Objects
    {
        Content,
    }

    private UI_InventorySlot[] _slots;
    private List<Item> _items;

    public UI_InventorySlot dragSlot;
    public UI_InventorySlot dropSlot;

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
        _slots = new UI_InventorySlot[content.transform.childCount];
        for (int i = 0; i < content.transform.childCount; i++)
        {
            _slots[i] = content.transform.GetChild(i).GetOrAddComponent<UI_InventorySlot>();
            _slots[i].Initialize();
        }
        RefreshSlots();
    }

    public void SwapSlot()
    {
        GameManager.Instance.Player.Inventory.SwapIndex(dragSlot.slotNumber, dropSlot.slotNumber);
        RefreshSlots();
        dropSlot = null; 
        dragSlot = null;
    }

    public void RefreshSlots()
    {
        for (int i = 0; i < _slots.Length; i++)
        {
            if (i < _items.Count)
                _slots[i].SetSlot(_items[i], i, true);
            else
                _slots[i].SetSlot(null, i);
        }
    }
}