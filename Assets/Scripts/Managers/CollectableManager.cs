using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectableManager : MonoBehaviour
{
    //Coins
    public static int numberOfCoins;
    public Text coinsText;


    //Gems
    public static int numberOfGems;
    public Text gemsText;


    void Start()
    {

        numberOfCoins = 0;
        numberOfGems = 0;

    }


    void Update()
    {

        coinsText.text = "" + numberOfCoins;
        gemsText.text = "" + numberOfGems;

    }

}
