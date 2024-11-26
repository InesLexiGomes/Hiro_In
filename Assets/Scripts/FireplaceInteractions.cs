using UnityEngine;

public class FireplaceInteractions : SpecialInteractions
{
    [SerializeField] private GameObject fireplaceUIObject;
    [SerializeField] private FireplaceUI fireplaceUI;
    [SerializeField] private UIManager uiManager;

    public override void SpecialInteract(Interactive interactive)
    {
        // Open corresponding GUI and lock player
        fireplaceUIObject.SetActive(true);
        uiManager.DisablePlayer();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F2)) fireplaceUI.FinishPuzzle();
    }

    private void Awake()
    {
        fireplaceUIObject.SetActive(false);
    }

}
