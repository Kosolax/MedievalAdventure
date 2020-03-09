/* -------------------------------------------------------------- */
/* -----------All rights reserved to Medieval Adventure---------- */
/* -------------------------------------------------------------- */

using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour
{
    public Statistic ActionPoint;
    public Statistic CriticalRate;
    public Statistic HealthPoint;
    public Statistic MagicalDamage;
    public Statistic MagicalPenetration;
    public Statistic MagicalResistance;
    public Statistic PhysicalDamage;
    public Statistic PhysicalPenetration;
    public Statistic PhysicalResistance;
    public Statistic Speed;

    [SerializeField] private EquipmentPanel equipmentPanel;

    [SerializeField] private Inventory inventory;

    [SerializeField] private StatPanel statPanel;

    [SerializeField] private ItemToolTip itemToolTip;
     
    [SerializeField] private Image draggableItem;

    private ItemSlot draggedSlot;

    public void Equip(EquippableItem item)
    {
        if (this.inventory.RemoveItem(item))
        {
            if (this.equipmentPanel.AddItem(item, out EquippableItem previousItem))
            {
                if (previousItem != null)
                {
                    this.inventory.AddItem(previousItem);
                    previousItem.Unequip(this);
                    this.statPanel.UpdateStatValues();
                }

                item.Equip(this);
                this.statPanel.UpdateStatValues();
            }
        }
        else
        {
            this.inventory.AddItem(item);
        }
    }

    public void Unequip(EquippableItem item)
    {
        if (!this.inventory.IsFull() && this.equipmentPanel.RemoveItem(item))
        {
            item.Unequip(this);
            this.statPanel.UpdateStatValues();
            this.inventory.AddItem(item);
        }
    }

    private void Awake()
    {
        this.statPanel.SetStats(this.ActionPoint, this.CriticalRate, this.HealthPoint, this.MagicalDamage, this.MagicalPenetration, this.MagicalResistance, this.PhysicalDamage, this.PhysicalPenetration, this.PhysicalResistance, this.Speed);
        this.statPanel.UpdateStatValues();

        this.inventory.OnRightClickEvent += this.Equip;
        this.equipmentPanel.OnRightClickEvent += this.Unequip;

        this.inventory.OnPointerEnterEvent += this.ShowToolTip;
        this.equipmentPanel.OnPointerEnterEvent += this.ShowToolTip;

        this.inventory.OnPointerExitEvent += this.HideToolTip;
        this.equipmentPanel.OnPointerExitEvent += this.HideToolTip;

        this.inventory.OnBeginDragEvent += this.BeginDrag;
        this.equipmentPanel.OnBeginDragEvent += this.BeginDrag;

        this.inventory.OnEndDragEvent += this.EndDrag;
        this.equipmentPanel.OnEndDragEvent += this.EndDrag;

        this.inventory.OnDragEvent += this.Drag;
        this.equipmentPanel.OnDragEvent += this.Drag;

        this.inventory.OnDropEvent += this.Drop;
        this.equipmentPanel.OnDropEvent += this.Drop;
    }

    private void Equip(ItemSlot itemSlot)
    {
        EquippableItem equippableItem = itemSlot.Item as EquippableItem;
        if (equippableItem != null)
        {
            this.Equip(equippableItem);
        }
    }

    private void Unequip(ItemSlot itemSlot)
    {
        EquippableItem equippableItem = itemSlot.Item as EquippableItem;
        if (equippableItem != null)
        {
            this.Unequip(equippableItem);
        }
    }

    private void ShowToolTip(ItemSlot itemSlot)
    {
        EquippableItem equippableItem = itemSlot.Item as EquippableItem;
        if (equippableItem != null)
        {
            this.itemToolTip.ShowToolTip(equippableItem);
        }
    }

    private void HideToolTip(ItemSlot itemSlot)
    {
        this.itemToolTip.HideToolTip();
    }

    private void BeginDrag(ItemSlot itemSlot)
    {
        if(itemSlot.Item != null)
        {
            this.draggedSlot = itemSlot;
            this.draggableItem.sprite = itemSlot.Item.Icon;
            this.draggableItem.transform.position = Input.mousePosition;
            this.draggableItem.enabled = true;
        }
    }

    private void EndDrag(ItemSlot itemSlot)
    {
        this.draggedSlot = null;
        this.draggableItem.enabled = false;
    }

    private void Drag(ItemSlot itemSlot)
    {
        if(this.draggableItem.enabled)
        {
            this.draggableItem.transform.position = Input.mousePosition;
        }
    }

    private void Drop(ItemSlot dropItemSlot)
    {
        if(dropItemSlot.CanReceiveItem(this.draggedSlot.Item) && this.draggedSlot.CanReceiveItem(dropItemSlot.Item))
        {
            EquippableItem dragItem = this.draggedSlot.Item as EquippableItem;
            EquippableItem dropItem = dropItemSlot.Item as EquippableItem;

            if(this.draggedSlot is EquipmentSlot)
            {
                if (dragItem != null)
                {
                    dragItem.Unequip(this);
                }
                if (dropItem != null)
                {
                    dropItem.Equip(this);
                }
            }

            if(dropItemSlot is EquipmentSlot)
            {
                if (dragItem != null)
                {
                    dragItem.Equip(this);
                }
                if (dropItem != null)
                {
                    dropItem.Unequip(this);
                }
            }
            this.statPanel.UpdateStatValues();

            Item draggedItem = this.draggedSlot.Item;
            this.draggedSlot.Item = dropItemSlot.Item;
            dropItemSlot.Item = draggedItem;
        }
    }
}