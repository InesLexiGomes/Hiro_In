using UnityEngine;

public class BookSortInteraction : SpecialInteractions
{
    [SerializeField] private SortingPuzzle sortingPuzzle;
    [SerializeField] private int index;

    private Interactive bookInteractive;

    public override void SpecialInteract(Interactive interactive)
    {
        sortingPuzzle.AddIndex(index);
        bookInteractive = interactive;
    }

    public void ResetBook()
    {
        // If it doesn't have an interactive it was never interacted with and doesn't need reseting
        if (bookInteractive != null)
        {
            // Allows it to interact again
            bookInteractive.isOn = true;

            // Make it so next time it won't check if it hasn't been interacted with
            bookInteractive = null;
        }
    }
}
