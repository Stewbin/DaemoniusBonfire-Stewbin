using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

// X
public class PlayerMovement : Movement
{
	[SerializeField]
	private float coyoteTime = 1f;
	public float ctTime;
	public float jumpBuffer = 5f;
	public float jbTime; 
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

		if (jbTime > 0 && ctTime > 0) // Big Jump
		{
			if (isJumping && time > 300)
			{
				Vector2 v = GetComponent<Rigidbody2D>().velocity;
				v.y -= speedY;
				jumpState = 2;
				GetComponent<Rigidbody2D>().velocity = v;

				// End 'grace period' jumps (may or may not be early), so player can't double jump
				jbTime = 0f;
				ctTime = 0f; 
			}
			
		}

		// Small jump
		if (Input.GetKeyDown(KeyCode.Space))
		{
			if (!isJumping)
			{
				jumpState = 1;
				isJumping = true;
				isGrounded = false;
				
				// End 'grace period' jumps (may or may not be early), so player can't double jump
				jbTime = 0f;
				ctTime = 0f;
			}
		}
		
		// Time statistics
		if (Input.GetKey(KeyCode.Space)) //jump
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
