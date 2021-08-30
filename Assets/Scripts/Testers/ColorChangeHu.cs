using UnityEngine;
using System.Collections;
public class ColorChangeHu : MonoBehaviour
{
 
    [Range(0,1)]
    public float hue = 0;
    public float saturation = 1;
    public float Value = 1;


    public float timeSinceStart = 0;


    [Range(0, 10)]
    public int changeSpeed = 1;


    public Material testsMat;

    public float howMuchItChangesPerSecond = 0.1f;

    void Start()
    {
        testsMat.color = Color.HSVToRGB(hue, saturation, Value);
    }

    void Update()
    {
        timeSinceStart += Time.deltaTime;
        //print(timeSinceStart + " Since The Start");

        if (hue > 1)
        {
            hue = 0;
        }


        testsMat.color = Color.HSVToRGB(hue, saturation, Value);




        //displaySeconds = seconds % 60;
        if ((int)(timeSinceStart) % changeSpeed == 0)
        {
            hue +=  (howMuchItChangesPerSecond * Time.deltaTime);

        }
        //This Makes it progress for a second (Cuz Rounding with (int)) every "changeSpeed"th     nth Second




        //print(hue + " hue");

    }




}