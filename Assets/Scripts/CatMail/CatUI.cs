using UnityEngine;
using UnityEngine.UI;

public class CatUI : MonoBehaviour
{
    [SerializeField] private CatPhrases catPhrases;
    [SerializeField] private Text catText;

    [Header("Used only for testing")]
    // After each puzzle increase by 1
    [SerializeField] private int currentPuzzle;
    // After asking for a hint increase by 1 and reset to 0 when at next puzzle
    [SerializeField] private int hintCount;

    private void Start()
    {
        currentPuzzle = 0;
        hintCount = 0;
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
                return CheckBanterFromArray(catPhrases.GramophoneHints);
            case (1):
                return CheckBanterFromArray(catPhrases.FireplaceHints);
            case (2):
                return CheckBanterFromArray(catPhrases.PaintingHints);
            case (3):
                return CheckBanterFromArray(catPhrases.TrainHints);
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
}
