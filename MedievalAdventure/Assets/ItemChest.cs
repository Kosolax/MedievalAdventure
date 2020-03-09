using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemChest : MonoBehaviour
{
    [SerializeField] private Item item;
    [SerializeField] private KeyCode itemPickUpKeyCode = KeyCode.E;

    private bool isInRange;
    private Inventory inventory;

    private void Update()
    {
        if (this.isInRange && Input.GetKeyDown(this.itemPickUpKeyCode))
        {
            this.inventory.AddItem(this.item);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        this.inventory = other.gameObject.GetComponentInChildren<Inventory>();
        this.isInRange = true;
    }

    private void OnTriggerExit(Collider other)
    {
        this.inventory = null;
        this.isInRange = false;
    }
}
