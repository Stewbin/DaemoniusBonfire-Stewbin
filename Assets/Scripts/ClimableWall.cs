using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimableWall : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rb;

    public bool CanClimb;
    public bool Climb;
    public float climbVelocity;
    public float speed = 8.0f;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            climbVelocity = 1;
            Climb = true;

        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            climbVelocity = 0;
            Climb = false;
            rb.gravityScale = 1.0f;
            rb.velocity = new Vector2(rb.velocity.x, 0);

        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            climbVelocity = -1;
            Climb = true;

        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            climbVelocity = 0;
            Climb = false;
            rb.gravityScale = 1.0f;
            rb.velocity = new Vector2(rb.velocity.x, 0);
        }
    }
    void FixedUpdate()
    {
        if (CanClimb)
        {
            if (Climb)
            {
                rb.gravityScale = 0;
                rb.velocity = new Vector2(rb.velocity.x, climbVelocity * speed);
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Debug.Log(other.gameObject.tag);

        if (other.CompareTag("climeBeam"))
        {
            CanClimb = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("climeBeam"))
        {
            CanClimb = false;
        }
    }
}
