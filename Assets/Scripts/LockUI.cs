using UnityEngine;
using UnityEngine.UI;

public class LockUI : MonoBehaviour
{
    [SerializeField] private UIManager          uiManager;
    [SerializeField] private Sprite             red;
    [SerializeField] private Sprite             blue;
    [SerializeField] private Sprite             green;
    [SerializeField] private Sprite             yellow;
    [SerializeField] private Image[]            buttons;
    [SerializeField] private LockInteraction    lockInteraction;

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
        if (buttons[0] == red && buttons[1] == green && buttons[2] == blue && buttons[3] == yellow && buttons[4] == red)
        {
            lockInteraction.OpenLock();
            Quit();
        }
    }
}
