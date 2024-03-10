using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackandForth : MonoBehaviour
{
    [SerializeField] private float MoveRange;
    [SerializeField] private float MoveSpeed;

    private float Direction = 1;
    private Vector3 StartPosition;
    private Vector3 TargetPosition;
    void Start()
    {
        StartPosition = transform.position;
        TargetPosition = StartPosition +  (MoveRange * Direction * Vector3.right);
    }

    void Update()
    {
        // Move towards the end position
        float Step = Time.deltaTime * MoveSpeed;
        transform.position = Vector3.MoveTowards(transform.position, TargetPosition, Step);

        // If reached destination, 
        if (Vector3.Distance(transform.position, TargetPosition) < 0.01f)  
        {
            // Reverse direction
            Direction *= -1;
            // Recalculate TargetPosition
            TargetPosition = StartPosition + (MoveRange * Direction * Vector3.right);
        } 
    }
}
