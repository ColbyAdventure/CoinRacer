using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public static bool isGameOver;
    public GameObject  gameOverPanel;

    public static bool isGameStarted;
    public GameObject  startingPanel;

    public GameObject  ColourChanger;

    void Start()
    {
        Time.timeScale = 1;
        isGameOver = false;
        isGameStarted = false;

    }


    void Update()
    {
        if (isGameOver)
        {
            gameOverPanel.SetActive(true);
            Time.timeScale = 0;
            ColourChanger.SetActive(false);
        }


        if (SwipeManager.tap  && !isGameStarted)
        {//Combine With Get Key Down Version Below
            isGameStarted = true;
            Destroy(startingPanel);
            ColourChanger.SetActive(true);

        }

        if (Input.anyKey)
        {//Combine With SwipeManager Version Above
            isGameStarted = true;
            Destroy(startingPanel);
            ColourChanger.SetActive(true);
        }

    }
}
