using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableDoor : Door, IInteractable
{
    [System.NonSerialized]
    public string interactPrompt;
    public string InteractPrompt { get => interactPrompt; set => interactPrompt = value; }

public float interactRadius;
    public float InteractRadius => interactRadius;

    [System.NonSerialized]
    public bool interactable = true;
    public bool Interactable { get => interactable; set => interactable = value; }

    public string openPrompt = "Press E to open door";
    public string closePrompt = "Press E to close door";

    public bool closeAutomatically = true;
    public float cooldownTime = 1;

    private bool onCooldown = false;
    private float currentCooldownTime = 0;

    [System.NonSerialized] public bool playerNear = false;

    public override void Start()
    {
        base.Start();

        InteractPrompt = openPrompt;
    }

    public override void Update()
    {
        base.Update();

        if (open && closeAutomatically)
        {
            if (onCooldown)
            {
                currentCooldownTime += Time.deltaTime;

                if (currentCooldownTime >= cooldownTime && !playerNear)
                {
                    Act();
                    onCooldown = false;
                    currentCooldownTime = 0;
                }
            }
        }
    }

    public void Interact()
    {
        Act();
        Interactable = false;
    }

    public override void finishTransitioning()
    {
        base.finishTransitioning();


        if (!open || (open && !closeAutomatically))
        {
            Interactable = true;
        }

        if (open && closeAutomatically)
        {
            onCooldown = true;
        }

        InteractPrompt = open ? closePrompt : openPrompt;
    }
}
