using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemRotation : MonoBehaviour
{
    public float rotationOnXAxis = 130;
    public float rotationOnYAxis;
    public float rotationOnZAxis;


    [SerializeField]
    private bool isRotating = false;

    public float delayBeforeStart;

    // Start is called before the first frame update
    void Start()
    {
        //Run a Co Routine To Wait x Seconds

        StartCoroutine(ExampleCoroutine());

    }

    IEnumerator ExampleCoroutine()
    {
        //Print the time of when the function is first called.
        //Debug.Log("Started Coroutine at timestamp : " + Time.time);

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds((delayBeforeStart *2));// * transform.position.z);

        //After we have waited 5 seconds print the time again.
        //Debug.Log("Finished Coroutine at timestamp : " + Time.time);

        isRotating = true;

    }



        // Update is called once per frame
        void Update()
    {
        if (isRotating)
        {
            transform.Rotate(rotationOnXAxis * Time.deltaTime, rotationOnYAxis * Time.deltaTime, rotationOnZAxis * Time.deltaTime);
        }

        
    }
}
