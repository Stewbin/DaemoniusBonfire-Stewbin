using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// When 
public class MoveWithPlatform : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb; 
    void FixedUpdate()
    {
        Vector3 Position = transform.position;
        
        RaycastHit2D Hit = Physics2D.Raycast(Position, Vector3.down, 3.0f, LayerMask.GetMask("FloorMask"));
        Debug.DrawRay(transform.position, Vector3.down, Color.green);

        // If not hit
        if (Hit.transform == null)
            return;

        else if (Hit.transform.gameObject.CompareTag("movingFloor"))
        {
            // Retrieve monobehaviour of hit
            MoveBackandForth HitObj = Hit.transform.GetComponent<MoveBackandForth>();
            // Determine the platform's axis of motion
            Vector2 AxisOfMotion = HitObj.GetIsVertical() ? Vector2.up : Vector2.right;
            // Calculuate platform's movement
            Vector2 PlatformVelocity = AxisOfMotion * HitObj.GetMoveSpeed();
            // Add velocity to standing object's rigidbody
            rb.velocity += PlatformVelocity;
        }


    }
}
