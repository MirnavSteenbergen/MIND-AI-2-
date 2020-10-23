using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void UnlockHandler();

public interface IUnlocker
{
    event UnlockHandler Unlocked;
}
