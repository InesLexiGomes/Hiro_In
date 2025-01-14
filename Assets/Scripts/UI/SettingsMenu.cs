using UnityEngine;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    [SerializeField] private Image tripEffect;
    [SerializeField] private Slider effectsSlider;
    [SerializeField] private Slider soundSlider;

    private void Start()
    {
        gameObject.SetActive(false);
    }

    private void Update()
    {

    }

    public void Confirm()
    {
        tripEffect.color = new Vector4(1, 1, 1, effectsSlider.value);

        gameObject.SetActive(false);
    }
}
