using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractionManager : MonoBehaviour
{
    private string interactableTag = "Interactable";
    private Transform _selection;

    public Text onScreenText;

    // Update is called once per frame
    void Update()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit))
        {
            if(_selection != null)
            {
                var selectionRenderer = _selection.GetComponent<Renderer>();
                onScreenText.text = "";
                _selection = null;
            }

            var selection = hit.transform;
            var interactable = selection.GetComponent<IInteractable>();

            if (selection.CompareTag(interactableTag) && hit.distance < interactable.InteractRadius && interactable.Interactable)
            {
                var selectionRenderer = selection.GetComponent<Renderer>();

                if (selectionRenderer != null)
                {
                    onScreenText.text = interactable.InteractPrompt;
                }

                _selection = selection;
            }
        }

        if(_selection != null)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                _selection.GetComponent<IInteractable>().Interact();
            }
        }
    }
}
