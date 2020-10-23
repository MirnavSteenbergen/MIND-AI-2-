using System;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    public Sound FindSound(string name)
    {
        return Array.Find(sounds, sound => sound.name == name);
    }
}
