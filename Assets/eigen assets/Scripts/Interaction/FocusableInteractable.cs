using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FocusableInteractable : MonoBehaviour, IInteractable
{
    public string interactPrompt;
    public string InteractPrompt => interactPrompt;

    public float interactRadius;
    public float InteractRadius => interactRadius;

    [System.NonSerialized]
    public bool interactable = true;
    public bool Interactable { get => interactable; set => interactable = value; }

    public PlayerMovement playerMovement;
    public Text onScreenText;
    public ObjectFocusController focusController;

    public string exitPrompt = "Press ESC to exit";

    public virtual void Interact()
    {
        playerMovement.None();
        focusController.ZoomIn();
        Interactable = false;
    }

    public virtual void Exit()
    {
        playerMovement.None();
        focusController.ZoomOut();
        onScreenText.text = "";
    }

    public virtual void FinishedZoomingIn()
    {
        playerMovement.CursorOnly();
        onScreenText.text = exitPrompt;
    }

    public virtual void FinishedZoomingOut()
    {
        playerMovement.Normal();
        Interactable = true;
    }

    public virtual void Start()
    {
        focusController.ZoomedIn += FinishedZoomingIn;
        focusController.ZoomedOut += FinishedZoomingOut;
    }

    public void OnDestroy()
    {
        focusController.ZoomedIn -= FinishedZoomingIn;
        focusController.ZoomedOut -= FinishedZoomingOut;
    }

    public virtual void Update()
    {
        if (focusController.focused && !focusController.transitioning && Input.GetKeyDown(KeyCode.Escape)) Exit();
    }

    
}
