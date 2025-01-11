using UnityEngine;
using UnityEngine.SceneManagement;
public class End : MonoBehaviour
{
    [SerializeField] private string sceneToLoad;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1")) SceneManager.LoadScene(sceneToLoad);
    }
}
