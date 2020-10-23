using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VideoController : FocusableInteractable
{
    public Video video;

    public override void FinishedZoomingIn()
    {
        onScreenText.text = exitPrompt;
        video.Play();
    }

    public override void Exit()
    {
        base.Exit();
        video.Stop();
    }

}
