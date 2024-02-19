using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.Contracts;
using System.IO.Enumeration;
using System.Numerics;
using System.Runtime.ConstrainedExecution;
using System.Security;
using UnityEngine;

public class StevenJump : MonoBehaviour 
{
    [SerializeField]
    private float PeakHeight;
    private float DistanceToPeak;
    private float VelocityX = 10f;
    public Rigidbody2D rb;
    
    private float BigJumpTime = 10f;
    private float jumpTime = BigJumpTime;
   
    private boolean FacingRight = true;
    
    
    // Calculate the constants 
    float VelocityY = 2 * MaxHeight * VelocityX / DistanceToPeak; // Initial y-velocity
    float GravityCur = -2 * MaxHeight * Math.Pow(VelocityX, 2) / Math.Pow(DistanceToPeak, 2); // Initial Gravity
    float GravityNew = GravityCur;
        

    void Update()
    {
        // Horizontal movement
        int direction = Input.GetAxisRaw; 
        // rb.velocity = direction * VelocityX; 
        
        // Increment x position method
        Vector3 TargetPositionX = transform.position + Vector3.right * direction * VelocityX * Time.deltaTime;
        transform.position = TargetPositionX;

        if (direction == -1 && FacingRight)
        {
            flip();
        }
        else if (direction == 1 && !FacingRight)
        {
            flip();
        }
       
        // Vertical movement


        // Timed Jumps
        if (Input.GetKey(KeyCode.Space))
        {
            jumpTime -= Time.deltaTime;
        }

        if(Input.GetKeyUp)
        {
            if (jumpTime < 0)
            {
                GravityNew = 3 * GravityCur;
            }
            jumpTime = BigJumpTime;
        }
        
        // pos += vel * Δt * (1/2)acc * Δt * Δt
        Vector3 TargetPositionY = Vector3.up * (VelocityY * Time.deltaTime) * 0.5(GravityCur * Time.deltaTime * Time.deltaTime);
        transform.position = transform.position + TargetPositionY;

        // vel += (acc + new_acc)/2 * Δt
        VelocityY += (GravityCur + GravityNew) * Time.deltaTime / 2;
        // acc = new_acc;
        GravityCur = GravityNew;
    }

    void flip() // flips the x scale of sprite
    {
        FacingRight = !FacingRight;
        transform.scale = Vector3(transform.scale.x, 1, 1);
    }
}