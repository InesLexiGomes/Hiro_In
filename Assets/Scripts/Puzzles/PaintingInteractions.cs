using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Splines;

public class PaintingInteractions : SpecialInteractions
{
    [SerializeField] private SplineAnimate[] train;

    void Start()
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

    public override void SpecialInteract(Interactive interactive)
    {
        Finish();
    }

    private void Finish()
    {
        gameObject.SetActive(false);
        foreach (SplineAnimate trainPart in train)
            trainPart.Loop = SplineAnimate.LoopMode.Once;
    }
}
