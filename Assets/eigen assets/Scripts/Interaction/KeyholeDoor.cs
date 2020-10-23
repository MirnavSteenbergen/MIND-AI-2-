using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyholeDoor : Door
{
    public Keyhole unlocker;

    public override void Start()
    {
        base.Start();
        unlocker.Unlocked += Act;
    }

    public void OnDestroy()
    {
        unlocker.Unlocked -= Act;
    }
}
