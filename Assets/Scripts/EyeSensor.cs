using System;
using System.Linq;
using UnityEngine;
using System.Collections.Generic;

public class EyeSensor : MonoBehaviour
{
    //shoots ray and tells you if player hing you want to attack is in site s
    public GameObject[] Targets;
    Vector2[] rays;
    public int raycount;
    public float distance;
    public float angle;
    public float FOV;

    // public Ray
    private void Start()
    {
        rays = new Vector2[raycount + 1];
    }

    private void Update()
    {
        Vector2 origin = Vector2.zero;
        float angleIncrease = FOV / raycount;
        rays = new Vector2[raycount + 1];
        rays[0] = origin;
        float tempAngle = angle;
        // Vector3 a = transform.rotation.eulerAngles.normalized;
        // tempAngle = Mathf.Atan2(a.x, a.y) * Mathf.Rad2Deg;
        // if (tempAngle < 0) tempAngle += 360;
        for (int i = 1; i < rays.Length; i++)
        {
            float angleRad = tempAngle * Mathf.PI / 180f;
            Vector2 v = origin + new Vector2(Mathf.Cos(angleRad), Mathf.Sin(angleRad)) * distance;
            RaycastHit2D hit = Physics2D.Raycast(
                transform.position,
                new Vector2(Mathf.Cos(angleRad), Mathf.Sin(angleRad)),
                5
            );
            rays[i] = v;
            // if (hit.collider != null)
            // {
            //     Debug.Log(hit.collider.gameObject.tag);
            //     rays[i] = hit.point;
            // }

            tempAngle -= angleIncrease;
            Debug.DrawRay(transform.position, rays[i], Color.green);
        }
        // // int n = 0;
        // if (GetComponent<SpriteRenderer>().flipX)
        // 	n = -1;
        // else
        // 	n = 1;
        // transform.LookAt(new Vector2(0,0));

        // Debug.DrawRay(transform.position,, Color.green); //debugging purposes
    }

    public bool NearTarget()
    {
        for (int i = 0; i < rays.Length; i++)
        {
            RaycastHit2D[] hit = Physics2D.RaycastAll(
                transform.position,
                rays[i],
                5
            );

            foreach (RaycastHit2D hits in hit)
            {
                foreach (GameObject target in Targets)
                {
                    if (hits.collider.gameObject.CompareTag(target.tag))
                    {
                        return true;
                    }
                }
            }
        }
        return false;
    }

    public bool NearSomething()
    {
        for (int i = 0; i < rays.Length; i++)
        {
            RaycastHit2D[] hit = Physics2D.RaycastAll(transform.position, rays[i], 5);

            foreach (RaycastHit2D hits in hit)
            {
                if (hits.collider.transform.position != transform.position)
                {
                    return true;
                }
            }
        }
        return false;
    }
}
