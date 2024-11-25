using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadSceneAsync("HiroIn");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
