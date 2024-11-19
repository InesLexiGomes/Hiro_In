using UnityEngine;

public class HandleInteraction : SpecialInteractions
{
    [SerializeField] private GramophoneInteractions gramophone;

    public override void SpecialInteract(Interactive interactive)
    {
        gramophone.Reverse();
    }
}
