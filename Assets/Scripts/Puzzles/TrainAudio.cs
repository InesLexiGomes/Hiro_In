using UnityEngine;

public class TrainAudio : MonoBehaviour
{
    [SerializeField] private AudioSource    audioSource;
    [SerializeField] private AudioClip      audio;
    [SerializeField] private AudioClip      audioAlt;

    public void TrainCompletePuzzle()
    {
        audioSource.clip = audio;
        audioSource.Play();
    }
    public void TrainStop()
    {
        audioSource.clip = audioAlt;
        audioSource.Play();
    }
}
