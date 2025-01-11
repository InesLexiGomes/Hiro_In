using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalInteraction : SpecialInteractions
{
    [SerializeField] private string sceneToLoad;

    public override void SpecialInteract(Interactive interactive)
    {
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene(sceneToLoad);
    }
}
