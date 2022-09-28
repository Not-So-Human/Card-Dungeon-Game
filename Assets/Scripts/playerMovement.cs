using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    Rigidbody2D rb;

    public float walkSpeed = .3f;
    public float speedLimiter = .7f;
    float inputHorizontal;
    float inputVertical;

    //Animations and states
    Animator animator;
    string currentState;
    const string PLAYER_IDLE = "Player_Idle";
    const string PLAYER_WALK_LEFT_DOWN = "Player_Walk_Left_Down";
    const string PLAYER_WALK_LEFT = "Player_Walk_Left";
    const string PLAYER_WALK_LEFT_UP = "Player_Walk_Left_Up";
    const string PLAYER_WALK_UP = "Player_Walk_Up";
    const string PLAYER_WALK_RIGHT_UP = "Player_Walk_Right_Up";
    const string PLAYER_WALK_RIGHT = "Player_Walk_Right";
    const string PLAYER_WALK_RIGHT_DOWN = "Player_Walk_Right_Down";
    const string PLAYER_WALK_DOWN = "Player_Walk_Down";


    //this is to change the walk speed to the dash speed
    public float activeMoveSpeed;
    public float dashSpeed = 4f;
    //these are self explanitory
    public float dashLength = .2f, dashCooldown = 3.5f;
    //these are use to make it so you cant spam the dash
    public float dashCounter;
    public float dashCoolCounter;
    // Start is called before the first frame update
    void Start()
    {
        activeMoveSpeed = walkSpeed;
        rb = gameObject.GetComponent<Rigidbody2D>();

        animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // W & S key inputs
        inputHorizontal = Input.GetAxisRaw("Horizontal");
        // A & D key inputs
        inputVertical = Input.GetAxisRaw("Vertical");

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (dashCoolCounter <= 0 && dashCounter <= 0)
            {
                activeMoveSpeed *= dashSpeed;
                dashCounter = dashLength;
            }
        }

        if (dashCounter > 0)
        {
            dashCounter -= Time.deltaTime;

            if (dashCounter <= 0)
            {
                activeMoveSpeed = walkSpeed;
                dashCoolCounter = dashCooldown;
            }
        }

        if (dashCoolCounter > 0)
        {
            dashCoolCounter -= Time.deltaTime;
        }
    }

    void FixedUpdate()
    {
        // Makes sure the speed you move diagonally is controlled
        if (inputHorizontal != 0 || inputVertical != 0)
        {
            if (inputHorizontal != 0 && inputVertical != 0)
            {
                inputHorizontal *= speedLimiter;
                inputVertical *= speedLimiter;
            }

            rb.velocity = new Vector2(inputHorizontal * activeMoveSpeed, inputVertical * activeMoveSpeed);


            if (inputHorizontal > 0 && inputVertical > 0)

            {
                ChangeAnimationState(PLAYER_WALK_RIGHT_UP);
            }
            else if (inputHorizontal < 0 && inputVertical > 0)
            {
                ChangeAnimationState(PLAYER_WALK_LEFT_UP);
            }
            else if (inputHorizontal > 0 && inputVertical < 0)
            {
                ChangeAnimationState(PLAYER_WALK_RIGHT_DOWN);
            }
            else if (inputHorizontal < 0 && inputVertical < 0)
            {
                ChangeAnimationState(PLAYER_WALK_LEFT_DOWN);
            }
            else if (inputHorizontal < 0)
            {
                ChangeAnimationState(PLAYER_WALK_LEFT);
            }
            else if (inputVertical > 0)
            {
                ChangeAnimationState(PLAYER_WALK_UP);
            }
            else if (inputVertical < 0)
            {
                ChangeAnimationState(PLAYER_WALK_DOWN);
            }
            else if (inputHorizontal > 0)
            {
                ChangeAnimationState(PLAYER_WALK_RIGHT);
            }
        }
        else
        {
            rb.velocity = new Vector2(0f, 0f);
            ChangeAnimationState(PLAYER_IDLE);
        }
        //animation state changer
        void ChangeAnimationState(string newState)
        {
            //Stop animation from interrupting itself
            if (currentState == newState) return;

            //play new animation
            animator.Play(newState);



            //Update current state
            currentState = newState;
        }
    }
}