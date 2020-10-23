using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpherePuzzle : FocusableInteractable, IUnlocker
{
    public GameObject[] spheres;

    public Material litMaterial;
    public Material unlitMaterial;

    private int step = 0;
    public bool emissionOn = false;

    public event UnlockHandler Unlocked;

    public override void Start()
    {
        base.Start();

        if(emissionOn)
        {
            lightSphere(step, emissionOn);
        }
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();

        if (focusController.focused)
        {
            if (Input.GetMouseButtonDown(0))
            {
                CheckHitObject();
            }
        }
    }

    public override void Exit()
    {
        base.Exit();

        lightSphere(step, false);

        if (step < 4)
        {
            lightSphere(0, true);
            step = 0;
        }
    }

    void CheckHitObject()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit[] hits;
        hits = Physics.RaycastAll(ray, 10f);

        foreach(RaycastHit hit in hits)
        {
            if (hit.transform == spheres[step].transform)
            {
                if(step >= 4)
                {
                    SetEmission(false);
                    Unlocked?.Invoke();
                    Exit();
                }
                else
                {
                    lightSphere(step, false);
                    lightSphere(step + 1, true);

                    step++;
                }
            }
        }
    }

    public void SetEmission(bool emission)
    {
        emissionOn = emission;
        lightSphere(step, emission);
    }

    void lightSphere(int sphereNumber, bool light)
    {
        if (emissionOn || !light)
        {
            GameObject sphere = spheres[sphereNumber];
            sphere.GetComponent<Renderer>().material = light ? litMaterial : unlitMaterial;
        }
    }

    public override void FinishedZoomingOut()
    {
        playerMovement.Normal();
        if(step < 4) Interactable = true;
    }
}
