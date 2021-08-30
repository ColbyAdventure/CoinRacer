using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenu : MonoBehaviour
{

    public AudioManager AudioManag;
    //****Added To Return Time To Normal after setting  to zero for game over
    private void Start()
    {
                Time.timeScale = 1;
        AudioManag = FindObjectOfType<AudioManager>();
        //FindObjectOfType<AudioManager>().PlaySound("Jump");
        //AudioManag.PlaySound("ButtonClick");
    }
    //^^**



    public void PlayGame()
    {
        //Time.timeScale = 1;
        AudioManag.PlaySound("ButtonClick");
        SceneManager.LoadScene("Level");
    }

    public void Menu()
    {
        //Time.timeScale = 1;
        AudioManag.PlaySound("ButtonClick");
        SceneManager.LoadScene("Menu");

    }

    public void Instructions()
    {
        // Time.timeScale = 1;
        AudioManag.PlaySound("ButtonClick");
        SceneManager.LoadScene("Instructions");
    }

    public void Info()
    {
        //Time.timeScale = 1;
        AudioManag.PlaySound("ButtonClick");
        SceneManager.LoadScene("Info");
    }


    public void QuitGame()
    {
        AudioManag.PlaySound("ButtonClick");
        Application.Quit();
    }
}
