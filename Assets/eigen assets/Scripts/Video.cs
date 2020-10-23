using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class Video : MonoBehaviour
{
    private VideoPlayer videoPlayer;
    public Material videoMaterial;
    public Material offMaterial;
    private Renderer screenRenderer;

    private void Awake()
    {
        videoPlayer = GetComponent<VideoPlayer>();
        screenRenderer = GetComponent<Renderer>();
    }

    public void Play()
    {
        videoPlayer.Play();
        screenRenderer.material = videoMaterial;
    }

    public void Stop()
    {
        videoPlayer.Stop();
        screenRenderer.material = offMaterial;
    }
}
