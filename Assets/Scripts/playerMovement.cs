using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    Rigidbody2D rb;

    public float walkSpeed = 5f;
    public float speedLimiter = .7f;
    float inputHorizontal;
    float inputVertical;

    //Animations and states
    Animator animator;
    string currentState;
    const string PLAYER_IDLE = "Player_Idle";
    const string PLAYER_WALK_LEFT_DOWN = "Player_WalkLeft_Down";
    const string PLAYER_WALK_LEFT = "Player_WalkLeft";
    const string PLAYER_WALK_LEFT_UP = "Player_WalkLeft_Up";
    const string PLAYER_WALK_UP = "Player_WalkUp";
    const string PLAYER_WALK_RIGHT_UP = "Player_WalkRight_Up";
    const string PLAYER_WALK_RIGHT = "Player_WalkRight";
    const string PLAYER_WALK_RIGHT_DOWN = "Player_WalkRight_Down";
    const string PLAYER_WALK_DOWN = "Player_WalkDown";

    //this is to change the walk speed to the dash speed
    public float activeMoveSpeed;
    public float dashSpeed = 5f;
    //these are self explanitory
    public float dashLength = .6f, dashCooldown = 3.5f;
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
           
       
            if (inputHorizontal > 0)
            {
                ChangeAnimationState(PLAYER_WALK_RIGHT);
            }
            else if (inputHorizontal > 0 && inputVertical > 0)
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