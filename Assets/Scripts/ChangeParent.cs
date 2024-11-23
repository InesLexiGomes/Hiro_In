using UnityEngine;

public class ChangeParent : SpecialInteractions
{
    [SerializeField] GameObject pieceToChange;

    public override void SpecialInteract(Interactive interactive)
    {
        pieceToChange.SetActive(true);
        pieceToChange.transform.SetParent(gameObject.transform, false);
    }
}
