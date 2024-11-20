using UnityEngine;
using UnityEngine.UI;

public class FireplaceUI : MonoBehaviour
{
    [SerializeField] private GameObject coinHolder;
    [SerializeField] private UIManager uIManager;

    public int coinCount = 8;

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
