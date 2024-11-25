using UnityEngine;
using UnityEngine.UI;

public class LockUI : MonoBehaviour
{
    [SerializeField] private UIManager                  uiManager;
    [SerializeField] private LockInteraction            lockInteraction;
    [SerializeField] private LockCombinationButton[]    buttons;

    public Color red;
    public Color blue;
    public Color green;
    public Color yellow;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) Quit();
    }
    private void Quit()
    {
        uiManager.EnablePlayer();
        this.gameObject.SetActive(false);
    }
    public void CheckSolution()
    {
        if (buttons[0].index == 0 && 
            buttons[1].index == 1 &&
            buttons[2].index == 2 &&
            buttons[3].index == 3 &&
            buttons[4].index == 0)
        {
            lockInteraction.OpenLock();
            Quit();
        }
    }
}
