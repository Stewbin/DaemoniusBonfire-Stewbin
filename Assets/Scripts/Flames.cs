using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flames : MonoBehaviour
{
    // Start is called before the first frame update
    public ParticleSystem Fire;

    void Start()
    {
        Fire.transform.position = transform.position;
        Fire.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(transform.position, transform.right * 10, Color.green);
        if (Physics2D.Raycast(transform.position, transform.right, 10).collider != null)
        {

            Collider2D c = Physics2D.Raycast(transform.position, transform.right * 4, 10).collider;
            if (c.gameObject.tag == "Player")
            {
                Fire.Play();
            }
            else
            {
                Fire.Stop();
            }
        }
        else
        {
            Fire.Stop();

        }
    }
}
