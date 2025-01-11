using UnityEngine;

public class ComputerInteraction : SpecialInteractions
{
    [SerializeField] CatUI catUI;
    [SerializeField] UIManager uiManager;

    private void Start()
    {
        catUI.gameObject.SetActive(false);
    }

    public override void SpecialInteract(Interactive interactive)
    {
        uiManager.DisablePlayer();
        catUI.gameObject.SetActive(true);
        catUI.SwapBanterText();
    }
}
