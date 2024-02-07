using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : MonoBehaviour
{
    [SerializeField] public float spiderSpeed;
    [SerializeField] public GameObject spider;
    [SerializeField] public Rigidbody2D spiderBody;


    void Start()
    {
        spiderBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {

        void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                print("Working"); 
            }
        }

        SpiderPatrolling(); 
        
    }

    public void SpiderPatrolling()
    {
        spiderSpeed = -2.0f; 
        spiderBody.velocity = new Vector2 (spiderSpeed, spiderBody.velocity.y);
    }

    
}
