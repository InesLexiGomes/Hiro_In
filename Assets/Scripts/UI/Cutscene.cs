using UnityEngine;
using UnityEngine.SceneManagement;

public class Cutscene : MonoBehaviour
{
    [SerializeField] private string sceneToLoad;
    [SerializeField] private float cutsceneTime;
    void Update()
    {
        if (Time.time >= cutsceneTime) SceneManager.LoadScene(sceneToLoad);
    }
}
