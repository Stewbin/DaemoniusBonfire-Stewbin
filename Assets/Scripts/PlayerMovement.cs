using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : Movement
{
    [SerializeField]
    private float coyoteTime = 0.05f;
    float ctTime = coyoteTime;
    private float jumpBuffer;
    float  = jumpBuffer;
    void Update()
    {	
        // Coyote Time Code
        if (isGrounded) // Can jump without being grounded, if within coyote time
        {
            ctTime = coyoteTime; 
        }
        else
        {
            ctTime -= Time.deltaTime;
        }
        
        // Jump Buffering Code 
        if (Input.GetKey(KeyCode.Space)) 
        {
            jbTime = jumpBuffer;
        }
        else // If not jumping
        {
            jbTime -= Time.deltaTime; // Can press space again after at least 'jumpBuffer' seconds
        }
        
        
         //this handles the jump animation
        Vector2 e = GetComponent<Rigidbody2D>().velocity; //RB velocity
        if (!isJumping)
        {
            isGrounded = (int)e.y > -1; //if jumping. is grounded is set by a collison or if the jump is complete	
        }
        
        
        animator.SetBool("isJumping", isJumping || (int)e.y < -1); // is Jumping or is Falling

        rb = GetComponent<Rigidbody2D>();

        animator.SetFloat("walk", Mathf.Abs(Input.GetAxisRaw("Horizontal") * 1)); //I couldnt help myself T~T
        targetVelocity = Input.GetAxisRaw("Horizontal") * speedX;

        Vector2 playerLocation = GetComponent<Transform>().position;
        rb.velocity = new Vector2(targetVelocity, rb.velocity.y);
        if (Input.GetAxisRaw("Horizontal") == -1)
        {
            GetComponent<SpriteRenderer>().flipX = true;    //flips the X so you can get forward and backwards
        }
        if (Input.GetAxisRaw("Horizontal") == 1)
        {
            GetComponent<SpriteRenderer>().flipX = false;    //flips the X so you can get forward and backwards
        }

        if (jbTime > 0) // Big Jump
        {
            if (isJumping && time > 30)
            {

                Vector2 v = GetComponent<Rigidbody2D>().velocity;
                v.y -= speedY;
                jumpState = 2;
                GetComponent<Rigidbody2D>().velocity = v;
            }

        } // Small jump
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!isJumping && ctTime > 0)
            {
                jumpState = 1;
                isJumping = true;
                isGrounded = false;
            }
        }
        if (jbTime > 0) //jump
        {
            if (isJumping)
            {

                if (timePerJump < 400)
                {
                    timePerJump += 4;
                    timePerJump += timePerJump * Time.deltaTime;
                }
            }
        }
        if (isJumping)
        {
            HandleJump(timePerJump, playerLocation);
        }

       // For falling animation
        animator.SetFloat("Y_velocity", rb.velocity.y);


        // Dash code
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            animator.SetBool("dash", true);
            Dash = true;

        }
        if (Dash)
        {
            HandleDash(20, playerLocation);
        }

        
    }
}
