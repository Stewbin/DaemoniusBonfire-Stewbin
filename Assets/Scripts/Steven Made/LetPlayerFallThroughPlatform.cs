using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class LetPlayerFallThroughPlatform : MonoBehaviour
{
    [SerializeField]
    private PlatformEffector2D effector;
    public float WaitTime = 0.1f;
    float waitTimer;
    //private Animator animator;    
    private GameObject Player;
    private bool IsFalling;
    
    // Start is called before the first frame update
    void Start()
    {
        effector = GetComponent<PlatformEffector2D>();
        //animator = GetComponent<Animator>();
        // The idea was to use the player's animation state to detect falling
        
        // Get reference to player in scene
        Player = GameObject.Find("MainCharacter");
        // Get movement script
        IsFalling = Player.GetComponent<BetterJumps>().falling;
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

        if(Input.GetKeyUp(KeyCode.S) && !IsFalling)
        {
            effector.rotationalOffset = 0; // Reset platform detection after release S
            waitTimer = WaitTime; // Reset counter 
        }

    }
}