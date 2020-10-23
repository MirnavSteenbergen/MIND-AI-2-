using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiraSpeaker : FocusableInteractable
{
    public Lira lira;
    [System.NonSerialized] public AudioSource liraSound;

    private void Awake()
    {
        liraSound = gameObject.AddComponent<AudioSource>();
        liraSound.spatialBlend = 1f;
    }

    public override void FinishedZoomingIn()
    {
        base.FinishedZoomingIn();

        lira.StartChatting();
    }

    public override void Exit()
    {
        base.Exit();

        lira.StopChatting();
    }
}
