using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedFlames : MonoBehaviour
{
    // Stole these from Flame
    public ParticleSystem Fire;
    //public PlayerStats PlayerStats;
    public float RestPeriod;
    public float FlameDuration;
    void Start()
    {
        Fire.transform.position = transform.position;
        StartCoroutine(ShootFlamesRegularly());
    }

    IEnumerator ShootFlamesRegularly()   
    {
        while(true)
        {
            Fire.Play(); // Activate animation
            yield return new WaitForSeconds(FlameDuration); // Wait for FlameDuration seconds
                    
            Fire.Stop(); // Stop animation
            yield return new WaitForSeconds(RestPeriod); // Wait for RestPeriod seconds
        }
    }
}
