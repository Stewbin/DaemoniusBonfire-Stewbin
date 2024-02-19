using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.Contracts;
using System.IO.Enumeration;
using System.Runtime.ConstrainedExecution;
using UnityEngine;

public class StevenJump : MonoBehaviour 
{
    [SerializeField]
    private float PeakHeight;
    private float DistanceToPeak;
    private float velocity_x = 10f;
    public Rigidbody2D rb;
    
    private float BigJumpTime = 10f;
    private float jumpTime = BigJumpTime;
   
    private boolean FacingRight = true;
    
    
    // Calculate the constants 
    float velocity_y = 2 * MaxHeight * velocity_x / DistanceToPeak; // Initial y-velocity
    const float gravity = -2 * MaxHeight * Math.Pow(velocity_x, 2) / Math.Pow(DistanceToPeak, 2); // Gravity, duh
    float 
    
        

    void Update()
    {
        // Horizontal movement
        int direction = Input.GetAxisRaw; 
        // rb.velocity = direction * velocity_x; 
        
        // Increment x position method
        Vector3 targetPosition = transform.position + Vector3.right * direction * velocity_x * Time.deltaTime;
        transform.position = targetPosition;

        if (direction == -1 && FacingRight)
        {
            flip();
        }
        else if (direction == 1 && !FacingRight)
        {
            flip();
        }
       
       // Vertical movement
        //float new_gravtiy = 
        
        
        // Timed Jumps
        if (Input.GetKey(KeyCode.Space))
        {
            jumpTime -= Time.deltaTime;
        }

        if(Input.GetKeyUp)
        {
            if (jumpTime < 0)
            {
                gravity *= 3;
            }
            jumpTime = BigJumpTime;
        }

    }

    void flip() // flips the x scale of sprite
    {
        FacingRight = !FacingRight;
        transform.scale = Vector3(transform.scale.x, 1, 1);
    }
    
    float calclateGravity(float pos);
    {
        return -2 * MaxHeight * Math.Pow(velocity_x, 2) / Math.Pow(DistanceToPeak, 2);
    }
}