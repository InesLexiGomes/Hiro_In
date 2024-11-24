using System;
using System.Collections.Generic;
using UnityEngine;

public class GramophoneInteractions : SpecialInteractions
{
    // Object interaction
    [SerializeField] private List<InteractiveData>  vinylsData;
    [SerializeField] private GameObject[]           vinylsObject;

    // Audio
    [SerializeField] private AudioSource            audioSource;
    [SerializeField] private AudioClip[]            vinylsNormalAudio;
    [SerializeField] private AudioClip[]            vinylsReverseAudio;

    private Interactive item;
    private bool        isReversed = false;
    private int         currentVinyl = -1;

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

        if (item == null) vinylCount = -1;

        currentVinyl = vinylCount;
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
                PlayVinyl(0);
                break;
            case 1:
                // Vinyl B interact
                VinylInteraction(1);
                PlayVinyl(1);
                break;
            case 2:
                // Vinyl C interact
                VinylInteraction(2);
                PlayVinyl(2);
                break;
            case 3:
                // Vinyl D interact
                VinylInteraction(3);
                PlayVinyl(3);
                break;
            default:
                audioSource.Stop();
                break;
        }
    }

    private void VinylInteraction(int index)
    {
        GameObject vinyl = vinylsObject[index];
        Vector3 position = this.transform.position;

        Debug.Log($"Vinyl {index} interact");
        vinyl.SetActive(true);

        position.y += 0.24f;

        vinyl.transform.position = position;
        vinyl.transform.rotation = this.transform.rotation;
    }

    private void PlayVinyl(int index)
    {
            if (!isReversed) audioSource.clip = vinylsNormalAudio[index];
            else audioSource.clip = vinylsReverseAudio[index];
            audioSource.Play();
    }

    public void Reverse()
    {
        isReversed = !isReversed;
        if (currentVinyl >= 0) PlayVinyl(currentVinyl);
    }
}
