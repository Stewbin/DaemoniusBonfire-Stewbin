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
	public bool falling = false;
	public float jumpSpeed;
	bool dashing = false;
	public float walkSpeed;
	public float fallSpeed;
	private float accel = 0.5f;
	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
	}


	// Update is called once per frame
	void Update()
	{
		if (dashing) return;
		animator.SetBool("isJumping", isJumping || !isGrounded);
		animator.SetFloat("walk", Mathf.Abs(Input.GetAxisRaw("Horizontal")));

		rb = GetComponent<Rigidbody2D>();
		CalcTargetVelocity(Input.GetAxisRaw("Horizontal"));
		if (Input.GetKey(KeyCode.S))
		{
			falling = true;
		}
		if (Input.GetKeyDown(KeyCode.Space))
		{
			SetJump();
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
		if (Input.GetKeyDown(KeyCode.X))
		{
			if (!dashing)
				StartCoroutine(Dash());

		}


	}
	private void FixedUpdate()
	{
		// rb.AddForce();
		// if (isGrounded)
		// 	falling = false;
		if (dashing) return;
		if (falling || rb.velocity.y < 0) //this makes object heavy ;3
		{

			rb.AddForce(Vector2.down * fallSpeed);
		}
	}
	public IEnumerator Dash()
	{
		float ogGrav = rb.gravityScale;
		rb.gravityScale = 0f;
		if (GetComponent<SpriteRenderer>().flipX)
			rb.velocity = new Vector2(transform.localScale.x * -250.0f, rb.velocity.y);
		else
			rb.velocity = new Vector2(transform.localScale.x * 250.0f, rb.velocity.y);
		dashing = true;
		yield return new WaitForSeconds(0.25f);
		rb.velocity = Vector2.zero;
		rb.gravityScale = ogGrav;
		dashing = false;

	}
	public void SetJump()
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
	public void HandleJump()
	{

		if (jumpTime >= 2.5)
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
	public void CalcTargetVelocity(float inputVelocity)
	{
		if (targetVelocity > 1) GetComponent<SpriteRenderer>().flipX = false;
		if (targetVelocity < -1) GetComponent<SpriteRenderer>().flipX = true;
		if (inputVelocity != 0)
		{
			if (accel < 8.0f)
			{
				accel += walkSpeed * Time.deltaTime;
			}

		}
		else
		{
			accel = 0.5f;
		}
		targetVelocity = accel * inputVelocity;
		rb.velocity = new Vector2(targetVelocity, rb.velocity.y);
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
			isJumping = false;
		}
	}
	private void OnCollisionExit2D(Collision2D other)
	{
		if (other.gameObject.tag == "floor") //use a hashmap of values that are like a ground (or create ground layer)
			isGrounded = false;
	}

}
