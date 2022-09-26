using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Animator animator;
    string currentState;
    const string ENEMY_LEFT = "Enemy_Left";
    const string ENEMY_RIGHT = "Enemy_Right";
    public float speed = 0.4f;
    public float Horizontal;
    Transform target;

    void Update()
    {
        if (target != null)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, target.position, step);
            Horizontal = Input.GetAxisRaw("Horizontal");
        }
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            target = other.transform;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            target = null;
        }
    }
    
    void FixedUpdate()
    {
        if (Horizontal > 0)
        {
            ChangeAnimationState(ENEMY_RIGHT);
        }
        if (Horizontal < 0)
        {
            ChangeAnimationState(ENEMY_LEFT);
        }
    }
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
