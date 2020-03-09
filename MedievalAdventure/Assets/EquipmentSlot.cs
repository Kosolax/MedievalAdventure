using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentSlot : ItemSlot
{
    public EquipmentType EquipmentType;

    //ToRemove ?
    protected override void OnValidate()
    {
        base.OnValidate();
        this.gameObject.name = this.EquipmentType.ToString() + " Slot";
    }

    public override bool CanReceiveItem(Item item)
    {
        if(item == null)
        {
            return true;
        }

        EquippableItem equippableItem = item as EquippableItem;
        return equippableItem != null && equippableItem.EquipmentType == this.EquipmentType;
    }
}
