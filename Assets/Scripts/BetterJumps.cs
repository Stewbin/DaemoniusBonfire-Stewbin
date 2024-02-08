using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BetterJumps : MonoBehaviour
{
	// Start is called before the first frame update
	private Rigidbody2D rb;
	public float velocityY;
	public Vector2 velocity;
	private float targetVelocity;
	public float jumpTime;
	public bool isJumping;
	public bool isGrounded = false;
	public bool isDashing = false;
	public Animator animator;
	bool falling = false;
	public float jumpSpeed;
	public float fallSpeed;
	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
	}


	// Update is called once per frame
	void Update()
	{
		// animator.SetBool("isJumping", isJumping || !isGrounded); // is Jumping or is Falling
		// animator.SetFloat("walk", Mathf.Abs(rb.velocity.x)); //I couldnt help myself T~T

		rb = GetComponent<Rigidbody2D>();
		CalcTargetVelocity();
		if (Input.GetKey(KeyCode.S))
		{
			falling = true;
		}
		if (Input.GetKey(KeyCode.X))
		{
			HandleDash();
		}
		if (Input.GetKeyDown(KeyCode.Space))
		{
			if (isGrounded && !isJumping)
			{
				isJumping = true;
				falling = false;
				jumpTime = 0.0f;
			}
			if (isJumping)
			{
				float jumpForce = Mathf.Sqrt(jumpSpeed * -2 * (Physics2D.gravity.y * rb.gravityScale));
				rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
			}
		}
		if (Input.GetKey(KeyCode.Space))
		{
			if (isJumping)
				HandleJump();
		}
		if (Input.GetKeyUp(KeyCode.Space))
		{
			isJumping = false;
			falling = true;
			jumpTime = 0.0f;
		}


	}
	private void FixedUpdate()
	{
		// rb.AddForce();
		if (falling || rb.velocity.y < 0) //this makes object heavy ;3
		{
			rb.AddForce(Vector2.down * fallSpeed);
		}
	}
	public void HandleJump()
	{

		if (jumpTime > 2.5)
		{
			isJumping = false;
			falling = true;
			return;
		}
		jumpTime += Time.deltaTime;

	}
	public void HandleDash()
	{
		isDashing = true;
		if (GetComponent<SpriteRenderer>().flipX)
			rb.velocity = new Vector2((velocity.x + 1) * -15, rb.velocity.y);
		else
			rb.velocity = new Vector2((velocity.x + 1) * 15, rb.velocity.y);

	}
	public void CalcTargetVelocity()
	{

		targetVelocity = 8.0f * Input.GetAxisRaw("Horizontal");
		rb.velocity = new Vector2(targetVelocity, rb.velocity.y);
		if (targetVelocity > 1) GetComponent<SpriteRenderer>().flipX = false;
		if (targetVelocity < -1) GetComponent<SpriteRenderer>().flipX = true;
		// GetComponent<SpriteRenderer>().flipX = targetVelocity > 0;

	}
	private void OnCollisionStay2D(Collision2D other)
	{
		if (other.gameObject.tag == "floor")
			isGrounded = true;

	}
	private void OnCollisionEnter2D(Collision2D other)
	{
		if (isJumping)
		{
			Debug.Log("test");
			isJumping = false;
		}
	}
	private void OnCollisionExit2D(Collision2D other)
	{
		if (other.gameObject.tag == "floor") //use a hashmap of values that are like a ground (or create ground layer)
			isGrounded = false;
	}

}
