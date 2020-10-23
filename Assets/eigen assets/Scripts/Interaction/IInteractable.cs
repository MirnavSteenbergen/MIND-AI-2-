using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable
{
    string InteractPrompt { get; }
    float InteractRadius { get; }
    bool Interactable { get; set; }

    void Interact();
}
