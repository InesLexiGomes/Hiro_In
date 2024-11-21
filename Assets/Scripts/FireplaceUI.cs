using System;
using System.Collections.Generic;
using UnityEngine;

public class FireplaceUI : MonoBehaviour
{
    [SerializeField] private GameObject coinHolder;
    [SerializeField] private UIManager uIManager;

    public int                      CoinCount = 8;
    private CoinSlotInteraction[]   coinArray;
    private bool[]                  SolutionArray;
    private bool[]                  libraArray = new bool[]
    {true, false, true, false, false,
    false, false, false, true, false,
    true, false, false, false, true,
    false, false, false, false, false,
    false, true, false, false, false};

    private void Awake()
    {
        coinArray = coinHolder.GetComponentsInChildren<CoinSlotInteraction>();
        SolutionArray = new bool[25];
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
            coin.GetCoinValue(SolutionArray);
        }
        foreach (bool solution in SolutionArray)
        {
            Debug.Log($"Slot {solution}");
        }
    }
}
