using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController1 : MonoBehaviour
{

    private CharacterController conteroller;
    private Vector3 diraectionFor;

    public float forwardSpeed;


    private int desiredLane = 1;//0:left, 1:middle, 2:right
    public float laneDistance = 2.5f;//The distance between tow lanes

    public float jumpForce;
    public float gravity = -20;







    // Start is called before the first frame update
    void Start()
    {
        conteroller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        diraectionFor.z = forwardSpeed;
        diraectionFor.y += gravity * Time.deltaTime;

        if (conteroller.isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                Jump();

            }
        }



        //Inputs

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            print("Right");
            desiredLane++;
            if (desiredLane == 3)
            {
                desiredLane = 2;
            }
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            print("Left");
            desiredLane--;
            if (desiredLane <=0)
            {
                desiredLane = 0;
            }
        }




            //Calculate where we should be in the future
            Vector3 targetPosition = transform.position.z * transform.forward + transform.position.y * transform.up;

        if (desiredLane == 0)
            targetPosition += Vector3.left * laneDistance;
        else if (desiredLane == 2)
            targetPosition += Vector3.right * laneDistance;

       // transform.position = targetPosition;
        //transform.position = Vector3.Lerp(transform.position, targetPosition, 10 * Time.deltaTime);
        transform.position = Vector3.Lerp(transform.position, targetPosition, 800 * Time.deltaTime);
    }

    private void FixedUpdate()
    {
        conteroller.Move(diraectionFor * Time.fixedDeltaTime);
    }







    private void Jump()
    {
        diraectionFor.y += jumpForce;
    }
}




public class PlayerController1a : MonoBehaviour
{/*
    private CharacterController controller;
    private Vector3 direction;
    public float forwardSpeed;
    public float maxSpeed;

    private int desiredLane = 1;//0:left, 1:middle, 2:right
    public float laneDistance = 2.5f;//The distance between tow lanes

    public bool isGrounded;
    public LayerMask groundLayer;
    public Transform groundCheck;

    public float jumpForce;
    public float Gravity = -20;

    public Animator animator;
    private bool isSliding = false;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (!LevelManager.isGameStarted)
            return;

        //Increase Speed 
        if (forwardSpeed < maxSpeed)
            forwardSpeed += 0.1f * Time.deltaTime;


        animator.SetBool("isGameStarted", true);
        direction.z = forwardSpeed;

        isGrounded = Physics.CheckSphere(groundCheck.position, 0.15f, groundLayer);
        animator.SetBool("isGrounded", isGrounded);
        if (isGrounded)
        {
            direction.y = -2;
            if (SwipeManager.swipeUp)
                Jump();

            if (SwipeManager.swipeDown && !isSliding)
                StartCoroutine(Slide());
        }
        else
        {
            direction.y += Gravity * Time.deltaTime;
            if (SwipeManager.swipeDown && !isSliding)
            {
                StartCoroutine(Slide());
                direction.y = -8;
            }


        }

        //Gather the inputs on which lane we should be
        if (SwipeManager.swipeRight)
        {
            desiredLane++;
            if (desiredLane == 3)
                desiredLane = 2;
        }
        if (SwipeManager.swipeLeft)
        {
            desiredLane--;
            if (desiredLane == -1)
                desiredLane = 0;
        }

        //Calculate where we should be in the future
        Vector3 targetPosition = transform.position.z * transform.forward + transform.position.y * transform.up;
        if (desiredLane == 0)
            targetPosition += Vector3.left * laneDistance;
        else if (desiredLane == 2)
            targetPosition += Vector3.right * laneDistance;


        //transform.position = targetPosition;
        if (transform.position == targetPosition)
            return;
        Vector3 diff = targetPosition - transform.position;
        Vector3 moveDir = diff.normalized * 25 * Time.deltaTime;
        if (moveDir.sqrMagnitude < diff.magnitude)
            controller.Move(moveDir);
        else
            controller.Move(diff);


    }
    private void FixedUpdate()
    {
        if (!LevelManager.isGameStarted)
            return;
        controller.Move(direction * Time.fixedDeltaTime);
    }

    private void Jump()
    {
        direction.y = jumpForce;
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.transform.tag == "Obstacle")
        {
            LevelManager.isGameOver = true;
            FindObjectOfType<AudioManager>().PlaySound("GameOver");
        }
    }

    private IEnumerator Slide()
    {
        isSliding = true;
        animator.SetBool("isSliding", true);
        controller.center = new Vector3(0, -0.5f, 0);
        controller.height = 1;

        yield return new WaitForSeconds(1.3f);

        controller.center = Vector3.zero;
        controller.height = 2;
        animator.SetBool("isSliding", false);
        isSliding = false;
    }*/
}

