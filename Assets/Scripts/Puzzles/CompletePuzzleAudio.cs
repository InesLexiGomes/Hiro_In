using UnityEngine;

public class CompletePuzzleAudio : MonoBehaviour
{
    [SerializeField] private AudioSource source;
    [SerializeField] private AudioClip completeAudio;
    [SerializeField] private AudioClip failedAudio;

    public void PlayComplete()
    {
        source.clip = completeAudio;
        source.Play();
    }

    public void PlayFailed()
    {
        source.clip = failedAudio;
        source.Play();
    }
}
