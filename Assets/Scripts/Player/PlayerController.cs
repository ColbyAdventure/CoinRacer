using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 direction;
    public float forwardSpeed;
    public float maxSpeed;

    private int desiredLane = 1;//0:left, 1:middle, 2:right
    public float laneDistance = 2.5f;//The distance between two lanes

    public bool isGrounded;
    public LayerMask groundLayer;
    public Transform groundCheck;

    public float jumpForce;
    public float Gravity = -20;

    public Animator animator;
    private bool isSliding = false;


    //****
    public bool isRotateRight = true;
    //^^**

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        //Check To See If The Game Is Running
        if (!LevelManager.isGameStarted)
            return;

        //Increase Speed 
        if(forwardSpeed < maxSpeed)
            forwardSpeed += 0.1f * Time.deltaTime;

        //****

        //print("forwardSpeed: " + forwardSpeed);
        if (maxSpeed < (CollectableManager.numberOfGems / 2))
        {
            maxSpeed = (CollectableManager.numberOfGems / 2);
        }
        //If there was no cap on the maxSpeed, it would be 15 at around 30 Gems
        //And 30 at sixty Gems. The above setup caps bad players at 15, and increases from 8 slow enough player adjusts quick, and on the second play, it feels "Too Slow"
        //^^**

        //print("MaxSpeed: " + maxSpeed);

        //Set Animator To True
        animator.SetBool("isGameStarted", true);

        //Set The Forward Vector To Forward Speed Float
        direction.z = forwardSpeed;


        //Do Grounded Check And Set Animator Bool
        isGrounded = Physics.CheckSphere(groundCheck.position, 0.15f, groundLayer);
        animator.SetBool("isGrounded", isGrounded);


        //Check If Jumping or Sliding (Cuz They Care About Gravity 
        if (isGrounded)
        {
            direction.y = -2;
            if (SwipeManager.swipeUp || Input.GetKeyDown(KeyCode.UpArrow))
                Jump();

            if ((SwipeManager.swipeDown || Input.GetKeyDown(KeyCode.DownArrow)) && !isSliding)
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
        if (SwipeManager.swipeRight || Input.GetKeyDown(KeyCode.RightArrow))
        {
            desiredLane++;
            if (desiredLane == 3)
                desiredLane = 2;
        }
        if (SwipeManager.swipeLeft || Input.GetKeyDown(KeyCode.LeftArrow))
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
        if (transform.position != targetPosition)
        {
            Vector3 diff = targetPosition - transform.position;
            Vector3 moveDir = diff.normalized * 25 * Time.deltaTime;
            if (moveDir.sqrMagnitude < diff.magnitude)
                controller.Move(moveDir);
            else
                controller.Move(diff);
        }
         


        PlayerMove();
    }

    private void PlayerMove()
    {
        if (!LevelManager.isGameStarted)
            return;
        controller.Move(direction * Time.deltaTime);
    }

    private void Jump()
    {
        direction.y = jumpForce;

        //****
        FlipIsRotatingRight();


        FindObjectOfType<AudioManager>().PlaySound("Jump");
        //^^**
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(hit.transform.tag == "Obstacle")
        {
            LevelManager.isGameOver = true;
            FindObjectOfType<AudioManager>().PlaySound("GameOver");
            FindObjectOfType<AudioManager>().PlaySound("Fail");
        }
    }

    private IEnumerator Slide()
    {
        isSliding = true;
        animator.SetBool("isSliding", true);
        controller.center = new Vector3(0, -0.5f, 0);
        controller.height = 1;

        //****
        FindObjectOfType<AudioManager>().PlaySound("Skidding");
        //^^**




        yield return new WaitForSeconds(1.3f);

        controller.center = Vector3.zero;
        controller.height = 2;
        animator.SetBool("isSliding", false);
        isSliding = false;

        //****
        FlipIsRotatingRight();
        //^^**
    }

    private void FlipIsRotatingRight()
    {
        //****
        isRotateRight = !isRotateRight;
        animator.SetBool("isRotateRight", isRotateRight);
        //^^**
    }
}

/*using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 direction;
    public float forwardSpeed;
    public float maxSpeed;


    //**For Left Right Movement
    private int desiredLane = 1;//0:left, 1:middle, 2:right
    public float laneDistance = 2.5f;//The distance between two lanes
    //^^For Left Right Movement


    //**For Jumping
    public bool isGrounded;
    public LayerMask groundLayer;
    public Transform groundCheck;

    public float jumpForce;
    public float Gravity = -20;
    //^^**For Jumping

    public Animator animator;
    private bool isSliding = false;


    //****
    public bool isRotateRight = true;
    //^^**

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        //Check To See If The Game Is Running
        if (!LevelManager.isGameStarted)
        {
            return;
        }
        //^^Replaces Above
        //IsGameStartedCheck();

        //Increase Speed 
        if (forwardSpeed < maxSpeed)
            forwardSpeed += 0.1f * Time.deltaTime;
        //Set The Forward Vector To Forward Speed Float
        direction.z = forwardSpeed;
        //^^Replaces Above
        //IncreaseCurrentSpeed();

        print("forwardSpeed: " + forwardSpeed);




        //Set Animator To True
        animator.SetBool("isGameStarted", true);
        //^^Replaces Above
        //SetIsStartedAnimationBool();


        //Do Grounded Check And Set Animator Bool
        isGrounded = Physics.CheckSphere(groundCheck.position, 0.15f, groundLayer);
        animator.SetBool("isGrounded", isGrounded);
        //^^Replaces Above
        //DoGroundedCheck();

        //Check If Jumping or Sliding (Cuz They Care About Gravity) 
        if (isGrounded)
        {
            direction.y = -2;
            if (SwipeManager.swipeUp || Input.GetKeyDown(KeyCode.UpArrow))
                Jump();

            if ((SwipeManager.swipeDown || Input.GetKeyDown(KeyCode.DownArrow)) && !isSliding)
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
        //^^Replaces Above
        //CheckInputResultsBasedOnGroundedCheck();

        //Gather the inputs on which lane we should be
        if (SwipeManager.swipeRight || Input.GetKeyDown(KeyCode.RightArrow))
        {
            desiredLane++;
            if (desiredLane == 3)
                desiredLane = 2;
        }
        if (SwipeManager.swipeLeft || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            desiredLane--;
            if (desiredLane == -1)
                desiredLane = 0;
        }
        //^^Replaces Above
        //CheckForDesiredLane();






        //Calculate where we should be in the future
        Vector3 targetPosition = transform.position.z * transform.forward + transform.position.y * transform.up;
        if (desiredLane == 0)
            targetPosition += Vector3.left * laneDistance;
        else if (desiredLane == 2)
            targetPosition += Vector3.right * laneDistance;
        //^^Replaces Above
       // SetTheDesiredLane();


        transform.position = targetPosition;
        if (transform.position == targetPosition)
            return;
        Vector3 diff = targetPosition - transform.position;
        Vector3 moveDir = diff.normalized * 25 * Time.deltaTime;
        if (moveDir.sqrMagnitude < diff.magnitude)
            controller.Move(moveDir);
        else
            controller.Move(diff);
        //Replaces Above
        //MoveToDesiredLane();


    }


    private void IsGameStartedCheck()
    {
        if (!LevelManager.isGameStarted)
        {
            return;
        }
    }

    private void IncreaseCurrentSpeed()
    {
        if (forwardSpeed < maxSpeed)
        {
            forwardSpeed += 0.1f * Time.deltaTime;
        }
        direction.z = forwardSpeed;
    }

    private void SetIsStartedAnimationBool()
    {
        animator.SetBool("isGameStarted", true);
    }


    private void DoGroundedCheck()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, 0.15f, groundLayer);
        animator.SetBool("isGrounded", isGrounded);
    }

    private void CheckInputResultsBasedOnGroundedCheck()
    {
        //Check If Jumping or Sliding (Cuz They Care About Gravity) 
        if (isGrounded)
        {
            direction.y = -2;
            if (SwipeManager.swipeUp || Input.GetKeyDown(KeyCode.UpArrow))
                Jump();

            if ((SwipeManager.swipeDown || Input.GetKeyDown(KeyCode.DownArrow)) && !isSliding)
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

    }

    private void CheckForDesiredLane()
    {
        if (SwipeManager.swipeRight || Input.GetKeyDown(KeyCode.RightArrow))
        {
            desiredLane++;
            if (desiredLane == 3)
                desiredLane = 2;
        }
        if (SwipeManager.swipeLeft || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            desiredLane--;
            if (desiredLane == -1)
                desiredLane = 0;
        }
    }

    private void SetTheDesiredLane()
    {
        //Vector3 targetPosition = transform.position.z * transform.forward + transform.position.y * transform.up;
        //if (desiredLane == 0)
        //    targetPosition += Vector3.left * laneDistance;
        //else if (desiredLane == 2)
        //    targetPosition += Vector3.right * laneDistance;

    }

    private void MoveToDesiredLane()
    {

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

        //****
        FlipIsRotatingRight();


        FindObjectOfType<AudioManager>().PlaySound("Jump");
        //^^**
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(hit.transform.tag == "Obstacle")
        {
            LevelManager.isGameOver = true;
            FindObjectOfType<AudioManager>().PlaySound("GameOver");
            FindObjectOfType<AudioManager>().PlaySound("Fail");
        }
    }

    private IEnumerator Slide()
    {
        //****
        FindObjectOfType<AudioManager>().PlaySound("Skidding");
        //^^**
        isSliding = true;
        animator.SetBool("isSliding", true);
        controller.center = new Vector3(0, -0.5f, 0);
        controller.height = 1;






        yield return new WaitForSeconds(1.3f);

        controller.center = Vector3.zero;
        controller.height = 2;
        animator.SetBool("isSliding", false);
        isSliding = false;

        //****
        FlipIsRotatingRight();
        //^^**
    }

    private void FlipIsRotatingRight()
    {
        //****
        isRotateRight = !isRotateRight;
        animator.SetBool("isRotateRight", isRotateRight);
        //^^**
    }
}*/
