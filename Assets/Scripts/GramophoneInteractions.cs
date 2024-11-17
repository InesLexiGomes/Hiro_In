using System.Collections.Generic;
using UnityEngine;

public class GramophoneInteractions : SpecialInteractions
{
    [SerializeField] private List<InteractiveData> vinylsData;
    [SerializeField] private GameObject[] vinylsObject;

    private Interactive item;

    public override void SpecialInteract(Interactive interactive)
    {

        item = interactive.playerInventory.GetSelected();
        if (item != null)
            ExecuteVinylsInteractions();

    }

    private int VinylCount()
    {
        int vinylCount = 0;

        foreach (InteractiveData vinyl in vinylsData)
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

    private void ExecuteVinylsInteractions()
    {
        switch (VinylCount())
        {
            case 0:
                // Vinyl A interact
                VinylInteraction(0);
                break;
            case 1:
                // Vinyl B interact
                VinylInteraction(1);
                break;
            case 2:
                // Vinyl C interact
                VinylInteraction(2);
                break;
            case 3:
                // Vinyl D interact
                VinylInteraction(3);
                break;
            default:
                break;
        }
    }

    private void VinylInteraction(int index)
    {
        GameObject vinyl = vinylsObject[index];
        Vector3 position = this.transform.position;

        Debug.Log($"Vinyl {index} interact");
        vinyl.SetActive(true);

        position.y += 0.35f;

        vinyl.transform.position = position;
        vinyl.transform.rotation = this.transform.rotation;

    }
}
