using UnityEngine;

public class TrainAudio : MonoBehaviour
{
    [SerializeField] private AudioSource    audioSource;
    [SerializeField] private AudioClip      audioNormal;
    [SerializeField] private AudioClip      audioAlt;

    public void TrainCompletePuzzle()
    {
        audioSource.clip = audioNormal;
        audioSource.Play();
    }
    public void TrainStop()
    {
        audioSource.clip = audioAlt;
        audioSource.Play();
    }
}
