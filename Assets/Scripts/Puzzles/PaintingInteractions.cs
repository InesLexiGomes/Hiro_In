using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Splines;

public class PaintingInteractions : SpecialInteractions
{
    [SerializeField] private Interactive[]          paintingSlots;
    [SerializeField] private Interactive[]          books;
    [SerializeField] private CatUI                  catUI;
    [SerializeField] private SplineAnimate[]        train;
    [SerializeField] private CarriageInteraction    carriageInteraction;
    [SerializeField] private TrainAudio             trainAudio;
    [SerializeField] private CompletePuzzleAudio completePuzzleAudio;

    private bool finish = false;

    private void Start()
    {
        gameObject.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F3))
        {
            Finish();
        }
    }
    private void FixedUpdate()
    {
        foreach (Interactive slot in paintingSlots)
        {
            if (slot.requirementsMet)
            {
                finish = true;
            }
            else
            {
                finish = false;
                break;
            }
        }
        if (finish)
            Finish();
    }

    public override void SpecialInteract(Interactive interactive)
    {
        Finish();
    }

    private void Finish()
    {
        gameObject.SetActive(false);
        catUI.NextPuzzle(3);
        carriageInteraction.Activate();
        trainAudio.TrainStop();
        completePuzzleAudio.PlayComplete();
        foreach (SplineAnimate trainPart in train)
            trainPart.Loop = SplineAnimate.LoopMode.Once;
    }
}
