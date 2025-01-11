using UnityEngine;
using TMPro;

public class CatUI : MonoBehaviour
{
    [SerializeField] private CatPhrases catPhrases;
    [SerializeField] private TextMeshProUGUI catText;
    [SerializeField] private UIManager uiManager;

    // After each puzzle increase by 1
    private int currentPuzzle;
    // After asking for a hint increase by 1 and reset to 0 when at next puzzle
    private int hintCount;

    private void Start()
    {
        currentPuzzle = 0;
        hintCount = 0;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) Quit();
    }

    public void SwapBanterText()
    {
        catText.text = GetBanterText();
    }

    private string GetBanterText()
    {
        switch (currentPuzzle)
        {
            case (0):
                return CheckBanterFromArray(catPhrases.GramophoneBanter);
            case (1):
                return CheckBanterFromArray(catPhrases.FireplaceBanter);
            case (2):
                return CheckBanterFromArray(catPhrases.PaintingBanter);
            case (3):
                return CheckBanterFromArray(catPhrases.TrainBanter);
            case (4):
                return CheckBanterFromArray(catPhrases.WinBanter);
            default:
                return "";
        }
    }

    private string CheckBanterFromArray(string[] banterArray)
    {
        int random = Random.Range(0, banterArray.Length);
        return banterArray[random];
    }

    public void SwapTextHint()
    {
        catText.text = GetHintText();
    }

    private string GetHintText()
    {
        switch (currentPuzzle)
        {
            case (0):
                return CheckHintFromArray(catPhrases.GramophoneHints);
            case (1):
                return CheckHintFromArray(catPhrases.FireplaceHints);
            case (2):
                return CheckHintFromArray(catPhrases.PaintingHints);
            case (3):
                return CheckHintFromArray(catPhrases.TrainHints);
            case (4):
                return CheckHintFromArray(catPhrases.WinHints);
            default:
                return "";
        }
    }

    private string CheckHintFromArray(string[] hintArray)
    {
        if (hintCount >= hintArray.Length)
            hintCount = hintArray.Length - 1;

        return hintArray[hintCount];
    }

    public void NextPuzzle(int puzzle)
    {
        currentPuzzle = puzzle;
    }
    private void Quit()
    {
        uiManager.EnablePlayer();
        this.gameObject.SetActive(false);
    }
}
