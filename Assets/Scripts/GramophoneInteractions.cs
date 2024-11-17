using System.Collections.Generic;
using UnityEngine;

public class GramophoneInteractions : SpecialInteractions
{
    [SerializeField] private List<InteractiveData> vinyls;

    private Interactive item;

    public override void SpecialInteract(Interactive interactive)
    {

        item = interactive.playerInventory.GetSelected();
        if (item != null)
            ExecuteVinyls();

    }

    private int VinylCount()
    {
        int vinylCount = 0;

        foreach (InteractiveData vinyl in vinyls)
        {
            if (item.interactiveData == vinyl)
            {
                item.playerInventory.Remove(item);
                break;
            }
            vinylCount++;
        }

        item = null;

        return vinylCount;
    }

    private void ExecuteVinyls()
    {
        switch (VinylCount())
        {
            case 0:
                // Vinyl A interact
                Debug.Log("Vinyl A interact");
                break;
            case 1:
                // Vinyl B interact
                Debug.Log("Vinyl B interact");
                break;
            case 2:
                // Vinyl C interact
                Debug.Log("Vinyl C interact");
                break;
            case 3:
                // Vinyl D interact
                Debug.Log("Vinyl D interact");
                break;
            default:
                break;
        }
    }
}
