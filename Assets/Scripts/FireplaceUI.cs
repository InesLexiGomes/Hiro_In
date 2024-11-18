using UnityEngine;

public class FireplaceUI : MonoBehaviour
{
    [SerializeField] UIManager uIManager;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K)) Quit();
    }

    private void Quit()
    {
            uIManager.EnablePlayer();
            this.gameObject.SetActive(false);
    }
}
