using UnityEngine;
using UnityEngine.UI;

public class CoinSlotInteraction : MonoBehaviour
{
    [SerializeField] private Color      selectedColor;
    [SerializeField] private Color      unselectedColor;
    [SerializeField] private Image      image;
    [SerializeField] private int        slotNumber;

    private FireplaceUI fireplaceUI;
    private bool hasCoin = true;

    private void Awake()
    {
        RemoveCoin();
        fireplaceUI = GetComponentInParent<FireplaceUI>();
    }

    public void LookForCoin()
    {
        // If this slot has a coin it should be removed and added to the player's inventory
        if (hasCoin)
        {
            RemoveCoin();
            fireplaceUI.CoinCount++;
        }

        // Else if the player has a coin in the inventory and there's no coin in the slot insert it in the slot
        else if (!hasCoin && fireplaceUI.CoinCount > 0)
        {
            InsertCoin();
            fireplaceUI.CoinCount--;
        }
        // Otherwise nothing happens
    }

    private void InsertCoin()
    {
        image.color = selectedColor;
        hasCoin = true;
    }

    private void RemoveCoin()
    {
        image.color = unselectedColor;
        hasCoin = false;
    }

    public void GetCoinValue(bool[] solutionArray)
    {
        solutionArray[slotNumber] = hasCoin;
    }
}
