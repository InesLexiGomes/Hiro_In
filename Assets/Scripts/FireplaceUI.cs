using System;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.Rendering.DebugUI;

public class FireplaceUI : MonoBehaviour
{
    [SerializeField] private GameObject coinHolder;
    [SerializeField] private UIManager uIManager;

    public int coinCount = 8;

    private CoinSlotInteraction[]   coinArray;
    public bool[]                   solutionArray;

    private void Awake()
    {
        coinArray = coinHolder.GetComponentsInChildren<CoinSlotInteraction>();
        solutionArray = new bool[25];
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K)) Quit();
        if (Input.GetKeyDown(KeyCode.V)) GetSolution();
    }

    private void Quit()
    {
            uIManager.EnablePlayer();
            this.gameObject.SetActive(false);
    }

    public void GetSolution()
    {
        foreach (CoinSlotInteraction coin in coinArray)
        {
            coin.GetCoinValue(solutionArray);
        }
        foreach (bool solution in solutionArray)
        {
            Debug.Log($"Slot {solution}");
        }
    }
}
