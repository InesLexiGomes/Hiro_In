using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FireplaceUI : MonoBehaviour
{
    [SerializeField] private GameObject coinHolder;
    [SerializeField] private UIManager uiManager;
    [SerializeField] private Interactive fireplaceInteractive;
    [SerializeField] private FireplaceSolutions solutions;
    [SerializeField] private GameObject paintingsNormal;
    [SerializeField] private GameObject paintingsChanged;
    [SerializeField] private Image[] fireplaceLights;
    [SerializeField] private Color lightsColor;
    [SerializeField] private CatUI catUI;
    [SerializeField] private CarriageInteraction carriageInteraction;
    [SerializeField] private TrainAudio trainAudio;
    [SerializeField] private Image tripEffect;
    [SerializeField] private CompletePuzzleAudio completePuzzleAudio;

    public int CoinCount = 8;
    private int currentConstelation = 1;
    private CoinSlotInteraction[] coinArray;
    private bool[] SolutionArray;
    private bool isEqual = true;

    private void Awake()
    {
        coinArray = coinHolder.GetComponentsInChildren<CoinSlotInteraction>();
        SolutionArray = new bool[25];
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) Quit();
    }

    private void Quit()
    {
        uiManager.EnablePlayer();
        this.gameObject.SetActive(false);
    }

    private void GetSolution(bool[][] currentArray)
    {
        foreach (bool[] solution in currentArray)
        {
            // Need to review if I can shorten this code, maybe try bringing the coin slot value so I don't need to organize them first
            foreach (CoinSlotInteraction coin in coinArray)
            {
                coin.GetCoinValue(SolutionArray);
            }
            isEqual = true;
            for (int i = 0; i < SolutionArray.Length; i++)
            {
                if (solution[i] != SolutionArray[i])
                {
                    isEqual = false;
                    break;
                }
            }

            Debug.Log(isEqual);

            if (isEqual && currentConstelation < 3)
            {
                NextConstelation();
                break;
            }

            else if (isEqual && currentConstelation >= 3)
            {
                FinishPuzzle();
                break;
            }
        }
    }

    public void FinishPuzzle()
    {
        fireplaceInteractive.isOn = false;
        // (GameObject paintingNormal in paintingsNormal)
        //paintingNormal.SetActive(false);
        paintingsChanged.SetActive(true);
        Quit();
        catUI.NextPuzzle(2);
        carriageInteraction.Activate();
        trainAudio.TrainCompletePuzzle();
        tripEffect.enabled = false;

        // Add Visual indicator
    }

    private void NextConstelation()
    {
        fireplaceLights[currentConstelation - 1].color = lightsColor;

        foreach (CoinSlotInteraction coin in coinArray) coin.RemoveCoin();
        currentConstelation++;
        CoinCount = 8;
    }

    public void DoButtonInteraction()
    {
        switch (currentConstelation)
        {
            case 1:
                GetSolution(solutions.libraArray);
                CheckSoundToPlay();
                break;
            case 2:
                GetSolution(solutions.cancerArray);
                CheckSoundToPlay();
                break;
            case 3:
                GetSolution(solutions.ariesArray);
                CheckSoundToPlay();
                break;
            default:
                break;
        }
    }

    private void CheckSoundToPlay()
    {
        if (isEqual)
            completePuzzleAudio.PlayComplete();
        else
            completePuzzleAudio.PlayFailed();
    }
}