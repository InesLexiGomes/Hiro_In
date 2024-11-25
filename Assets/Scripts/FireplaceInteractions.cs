using UnityEngine;

public class FireplaceInteractions : SpecialInteractions
{
    [SerializeField] private GameObject fireplaceUI;
    [SerializeField] private UIManager uiManager;

    public override void SpecialInteract(Interactive interactive)
    {
        // Open corresponding GUI and lock player
        fireplaceUI.SetActive(true);
        uiManager.DisablePlayer();
    }

    private void Awake()
    {
        fireplaceUI.SetActive(false);
    }

}
