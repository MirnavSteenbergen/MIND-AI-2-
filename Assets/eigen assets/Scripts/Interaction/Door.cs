using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Slider
{
    private AudioSource doorSound;

    public AudioClip doorOpenSound;
    public AudioClip doorCloseSound;

    private void Awake()
    {
        doorSound = gameObject.AddComponent<AudioSource>();
        doorSound.spatialBlend = 1f;
    }

    public override void Act()
    {
        base.Act();

        if (open && doorCloseSound != null) doorSound.clip = doorCloseSound;
        else if (doorOpenSound != null) doorSound.clip = doorOpenSound;

        doorSound.Play();
    }
}
