using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackandForth : MonoBehaviour
{
    [SerializeField]
    private float lerpspeed;
    private float range;
    Vector3 midPt, leftPt, rightPt; 
    void Start()
    {
        midPt = leftPt = rightPt = transform.position; // Midpoint of the motion, and where you place the game object
        // Add/Subtract the ranges from the midPt's horizontal coordinate
        leftPt.x -=  range;
        rightPt.x += range;
    }

    void Update()
    {
        transform.position = Vector3.Lerp(leftPt, rightPt, lerpspeed);
    }
}
