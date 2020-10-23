using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSlot : MonoBehaviour
{
    public Item item;

    public void AddItem(Item item)
    {
        ClearItem();

        this.item = item;
        item.transform.parent = gameObject.transform;
        item.MoveToSlotPosition();
    }

    public void ClearItem()
    {
        foreach(Transform child in GetComponentInChildren<Transform>())
        {
            GameObject.Destroy(child.gameObject);
        }
    }



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
