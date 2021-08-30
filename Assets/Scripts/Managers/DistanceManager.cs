using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DistanceManager : MonoBehaviour
{

    public float playerDistance;

    public Text displayText;

    void Update()
    {
        if (LevelManager.isGameStarted)
        {
            playerDistance += Time.deltaTime;
            displayText.text = (int)playerDistance + " m";
        }
    }
}
