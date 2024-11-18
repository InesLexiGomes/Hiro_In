using UnityEngine;

public class FireplaceInteractions : SpecialInteractions
{
    [SerializeField] private GameObject fireplaceUI;
    [SerializeField] private UIManager uIManager;

    public override void SpecialInteract(Interactive interactive)
    {
        // Open corresponding GUI and lock player
        Cursor.lockState    = CursorLockMode.None;
        fireplaceUI.SetActive(true);
        uIManager.DisablePlayer();
    }
}
