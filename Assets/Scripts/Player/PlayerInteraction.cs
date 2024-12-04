using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] private UIManager  uiManager;
    [SerializeField] private float      maxInteractionDistance;

    private Transform   cameraTransform;
    private Interactive currentInteractive;
    private bool        refreshCurrentInteractive;

    void Start()
    {
        cameraTransform = GetComponentInChildren<Camera>().transform;
        currentInteractive = null;
        refreshCurrentInteractive = false;
    }

    void Update()
    {
        UpdateCurrentInteractive();
        CheckForPlayerInteraction();
    }

    private void UpdateCurrentInteractive()
    {
        if (Physics.Raycast(cameraTransform.position, cameraTransform.forward, out RaycastHit hitInfo, maxInteractionDistance))
            CheckObjectForInteraction(hitInfo.collider);
        else if (currentInteractive != null)
            ClearCurrentInteractive();
    }

    private void CheckObjectForInteraction(Collider collider)
    {
        Interactive interactive = collider.GetComponent<Interactive>();

        if (interactive == null || !interactive.isOn)
        {
            if (currentInteractive != null)
                ClearCurrentInteractive();
        }
        else if (interactive != currentInteractive || refreshCurrentInteractive)
            SetCurrentInteractive(interactive);
    }

    private void ClearCurrentInteractive()
    {
        currentInteractive = null;
        uiManager.HideInteractionPanel();
    }

    private void SetCurrentInteractive(Interactive interactive)
    {
        currentInteractive = interactive;
        refreshCurrentInteractive = false;

        string interactionMessage = interactive.GetInteractionMessage();

        if (interactionMessage != null && interactionMessage.Length > 0)
            uiManager.ShowInteractionPanel(interactionMessage);
        else
            uiManager.HideInteractionPanel();
    }

    private void CheckForPlayerInteraction()
    {
        if (Input.GetButtonDown("Fire1") && currentInteractive != null)
        {
            currentInteractive.Interact();
            refreshCurrentInteractive = true;
        }
    }

    public void RefreshCurrentInteractive()
    {
        refreshCurrentInteractive = true;
    }
}
