using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MultipleManager : MonoBehaviour
{
    public static float currentMultiple;

    public Text multipleText;

    public float HowManySlicesOfPie; //(1/nth of the pie)

    void Start()
    {
        currentMultiple = 1f;
    }

    void Update()
    {
        //****This One Trims the UI Text to One Decimal Place
        multipleText.text = "" + currentMultiple.ToString("F1");
        //multipleText.text = "" + currentMultiple;

        //Debug.Log("Distance travelled" + currentMultiple.ToString("F1") + "  m");

        if (currentMultiple > 1)
        {
            currentMultiple = currentMultiple - (Time.deltaTime / HowManySlicesOfPie);
        }
        else
        {//This One is here to stop it from flashing 0.999 randomly
            currentMultiple = 1;
        }
    }


}
