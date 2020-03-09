using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private List<Item> startingItems;
    [SerializeField] private ItemSlot[] itemSlots;
    [SerializeField] private GameObject itemSlotPrefab;
    [SerializeField] private int lines;
    [SerializeField] private int columns;

    private void OnValidate()
    {
        this.SetStartingItems();
    }

    public event Action<ItemSlot> OnRightClickEvent;
    public event Action<ItemSlot> OnPointerExitEvent;
    public event Action<ItemSlot> OnPointerEnterEvent;
    public event Action<ItemSlot> OnBeginDragEvent;
    public event Action<ItemSlot> OnEndDragEvent;
    public event Action<ItemSlot> OnDragEvent;
    public event Action<ItemSlot> OnDropEvent;

    private void Awake()
    {
        int nbSlot = this.lines * this.columns;
        this.itemSlots = new ItemSlot[nbSlot];
        for (int i = 0; i < nbSlot; i++)
        {
            GameObject instantiatedGameobject = Instantiate(this.itemSlotPrefab, this.transform.position, this.transform.rotation);
            instantiatedGameobject.transform.SetParent(this.gameObject.transform, false);
            this.itemSlots[i] = instantiatedGameobject.GetComponentInChildren<ItemSlot>();
        }

        for (int i = 0; i < this.itemSlots.Length; i++)
        {
            this.itemSlots[i].OnRightClickEvent += OnRightClickEvent;
            this.itemSlots[i].OnPointerExitEvent += OnPointerExitEvent;
            this.itemSlots[i].OnPointerEnterEvent += OnPointerEnterEvent;
            this.itemSlots[i].OnBeginDragEvent += OnBeginDragEvent;
            this.itemSlots[i].OnEndDragEvent += OnEndDragEvent;
            this.itemSlots[i].OnDragEvent += OnDragEvent;
            this.itemSlots[i].OnDropEvent += OnDropEvent;
        }

        this.SetStartingItems();
    }

    private void SetStartingItems()
    {
        int i = 0;

        for(; i < this.startingItems.Count && i < this.itemSlots.Length; i++)
        {
            this.itemSlots[i].Item = Instantiate(this.startingItems[i]);
        }

        for(; i < this.itemSlots.Length; i++)
        {
            this.itemSlots[i].Item = null;
        }
    }

    public bool AddItem(Item item)
    {
        for (int i = 0; i < this.itemSlots.Length; i++)
        {
            if(this.itemSlots[i].Item == null)
            {
                this.itemSlots[i].Item = item;
                return true;
            }
        }

        return false;
    }

    public bool RemoveItem(Item item)
    {
        for (int i = 0; i < this.itemSlots.Length; i++)
        {
            if (this.itemSlots[i].Item == item)
            {
                this.itemSlots[i].Item = null;
                return true;
            }
        }

        return false;
    }

    public bool IsFull()
    {
        for (int i = 0; i < this.itemSlots.Length; i++)
        {
            if (this.itemSlots[i].Item == null)
            {
                return false;
            }
        }

        return true;
    }
}
