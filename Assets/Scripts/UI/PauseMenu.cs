using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] UIManager uIManager;
    [SerializeField] GameObject confirmScreen;

    private bool exit = false; // False is used to go to the main menu while true is used to exit

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            Resume();
    }

    public void Resume()
    {
        gameObject.SetActive(false);
        confirmScreen.SetActive(false);
        uIManager.EnablePlayer();
    }

    public void MainMenu()
    {
        exit = false;
        ConfirmScreen();
    }

    public void Exit()
    {
        exit = true;
        ConfirmScreen();
    }

    private void ConfirmScreen()
    {
        confirmScreen.SetActive(true);
    }

    public void Confirm()
    {
        if (exit)
            Application.Quit();
        else
            SceneManager.LoadScene("MainMenu");
    }

    public void Cancel()
    {
        confirmScreen.SetActive(false);
    }
}
