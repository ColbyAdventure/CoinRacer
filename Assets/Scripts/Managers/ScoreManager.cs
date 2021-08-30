using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{

    public float playerScore;

    public Text scoreText;

    void Start()
    {
        playerScore = 0;
    }


    void Update()
    {
        if (LevelManager.isGameStarted)
        {
            playerScore += (Time.deltaTime * MultipleManager.currentMultiple);

            scoreText.text = "" + (int)playerScore;

            //This One Has Decimals
            //scoreText.text = "" + playerScore;
        }
    }
}
