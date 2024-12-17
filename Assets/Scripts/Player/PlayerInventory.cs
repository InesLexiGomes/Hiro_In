using System.Collections.Generic;
using System.Reflection;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] private UIManager uiManager;

    private PlayerInteraction   playerInteraction;
    private List<Interactive>   inventory;
    private int                 selectedSlotIndex;

    void Start()
    {
        playerInteraction = GetComponent<PlayerInteraction>();
        inventory = new List<Interactive>();
        selectedSlotIndex = -1;
    }

    public void Add(Interactive item)
    {
        inventory.Add(item);

        uiManager.ShowInventoryIcon(inventory.Count - 1, item.InventoryIcon);

        if (selectedSlotIndex == -1)
            SelectInventorySlot(0);
    }

    public void Remove(Interactive item)
    {
        inventory.Remove(item);

        uiManager.HideInventoryIcons();

        for (int i = 0; i < inventory.Count; ++i)
            uiManager.ShowInventoryIcon(i, inventory[i].InventoryIcon);

        if (selectedSlotIndex == inventory.Count)
            SelectInventorySlot(selectedSlotIndex - 1);
    }

    public bool Contains(Interactive item)
    {
        return inventory.Contains(item);
    }

    public bool IsFull()
    {
        return inventory.Count == uiManager.GetInventorySlotCount();
    }

    private void SelectInventorySlot(int index)
    {
        selectedSlotIndex = index;

        uiManager.SelectInventorySlot(index);

        playerInteraction.RefreshCurrentInteractive();
    }

    public string GetSelectedInteractionMessage()
    {
        return inventory[selectedSlotIndex].GetInteractionMessage();
    }

    public bool IsSelected(Interactive item)
    {
        return GetSelected() == item;
    }

    public Interactive GetSelected()
    {
        return selectedSlotIndex != -1 ? inventory[selectedSlotIndex] : null;
    }

    void Update()
    {
        CheckForPlayerSlotSelection();
    }

    private void CheckForPlayerSlotSelection()
    {
        for (int i = 0; i < inventory.Count; ++i)
            if (Input.GetKeyDown(KeyCode.Alpha1 + i) && i != selectedSlotIndex)
                SelectInventorySlot(i);
    }

    public void ClearInventory()
    {
        inventory.Clear();
        selectedSlotIndex = -1;
        uiManager.HideInventoryIcons();
    }
}
