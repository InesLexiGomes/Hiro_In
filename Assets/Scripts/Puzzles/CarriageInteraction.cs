using UnityEngine;

public class CarriageInteraction : MonoBehaviour
{
    [SerializeField] private GameObject main;
    [SerializeField] private GameObject wheels1;
    [SerializeField] private GameObject wheels2;

    private void Start()
    {
        Deactivate();
    }

    private void Deactivate()
    {
        main.SetActive(false);
        wheels1.SetActive(false);
        wheels2.SetActive(false);
    }
    public void Activate()
    {
        main.SetActive(true);
        wheels1.SetActive(true);
        wheels2.SetActive(true);
    }
}
