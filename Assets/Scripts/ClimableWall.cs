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
            // Vector3 hit = other.contacts[0].normal;
            // float angle = Vector3.Angle(hit, Vector3.up);
            // // Debug.Log(angle);
            // if (Mathf.Approximately(angle, 90) && Input.GetKey(KeyCode.F))
            // {

            //     rb.velocity = new Vector2(rb.velocity.x, 5.0f);
            //     if (Input.GetKey(KeyCode.RightShift))
            //         rb.velocity = new Vector2(rb.velocity.x, 0.0f);
            //     // Debug.Log("can climb");
            // }

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
