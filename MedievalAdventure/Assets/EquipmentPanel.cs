using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentPanel : MonoBehaviour
{
    [SerializeField] private EquipmentSlot[] equipmentSlots;

    public event Action<ItemSlot> OnRightClickEvent;
    public event Action<ItemSlot> OnPointerExitEvent;
    public event Action<ItemSlot> OnPointerEnterEvent;
    public event Action<ItemSlot> OnBeginDragEvent;
    public event Action<ItemSlot> OnEndDragEvent;
    public event Action<ItemSlot> OnDragEvent;
    public event Action<ItemSlot> OnDropEvent;

    private void Awake()
    {
        for (int i = 0; i < this.equipmentSlots.Length; i++)
        {
            this.equipmentSlots[i].OnRightClickEvent += OnRightClickEvent;
            this.equipmentSlots[i].OnPointerExitEvent += OnPointerExitEvent;
            this.equipmentSlots[i].OnPointerEnterEvent += OnPointerEnterEvent;
            this.equipmentSlots[i].OnBeginDragEvent += OnBeginDragEvent;
            this.equipmentSlots[i].OnEndDragEvent += OnEndDragEvent;
            this.equipmentSlots[i].OnDragEvent += OnDragEvent;
            this.equipmentSlots[i].OnDropEvent += OnDropEvent;
        }
    }

    public bool AddItem(EquippableItem item, out EquippableItem previousItem)
    {
        for (int i = 0; i < this.equipmentSlots.Length; i++)
        {
            if(this.equipmentSlots[i].EquipmentType == item.EquipmentType)
            {
                previousItem = (EquippableItem)this.equipmentSlots[i].Item;
                this.equipmentSlots[i].Item = item;
                return true;
            }
        }
        previousItem = null;
        return false;
    }

    public bool RemoveItem(EquippableItem item)
    {
        for (int i = 0; i < this.equipmentSlots.Length; i++)
        {
            if (this.equipmentSlots[i].Item == item)
            {
                this.equipmentSlots[i].Item = null;
                return true;
            }
        }

        return false;
    }
}
