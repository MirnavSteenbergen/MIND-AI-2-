using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    public Transform slideDoorBox;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            slideDoorBox.GetComponent<InteractableDoor>().playerNear = true;
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            slideDoorBox.GetComponent<InteractableDoor>().playerNear = false;
        }
    }
}
