using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedFlames : MonoBehaviour
{
    // Stole these from Flame
    public ParticleSystem Fire;
    //public PlayerStats PlayerStats;
    public float FlamePeriod;
    public float FlameDuration;
    [SerializeField] 
    private float waitTime;
    [SerializeField] 
    private float fireTime;
    void Start()
    {
        Fire.transform.position = transform.position;
        StartCoroutine(ShootFlamesRegularly());
    }

    IEnumerator ShootFlamesRegularly()   
    {
        fireTime = 0;
        waitTime = 0;
        while(true)
        {
            if (waitTime < FlamePeriod)
            {
                waitTime += Time.deltaTime;
            }
            else 
            {
               if (fireTime < FlameDuration)
                {
                    Fire.Play();
                    fireTime+= Time.deltaTime;
                    yield return null;
                }
                else
                {
                    fireTime= 0;
                    Fire.Stop();
                    waitTime = 0;
                } 
                yield return null;
            }
    }
}
