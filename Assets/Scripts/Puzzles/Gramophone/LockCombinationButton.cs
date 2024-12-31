using UnityEngine;
using UnityEngine.UI;

public class LockCombinationButton : MonoBehaviour
{
    [SerializeField] private Image image;
    [SerializeField] private LockUI lockUI;

    public int index = 0;

    private void Start()
    {
        image.color = lockUI.red;
    }

    public void DoButtonInteraction()
    {
        switch (index)
        {
            case 0:
                image.color = lockUI.blue;
                index++;
                break;
            case 1:
                image.color = lockUI.green;
                index++;
                break;
            case 2:
                image.color = lockUI.yellow;
                index++;
                break;
            case 3:
                image.color = lockUI.red;
                index = 0;
                break;
            default:
                break;
        }
    }
}
