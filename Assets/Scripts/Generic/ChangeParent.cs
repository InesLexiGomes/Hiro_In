using UnityEngine;

public class ChangeParent : SpecialInteractions
{
    [SerializeField] private GameObject     pieceToChange;
    private Interactive                     pieceToChangeInteractive;

    private void Awake()
    {
        pieceToChangeInteractive = pieceToChange.GetComponent<Interactive>();
    }

    public override void SpecialInteract(Interactive interactive)
    {
        pieceToChange.SetActive(true);
        pieceToChange.transform.SetParent(gameObject.transform, false);
        pieceToChangeInteractive.isOn = false;
    }
}
