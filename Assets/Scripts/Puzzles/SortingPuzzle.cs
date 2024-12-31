using UnityEngine;
using System.Collections.Generic;

public class SortingPuzzle : MonoBehaviour
{
    [SerializeField] private int[] solution;

    // List of attempts the player has made
    private List<int> attempts = new List<int>();

    //Check Solution and reset if attempts are equal or bigger lenght
    private void CheckSolution()
    {
        // Safety in case it exceeds the lenght of the solution
        if (attempts.Count > solution.Length)
            attempts = new List<int>();

        if (attempts.Count == solution.Length)
        {
            if (Compare())
            {
                // Execute finish puzzle code here
            }
            else
                attempts = new List<int>();
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
}
