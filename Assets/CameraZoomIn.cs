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
    private float MaxZoom;

    void Start()
    {
        // Record current (default) camera state
        MaxZoom = vcam.m_Lens.OrthographicSize;

        // Make sure MinZoom is between 1 and our current zoom size
        MinZoom = Mathf.Clamp(MinZoom, 1f, MaxZoom);
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
                BlendState(MinZoom)
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
            BlendState(MaxZoom)
        );
    }

    IEnumerator BlendState(float TargetZoom)
    {
        Debug.Log("Coroutine stared.");
        float currentZoom = vcam.m_Lens.OrthographicSize;
        for (float t = 0; t < 1; t += Time.deltaTime * TransitionSpeed)
        {
            Debug.Log("Coroutine iteration: " + t);
            vcam.m_Lens.OrthographicSize = Mathf.Lerp(currentZoom, TargetZoom, t);
            yield return null;
        }
        Debug.Log("Coroutine completed.");
    }
}