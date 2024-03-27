using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flames : MonoBehaviour
{
    public int FlameThrowerLength;
    // Start is called before the first frame update
    public ParticleSystem Fire;
    public PlayerStats PlayerStats;
    void Start()
    {
        Fire.transform.position = transform.position;
        Fire.Stop();
    }
    void Update()
    {
        Debug.DrawRay(transform.position, transform.right * 10, Color.green);
        if (Physics2D.Raycast(transform.position, transform.right, FlameThrowerLength).collider != null &&
                Physics2D.Raycast(transform.position, transform.right, FlameThrowerLength).collider.gameObject.tag == "Player")
            Fire.Play();
        else
            Fire.Stop();
    }
}
