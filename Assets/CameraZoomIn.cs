using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using JetBrains.Annotations;


public class CameraZoomIn : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera vcam;
    [SerializeField] private float MinZoom = 2f;
    [SerializeField] private float TransitionSpeed = 1.0f;
    private LensSettings maxZoomState;
    private LensSettings minZoomState;

    void Start()
    {
        // Record current (default) camera state
        maxZoomState = vcam.m_Lens;

        // Make sure MinZoom is between 1 and our current zoom size
        //MinZoom = Mathf.Clamp(MinZoom, 1f, maxZoomState.OrthographicSize);

        // Create a new canera state where ortho/zoom size is changed
        minZoomState = new()
        {
            OrthographicSize = MinZoom
        };
        // Make sure the new settings are "sane"
        minZoomState.Validate(); 
    }

    void OnTriggerEnter2D(Collider2D obj)
    {
        if(obj.CompareTag("Player"))
        {
            Debug.Log("Entered.");
            // Stop current running coroutine
            StopAllCoroutines();
            // Blend into zoomed in state
            StartCoroutine(
                BlendState(maxZoomState, minZoomState)
            );
        }
    }

    void OnTriggerExit2D()
    {
        Debug.Log("Exited.");
        // Stop current running coroutine
        StopAllCoroutines();
        // Blend into zoomed out state
        StartCoroutine(
            BlendState(minZoomState, maxZoomState)
        );
    }

    IEnumerator BlendState(LensSettings lensA, LensSettings lensB)
    {
        Debug.Log("Running running running.");
        for (float t = 0; t < 1; t += Time.deltaTime * TransitionSpeed)
        {
            LensSettings.Lerp(lensA, lensB, t);
        }
        yield return null;
    }
}