using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LiraSounds : MonoBehaviour
{
    public Sound[] sounds;

    public Sound FindSound(string name)
    {
        return Array.Find(sounds, sound => sound.name == name);
    }
}
