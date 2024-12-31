using UnityEngine;

public class VinylsStopPlaying : SpecialInteractions
{
    [SerializeField] private GramophoneInteractions gramophone;
    public override void SpecialInteract(Interactive interactive)
    {
        gramophone.StopMusic();
    }
}
