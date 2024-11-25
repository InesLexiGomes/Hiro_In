using UnityEngine;

public class LockInteraction : SpecialInteractions
{
    [SerializeField] private GameObject itemToLock;
    [SerializeField] private GameObject drawer;
    [SerializeField] private GameObject lockUI;
    [SerializeField] private UIManager  uiManager;

    private void Start()
    {
        drawer.transform.localPosition = new Vector3(0, 0, 0);
        itemToLock.SetActive(false);
    }

    public override void SpecialInteract(Interactive interactive)
    {
        lockUI.SetActive(true);
        uiManager.DisablePlayer();
    }

    public void OpenLock()
    {
        drawer.transform.localPosition = new Vector3(0, 0, 0.2f);
        gameObject.SetActive(false);
        itemToLock.SetActive(true);
    }
}
