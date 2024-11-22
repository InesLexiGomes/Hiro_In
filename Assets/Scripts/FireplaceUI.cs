using System;
using System.Collections.Generic;
using UnityEngine;

public class FireplaceUI : MonoBehaviour
{
    [SerializeField] private GameObject     coinHolder;
    [SerializeField] private UIManager      uIManager;
    [SerializeField] private Interactive    fireplaceInteractive;
    [SerializeField] private GameObject   paintingsNormal;
    [SerializeField] private GameObject   paintingsChanged;

    public int                      CoinCount = 8;
    private int                     currentConstelation = 3;
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
        if (Input.GetKeyDown(KeyCode.V)) GetSolution(libraArray);
    }

    private void Quit()
    {
            uIManager.EnablePlayer();
            this.gameObject.SetActive(false);
    }

    public void GetSolution(bool[] currentArray)
    {
        // Need to review if I can shorten this code, maybe try bringing the coin slot value so I don't need to organize them first
        foreach (CoinSlotInteraction coin in coinArray)
        {
            coin.GetCoinValue(SolutionArray);
        }
        bool isEqual = true;
        for (int i = 0; i < SolutionArray.Length; i++)
        {
            if (currentArray[i] != SolutionArray[i])
            {
                isEqual = false;
                break;
            }
        }

        /*if (isEqual && currentConstelation <3)
        {
            NextConstelation();
        }*/

        if (isEqual && currentConstelation >= 3)
        {
            FinishPuzzle();
        }
    }

    private void FinishPuzzle()
    {
        fireplaceInteractive.isOn = false;
        // (GameObject paintingNormal in paintingsNormal)
            //paintingNormal.SetActive(false);
        paintingsChanged.SetActive(true);

        // Add Visual indicator
    }

    private void NextConstelation()
    {
        foreach (CoinSlotInteraction coin in coinArray) coin.RemoveCoin();
        currentConstelation++;
        CoinCount = 8;

        // Add a visual indicator that it is done
    }
}
