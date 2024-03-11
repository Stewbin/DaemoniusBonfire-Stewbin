using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackandForth : MonoBehaviour
{
    [SerializeField] private float MoveRange;
    [SerializeField] private float MoveSpeed;
    [SerializeField] private bool Vertical; // Do you want Vertical motion?

    private float Direction = 1;
    private Vector3 StartPosition;
    private Vector3 TargetPosition;
    private Vector3 AxisOfMotion = Vector3.right; // Moves Horizontally by default

    void Start()
    {
        StartPosition = transform.position;
        TargetPosition = StartPosition +  (MoveRange * Direction * AxisOfMotion);
    }

    void Update()
    {
        // Evaluate axis of motion
        AxisOfMotion = Vertical ? Vector3.up : Vector3.right;

        // Move towards the end position
        float Step = Time.deltaTime * MoveSpeed;
        transform.position = Vector3.MoveTowards(transform.position, TargetPosition, Step);

        // If reached destination, 
        if (Vector3.Distance(transform.position, TargetPosition) < 0.01f)  
        {
            // Reverse direction
            Direction *= -1;
            // Recalculate TargetPosition
            TargetPosition = StartPosition + (MoveRange * Direction * AxisOfMotion);
        } 
    }
}
