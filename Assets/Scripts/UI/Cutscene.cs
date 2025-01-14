using UnityEngine;
using UnityEngine.SceneManagement;

public class Cutscene : MonoBehaviour
{
    [SerializeField] private string sceneToLoad;
    [SerializeField] private float cutsceneTime;

    private float startTime;

    private void Start()
    {
        startTime = Time.time;
    }

    void Update()
    {
        if (Time.time >= cutsceneTime+startTime) SceneManager.LoadScene(sceneToLoad);
    }
}
