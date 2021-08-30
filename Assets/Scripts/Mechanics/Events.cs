using UnityEngine.SceneManagement;
using UnityEngine;

public class Events : MonoBehaviour
{
    public void ReplayGame()
    {
        //Time.timeScale = 1;
        SceneManager.LoadScene("Level");
    }

    public void GoToMenu()
    {
        //Time.timeScale = 1;
        SceneManager.LoadScene("Menu");
    }


    public void QuitGame()
    {
        Application.Quit();
    }
}
