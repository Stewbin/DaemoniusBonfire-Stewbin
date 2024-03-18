using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{

    public Rigidbody2D rb;
    public float time = 0;
    void FixedUpdate()
    {
        rb = GetComponent<Rigidbody2D>();
        if (time > 1.0f)
        {
            rb.constraints = ~RigidbodyConstraints2D.FreezePositionY;
            rb.velocity = Vector2.down;
            time = 0;
        }
    }

    private void OnCollisionStay2D(Collision2D other)
    {

        if (other.gameObject.tag == "Player")
        {

            time += Time.deltaTime;
        }
    }
    private void OnCollisionExit2D(Collision2D other)
    {
        time = 0;
    }
}
