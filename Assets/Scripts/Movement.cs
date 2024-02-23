using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// X next week...
public class Movement : MonoBehaviour
{
	[SerializeField]
	private Vector2 velocity; //players x, y velocity
	public float speedX = 10;
	public float speedY = 8;
	public Rigidbody2D rb;
	public bool isGrounded; //is grounded
	public bool isJumping; // isJumping
	public float time = 1; //time of jump (in frames 1 jump = 60 frames)
	public float DashTime = 1;
	public bool Dash = false;
	public float timePerJump; //this is the time per a jump. out of 60
	public int jumpState = 1;
	public Animator animator;
	public float targetVelocity;
	
	public void HandleDash(float estimateFrames, Vector2 playerLocation)
	{
		if (DashTime > estimateFrames) //change to the falling state
		{
			animator.SetBool("dash", false);
			DashTime = 0;
			Dash = false;
			return;
		}
		if (!GetComponent<SpriteRenderer>().flipX)
		{
			rb.velocity = new Vector2(speedX* 10, rb.velocity.y);

		}
		else
		{
			rb.velocity = new Vector2(speedX* -10, rb.velocity.y);

		}
		GetComponent<Transform>().position = playerLocation;
		DashTime++;

	}
	
	/// <summary>
	/// handles the jump of the player
	/// uses state machine. 
	/// 1st state is jumping 2nd state is falling. 
	/// we can add a 3rd state so it can make the jumps more like a "Sine wave" rather than sharp. 
	/// </summary>
	/// <param name="estimateFrames"> estimated time of the Jump. either 60 </param>
	/// <param name="playerLocation"></param> location of the player<summary>	
	public void HandleJump(float estimateFrames, Vector2 playerLocation)
	{
		Vector2 v = GetComponent<Rigidbody2D>().velocity; //RB velocity

		if (jumpState == 1)
		{
			if ((int)estimateFrames > 1)
			{

				if (time > (int)estimateFrames / 2) //change to the falling state
				{
					jumpState = 2; //commit from neo-vim
					return;
				}
			}
			//jumping
			playerLocation.y += speedY * Time.deltaTime;
			v.y += speedY * Time.deltaTime;
			GetComponent<Transform>().position = playerLocation;
			GetComponent<Rigidbody2D>().velocity = v;
		}
		else if (jumpState == 2)
		{
			//falling
			playerLocation.y -= speedY * Time.deltaTime;

			v.y = (speedY - v.y) * Time.deltaTime;  //velocity*time + ((G * time^2)/2) good formula for jumps
			GetComponent<Rigidbody2D>().velocity = v;
			GetComponent<Transform>().position = playerLocation;
		}
		
		//this makes sure its valid
		if (time > estimateFrames && isGrounded)
		{
			ResetJumps();
			return;
		}



		time += 1;
		time += time * Time.deltaTime;
	}
	/// <summary>
	/// resets jump states.
	/// </summary>

	public void ResetJumps()
	{
		isJumping = false;
		time = 1;
		jumpState = 1;
		timePerJump = 1;
	}


	private void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.tag == "floor")
		{
			//calculates angle so you only get it iff its on the floor
			Vector3 hit = other.contacts[0].normal;
			float angle = Vector3.Angle(hit, Vector3.up);
			if (Mathf.Approximately(angle, 0))  //if floor collsion
			{
				ResetJumps();
				isGrounded = true;
				animator.SetBool("isJumping", isJumping);
			}
			/*
			else if (Mathf.Approximately(angle, 180) || Mathf.Approximately(angle, 90))  //if roof collison
			{
				//Up
				if (isJumping)
				{
					jumpState = 2; //modify to falling state if jumping active

				}
			}
			*/
		}
	}

}
