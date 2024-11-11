using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] private UIManager uIManager;
    [SerializeField] private float maxInteractionDistance;

    private Transform   cameraTransform;
    private Interactive currentInteractive;
    private bool        refreshCurrentInteractive;

    private void Start()
    {
        cameraTransform = GetComponentInChildren<Camera>().transform;
        currentInteractive = null;
        refreshCurrentInteractive = false;
    }

    private void Update()
    {
        UpdateCurrentInteractive();
        CheckForPlayerInteraction();
    }

    private void UpdateCurrentInteractive()
    {
        if (Physics.Raycast(cameraTransform.position, cameraTransform.forward, out RaycastHit hitInfo, maxInteractionDistance))
        {
            //CheckObjectForInteraction(hitInfo.collider);
        }
        //else if (currentInteractive != null) ClearCurrentInteractive();
    }

    private void CheckObjectForInteraction(Collider collider)
    {
        Interactive interactive = collider.GetComponent<Interactive>();

        if (interactive == null || !interactive.isOn) ClearCurrentInteractive();
    }

    private void ClearCurrentInteractive()
    {
        currentInteractive = null;
    }

    private void CheckForPlayerInteraction()
    {

    }
}