using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] private UIManager _uiManager;

    private List<Interactive>   _inventory;
    private int                 _selectedSlotIndex;

    void Start()
    {
        _inventory          = new List<Interactive>();
        _selectedSlotIndex  = -1;
    }

    public void Add(Interactive item)
    {
        _inventory.Add(item);

        // show icon on UI

        if (_inventory.Count == 1)
            SelectInventorySlot(0);
    }

    public void Remove(Interactive item)
    {
        _inventory.Remove(item);

        // update icons on UI

        if (_selectedSlotIndex == _inventory.Count)
            SelectInventorySlot(_selectedSlotIndex - 1);
    }

    public bool Contains(Interactive item)
    {
        return _inventory.Contains(item);
    }

    public bool IsFull()
    {
        return _inventory.Count == _uiManager.GetInventorySlotCount();
    }

    private void SelectInventorySlot(int index)
    {
        _selectedSlotIndex = index;

        _uiManager.SelectInventorySlot(index);
    }
    
    public bool IsSelected(Interactive item)
    {
        return GetSelected() == item;
    }

    public Interactive GetSelected()
    {
        return _selectedSlotIndex != -1 ? _inventory[_selectedSlotIndex] : null;
    }
}
