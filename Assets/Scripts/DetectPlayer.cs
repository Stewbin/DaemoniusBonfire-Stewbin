using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class DetectPlayer : MonoBehaviour
{
    [SerializeField]
    private PlatformEffector2D effector;
    public float WaitTime = 0.2f;
    float waitTimer;
    private Animator animator;    
    
    // Start is called before the first frame update
    void Start()
    {
        effector = GetComponent<PlatformEffector2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
       // If player holding down, 
        if(Input.GetKey(KeyCode.S)) // Don't know if better to use GetKey or GetAxisRaw
        {
            if(waitTimer <= 0) // after 0.5s, 
            {
                effector.rotationalOffset = 180; // collision detection flips direction
            } 
            else
            { 
                waitTimer -= Time.deltaTime; // start counting down
            }
        } 

        if(Input.GetKeyUp(KeyCode.S) && !animator.GetCurrentAnimatorStateInfo(0).IsName("Midair Idle"))
        {
            effector.rotationalOffset = 0; // Reset platform detection after release S
            waitTimer = WaitTime; // Reset counter 
        }

    }
}