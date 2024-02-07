using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Spider : MonoBehaviour
{
    [SerializeField] public float spiderSpeed;
    [SerializeField] public GameObject spider;
    [SerializeField] public Rigidbody2D spiderBody;
    public GameObject pointA;
    public GameObject pointB;
    public Animator anim;
    public Transform currentPoint;


    void Start()
    {
        spiderBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        currentPoint = pointB.transform;
        anim.SetBool("isRunning", true);
    }

    void Update()
    {


        CheckCollision();  
         SpiderPatrolling(); 
        
    }

    public void SpiderPatrolling()
    {
        spiderSpeed = 2.0f;

        Vector2 point = currentPoint.position - transform.position; 
       
        if (currentPoint == pointB.transform)
        {
            spiderBody.velocity = new Vector2(spiderSpeed, 0);
        } else
        {
            spiderBody.velocity = new Vector2(-spiderSpeed, 0);
        }

        if(Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint ==pointB.transform)
        {
            currentPoint = pointA.transform; 
        }
    }

    public void CheckCollision()
    {
        void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                print("Working");
            }
        }
    }
}
