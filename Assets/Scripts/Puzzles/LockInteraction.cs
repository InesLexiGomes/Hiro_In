using UnityEngine;
using UnityEngine.UI;

public class LockInteraction : SpecialInteractions
{
    [SerializeField] private GameObject itemToLock;
    [SerializeField] private GameObject skylights;
    [SerializeField] private GameObject drawer;
    [SerializeField] private GameObject lockUI;
    [SerializeField] private UIManager  uiManager;
    [SerializeField] private CarriageInteraction carriageInteraction;
    [SerializeField] private TrainAudio trainAudio;
    [SerializeField] private Image tripEffect;
    [SerializeField] private PlayerInventory playerInventory;
    [SerializeField] private GameObject[] vinyls;
    [SerializeField] private GramophoneInteractions gramophone;

    private void Start()
    {
        drawer.transform.localPosition = new Vector3(0, 0, 0);
        itemToLock.SetActive(false);
        skylights.SetActive(false);
        lockUI.SetActive(false);
        tripEffect.enabled = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1)) OpenLock();
    }

    public override void SpecialInteract(Interactive interactive)
    {
        lockUI.SetActive(true);
        uiManager.DisablePlayer();
    }

    public void OpenLock()
    {
        carriageInteraction.Activate();
        drawer.transform.localPosition = new Vector3(0, 0, 0.2f);
        gameObject.SetActive(false);
        itemToLock.SetActive(true);
        skylights.SetActive(true);
        tripEffect.enabled = true;
        trainAudio.TrainCompletePuzzle();
        ClearVinyls();
    }

    private void ClearVinyls()
    {
        gramophone.StopMusic();
        playerInventory.ClearInventory();
        foreach (GameObject vinyl in vinyls)
            vinyl.SetActive(false);
    }
}
