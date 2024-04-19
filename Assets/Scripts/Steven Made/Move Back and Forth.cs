using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class MoveBackandForth : MonoBehaviour
{
    [SerializeField] private float MoveRange;
    [SerializeField] private float MoveSpeed;
    [SerializeField] private bool IsVertical; // Do you want Vertical motion?

    private float Direction = 1;
    private Vector3 StartPosition;
    private Vector3 TargetPosition;
    private Vector3 AxisOfMotion = Vector3.right; // Moves Horizontally by default

    void Start()
    {
        StartPosition = transform.position;
        TargetPosition = StartPosition + (MoveRange * Direction * AxisOfMotion);
    }

    void Update()
    {
        // Evaluate axis of motion
        AxisOfMotion = IsVertical ? Vector3.up : Vector3.right;

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

        // Show range of motion
        Debug.DrawRay(StartPosition, MoveRange * AxisOfMotion, Color.green); // Forward
        Debug.DrawRay(StartPosition, -MoveRange * AxisOfMotion, Color.green); // Back
    }

    public bool GetIsVertical()
    { return IsVertical; }
    public float GetMoveSpeed()
    { return MoveSpeed; }

    // Make player move with platform 
    
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(this.transform);
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
         if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(null);
        }
    }
    
}
