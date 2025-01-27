using UnityEngine;

public class BookSortInteraction : SpecialInteractions
{
    [SerializeField] private SortingPuzzle sortingPuzzle;
    [SerializeField] private int index;
    [SerializeField] private Animator animator;
    [SerializeField] private Interactive bookInteractive;
    [SerializeField] private AudioSource source;

    public override void SpecialInteract(Interactive interactive)
    {
        animator.ResetTrigger("Reset");
        sortingPuzzle.AddIndex(index);
        animator.Play("BookOut");
        source.Play();
    }

    public void ResetBook()
    {
        animator.SetTrigger("Reset");
        source.Play();
    }
}
