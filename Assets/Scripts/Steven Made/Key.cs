using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Composition.Hosting;
using UnityEngine;


public class Key : MonoBehaviour
{
    [SerializeField] private State state;
    private GameObject player;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float HoverSpeed = 2f;
    [SerializeField] private float HoverHeight = 2f;
    

    
    Vector3 MidPoint;    
    // Start is called before the first frame update
    void Start()
    {
        state = State.NOT_FOUND;
        MidPoint = transform.position + Vector3.up * HoverHeight/2;
    }

    // Update is called once per frame
    void Update()
    {
        if (state == State.FOUND)
        {
            // Calculate displacement vector
            Vector3 ds = player.transform.position - transform.position;
            // Add force in that direction 
            rb.AddForce(ds * Time.deltaTime);
        }
        else
        {
            // Animation
            transform.position = MidPoint + (Mathf.Sin(HoverSpeed * Time.time) * HoverHeight * Vector3.up);
        }
    }


    void OnTriggerEnter2D(Collider2D CollidedWith)
    {
        if (CollidedWith.CompareTag("Player"))
        {
            // Change state
            state = State.FOUND;
            // Get reference to player
            player = CollidedWith.gameObject;
        }
    }
    
}

public enum State 
{
    FOUND,
    NOT_FOUND,
}
