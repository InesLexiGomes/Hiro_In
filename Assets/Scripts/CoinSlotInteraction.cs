using UnityEngine;
using UnityEngine.UI;

public class CoinSlotInteraction : MonoBehaviour
{
    [SerializeField] private Color selectedColor;
    [SerializeField] private Color unselectedColor;
    [SerializeField] private Image  image;
    [SerializeField] private int slotNumber;

    private bool hasCoin = true;

    public void LookForCoin()
    {
        // If this slot has a coin it should be removed and added to the player's inventory
        if (hasCoin)
        {
            image.color = unselectedColor;
            hasCoin = false;
        }

        // Else if the player has a coin in the inventory and there's no coin in the slot insert it in the slot
        else if (!hasCoin /* and the player has one in the inventory*/)
        {
            image.color = selectedColor;
            hasCoin = true;
        }
        // Otherwise nothing happens
    }
}
