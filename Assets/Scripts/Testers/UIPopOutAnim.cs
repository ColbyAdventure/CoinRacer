using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPopOutAnim : MonoBehaviour
{



    public bool AnimationisRunning = false;
    //private int gems;

    public  Animator anim;


    // Update is called once per frame
    void Update()
    {

        if (CollectableManager.numberOfCoins <1)
        {
            return;
        }
        WhenTheNumberHitsTen();

        WhenTheNumberHitsEleven();
    }

    void WhenTheNumberHitsTen()
    {
        if (CollectableManager.numberOfCoins % 10 == 0)
        {
            if (AnimationisRunning == true)
            {
                return;

            }
            else
            {
                //anim.enabled = true;
                AnimationisRunning = true;
                print("First Ten!");
            }

            print("Ten!");
        }
    }


    void WhenTheNumberHitsEleven()
    {
        if (CollectableManager.numberOfCoins % 10 == 1)
        {
            if (AnimationisRunning == true)
            {

                //anim.enabled = false;
                AnimationisRunning = false;
                print("First Eleven!");


            }

        }
    }


    void FirstTimeFlipper() {
        anim.enabled = AnimationisRunning;
    }


}
/*
 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPopOutAnim : MonoBehaviour
{



    public bool AnimationisRunning = false;
    //private int gems;

    public  Animator anim;


    // Update is called once per frame
    void Update()
    {

        if (CollectableManager.numberOfCoins <1)
        {
            return;
        }
        WhenTheNumberHitsTen();

        WhenTheNumberHitsEleven();
    }

    void WhenTheNumberHitsTen()
    {
        if (CollectableManager.numberOfCoins % 10 == 0)
        {
            if (AnimationisRunning == true)
            {
                return;

            }
            else
            {
                anim.enabled = true;
                AnimationisRunning = true;
                print("First Ten!");
            }

            print("Ten!");
        }
    }


    void WhenTheNumberHitsEleven()
    {
        if (CollectableManager.numberOfCoins % 10 == 1)
        {
            if (AnimationisRunning == true)
            {

                anim.enabled = false;
                AnimationisRunning = false;
                print("First Eleven!");


            }

        }
    }


}

     */

