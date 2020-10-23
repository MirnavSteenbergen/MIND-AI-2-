using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectFocusController : MonoBehaviour
{
    public Transform cameraFocusPoint;
    public Transform mainCamera;

    public float transitionTime = 1;

    private Vector3 startPosition;
    private Quaternion startRotation;
    private Vector3 endPosition;
    private Quaternion endRotation;

    private float lerpPct = 0;

    [System.NonSerialized] public bool transitioning = false;
    [System.NonSerialized] public bool focused = false;

    public delegate void ZoomInHandler();
    public event ZoomInHandler ZoomedIn;

    public delegate void ZoomOutHandler();
    public event ZoomOutHandler ZoomedOut;

    // Start is called before the first frame update
    void Start()
    {
        endPosition = cameraFocusPoint.position;
        endRotation = cameraFocusPoint.rotation;
    }

    public void ZoomIn()
    {
        startPosition = mainCamera.position;
        startRotation = mainCamera.rotation;

        transitioning = true;
    }

    public void ZoomOut()
    {
        transitioning = true;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(transitioning)
        {
            lerpPct += Time.deltaTime / transitionTime;

            mainCamera.position = Vector3.Lerp(focused ? endPosition : startPosition, focused ? startPosition : endPosition, lerpPct);
            mainCamera.rotation = Quaternion.Lerp(focused ? endRotation : startRotation, focused ? startRotation : endRotation, lerpPct);

            if (lerpPct >= 1) FinishTransitioning();
        }
    }

    void FinishTransitioning()
    {
        transitioning = false;
        focused = !focused;
        lerpPct = 0;

        if (focused) ZoomedIn?.Invoke();
        else ZoomedOut?.Invoke();
    }
}
