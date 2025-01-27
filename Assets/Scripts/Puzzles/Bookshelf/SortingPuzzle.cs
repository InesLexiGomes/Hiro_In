using UnityEngine;
using System.Collections.Generic;

public class SortingPuzzle : MonoBehaviour
{
    [Header("Main")]

    [SerializeField] private Animator animator;
    // Correct solution player needs to input
    [SerializeField] private int[] solution;
    // List of attempts the player has made
    private List<int> attempts = new List<int>();

    [Header("Reset")]
    [SerializeField] private BookSortInteraction[] books;

    [Header("Finish")]
    [SerializeField] private GameObject portal;
    [SerializeField] private CatUI catUI;
    [SerializeField] private CompletePuzzleAudio completePuzzleAudio;

    private void Start()
    {
        portal.SetActive(false);
    }

    //Check Solution and reset if attempts are equal or bigger lenght
    private void CheckSolution()
    {
        // Safety in case it exceeds the lenght of the solution
        if (attempts.Count > solution.Length)
            ResetPuzzle();

        if (attempts.Count == solution.Length)
        {
            if (Compare())
            {
                CompletePuzzle();
            }
            else ResetPuzzle();
        }
    }

    private bool Compare()
    {
        for (int i = 0; i < solution.Length; i++)
        {
            if (solution[i] != attempts[i])
                return false;
        }
        return true;
    }

    public void AddIndex(int index)
    {
        attempts.Add(index);
        CheckSolution();
    }

    private void ResetPuzzle()
    {
        completePuzzleAudio.PlayFailed();
        attempts = new List<int>();
        foreach(BookSortInteraction book in books)
        {
            book.ResetBook();
        }
    }

    private void CompletePuzzle()
    {
        Debug.Log("Finished");
        animator.Play("BookshelfAwake");
        portal.SetActive(true);
        catUI.NextPuzzle(4);
        completePuzzleAudio.PlayComplete();
    }
}
