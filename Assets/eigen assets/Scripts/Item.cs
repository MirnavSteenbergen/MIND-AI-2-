using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour, IInteractable
{
    public string interactPrompt;
    public string InteractPrompt => interactPrompt;

    public float interactRadius;
    public float InteractRadius => interactRadius;

    [System.NonSerialized]
    public bool interactable = true;
    public bool Interactable { get => interactable; set => interactable = value; }

    private ItemSlot itemSlot;
    private Vector3 itemSlotPosition = new Vector3(0, 0, 0);
    private Quaternion itemSlotRotation = new Quaternion(0, 0, 0, 0);

    public void Interact()
    {
        itemSlot.AddItem(this);
    }

    public void MoveToSlotPosition()
    {
        transform.localPosition = itemSlotPosition;
        transform.localRotation = itemSlotRotation;
    }

    // Start is called before the first frame update
    void Start()
    {
        itemSlot = GameObject.FindObjectOfType<ItemSlot>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
