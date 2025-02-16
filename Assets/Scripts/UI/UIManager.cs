using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private PlayerMovement playerMovementScript;
    [SerializeField] private PlayerInteraction playerInteractionScript;

    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject confirmScreen;
    [SerializeField] private GameObject interactionPanel;
    [SerializeField] private GameObject inventorySlotsContainer;
    [SerializeField] private GameObject inventoryIconsContainer;
    [SerializeField] private Color      unselectedSlotColor;
    [SerializeField] private Color      selectedSlotColor;

    private TextMeshProUGUI interactionMessage;
    private Image[]         inventorySlots;
    private Image[]         inventoryIcons;
    private int             selectedSlotIndex;

    void Start()
    {
        interactionMessage = GetComponentInChildren<TextMeshProUGUI>();
        inventorySlots = inventorySlotsContainer.GetComponentsInChildren<Image>();
        inventoryIcons = inventoryIconsContainer.GetComponentsInChildren<Image>();
        selectedSlotIndex = -1;

        pauseMenu.SetActive(false);
        confirmScreen.SetActive(false);
        HideInteractionPanel();
        HideInventoryIcons();
        ResetInventorySlots();
    } 

    public void HideInteractionPanel()
    {
        interactionPanel.SetActive(false);
    }

    public void ShowInteractionPanel(string message)
    {
        interactionMessage.text = message;
        interactionPanel.SetActive(true);
    }

    public int GetInventorySlotCount()
    {
        return inventorySlots.Length;
    }

    public void HideInventoryIcons()
    {
        foreach (Image image in inventoryIcons)
            image.enabled = false;
    }

    private void ResetInventorySlots()
    {
        foreach (Image image in inventorySlots)
            image.color = unselectedSlotColor;
    }

    public void ShowInventoryIcon(int index, Sprite icon)
    {
        inventoryIcons[index].sprite = icon;
        inventoryIcons[index].enabled = true;
    }

    public void SelectInventorySlot(int index)
    {
        if (selectedSlotIndex != -1)
            inventorySlots[selectedSlotIndex].color = unselectedSlotColor;

        if (index != -1)
        {
            inventorySlots[index].color = selectedSlotColor;
            selectedSlotIndex = index;
        }
    }

    public void PauseGame()
    {
            DisablePlayer();
            pauseMenu.SetActive(true);
    }

    public void DisablePlayer()
    {
        playerMovementScript.enabled = false;
        playerInteractionScript.enabled = false;
        Cursor.lockState = CursorLockMode.Confined;
    }

    public void EnablePlayer()
    {
        playerMovementScript.enabled = true;
        playerInteractionScript.enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
