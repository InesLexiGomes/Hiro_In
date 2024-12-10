using UnityEngine;

public class BookInteractions : SpecialInteractions
{
    [SerializeField] private GameObject astronomyBook;
    [SerializeField] private UIManager uiManager;

    private void Start()
    {
        astronomyBook.SetActive(false);
    }

    public override void SpecialInteract(Interactive interactive)
    {
        astronomyBook.SetActive(true);
        uiManager.DisablePlayer();
    }
}
