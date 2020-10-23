using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keyhole : MonoBehaviour, IInteractable, IUnlocker
{
    public string interactPrompt;
    public string InteractPrompt => interactPrompt;

    public float interactRadius;
    public float InteractRadius => interactRadius;

    [System.NonSerialized]
    public bool interactable = true;
    public bool Interactable { get => interactable; set => interactable = value; }

    public int id;

    private ItemSlot itemSlot;
    private bool unlocking;

    public event UnlockHandler Unlocked;

    public void Interact()
    {
        if(itemSlot.item && itemSlot.item.GetComponent<Key>().id == id)
        {
            unlocking = true;
        }
        else
        {
            Debug.Log("Don't have the correct key!");
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        itemSlot = GameObject.FindObjectOfType<ItemSlot>();
    }

    // Update is called once per frame
    void Update()
    {
        if(unlocking)
        {
            Unlocked?.Invoke();
            itemSlot.ClearItem();
            unlocking = false;
        }
    }
}
