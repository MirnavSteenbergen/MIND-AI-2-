using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slider : MonoBehaviour
{
    public float xOffset = 0;
    public float yOffset = 0;
    public float zOffset = 0;
    public float transitionTime = 1;

    private Vector3 closedPosition;
    private Vector3 openPosition;

    private float lerpPct = 0;

    [System.NonSerialized] public bool open = false;
    [System.NonSerialized] public bool transitioning = false;

    // Start is called before the first frame update
    public virtual void Start()
    {
        closedPosition = transform.position;
        openPosition = new Vector3(transform.position.x + xOffset, transform.position.y + yOffset, transform.position.z + zOffset);
    }

    // Update is called once per frame
    public virtual void Update()
    {
        if (transitioning)
        {
            lerpPct += Time.deltaTime / transitionTime;

            if (open) transform.position = Vector3.Lerp(openPosition, closedPosition, lerpPct);
            else transform.position = Vector3.Lerp(closedPosition, openPosition, lerpPct);

            if (lerpPct >= 1)
            {
                finishTransitioning();
            }
        }
    }

    public virtual void Act()
    {
        transitioning = true;
    }

    public virtual void finishTransitioning()
    {
        transitioning = false;
        open = !open;
        lerpPct = 0;
    }
}
