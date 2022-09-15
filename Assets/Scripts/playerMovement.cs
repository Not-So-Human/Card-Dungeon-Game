using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    Rigidbody2D rb;

    public float walkSpeed = 4f;
    public float speedLimiter = .7f;
    float inputHorizontal;
    float inputVertical;
    //this is to change the walk speed to the dash speed
    public float activeMoveSpeed;
    public float dashSpeed = 5f;
    //these are self explanitory
    public float dashLength = .7f, dashCooldown = 3.5f;
    //these are use to make it so you cant spam the dash
    public float dashCounter;
    public float dashCoolCounter;
    // Start is called before the first frame update
    void Start()
    {
        activeMoveSpeed = walkSpeed;
        rb = gameObject.GetComponent<Rigidbody2D>();
       
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

        if(dashCoolCounter > 0)
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
        }
        else
        // Make sures there is no input so it stops the character from moving
            rb.velocity = new Vector2(0f, 0f);
    }
    
}