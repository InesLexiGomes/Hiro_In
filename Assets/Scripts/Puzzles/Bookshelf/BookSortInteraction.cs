using UnityEngine;

public class BookSortInteraction : SpecialInteractions
{
    [SerializeField] private SortingPuzzle sortingPuzzle;
    [SerializeField] private int index;
    [SerializeField] private Animator animator;
    [SerializeField] private Interactive bookInteractive;

    public override void SpecialInteract(Interactive interactive)
    {
        animator.ResetTrigger("Reset");
        sortingPuzzle.AddIndex(index);
        animator.Play("BookOut");
    }

    public void ResetBook()
    {
        animator.SetTrigger("Reset");
    }
}
