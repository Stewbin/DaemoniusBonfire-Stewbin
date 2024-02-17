using System.Collections;
using System.Collections.Generic;
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
    
    

    void Start()
    {
        float velocity_y = 2 * MaxHeight * velocity_x / DistanceToPeak;
        float gravity = -2 * MaxHeight * Math.Pow(velocity_x, 2) / Math.Pow(DistanceToPeak);
    }

    void Update()
    {
        // Horizontal movement
        int direction = Input.GetAxisRaw; 
        // rb.velocity = direction * velocity_x; 
        
        // Increment x position method
        Vector3 targetPosition = transform.position + Vector3(direction * velocity_x * Time.deltaTime, 0, 0);
        transform.position = targetPosition;

        // Vertical movement
        //float new_gravtiy = 

        if (direction == -1 && FacingRight)
        {
            flip();
        }
        else if (direction == 1 && !FacingRight)
        {
            flip();
        }

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
}