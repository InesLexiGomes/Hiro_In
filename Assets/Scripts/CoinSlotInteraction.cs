using UnityEngine;

public class CoinSlotInteraction : MonoBehaviour
{
    private bool hasCoin = false;

    private void LookForCoin()
    {
        // If this slot has a coin it should be removed and added to the player's inventory
        if (hasCoin)
        {
        }

        // Else if the player has a coin in the inventory and there's no coin in the slot insert it in the slot
        else if (!hasCoin /* and the player has one in the inventory*/)
        {
        }
        // Otherwise nothing happens
    }
}
