/* -------------------------------------------------------------- */
/* -----------All rights reserved to Medieval Adventure---------- */
/* -------------------------------------------------------------- */

using UnityEngine;

[CreateAssetMenu]
public class EquippableItem : Item
{
    public int ActionPointBonus;
    public int CriticalRateBonus;
    public int HealthPointBonus;
    public int MagicalDamageBonus;
    public int MagicalPenetrationBonus;
    public int MagicalResistanceBonus;
    public int PhysicalDamageBonus;
    public int PhysicalPenetrationBonus;
    public int PhysicalResistanceBonus;
    public int SpeedBonus;
    [Space]
    public float ActionPointPercentBonus;
    public float CriticalRatePercentBonus;
    public float HealthPointPercentBonus;
    public float MagicalDamagePercentBonus;
    public float MagicalPenetrationPercentBonus;
    public float MagicalResistancePercentBonus;
    public float PhysicalDamagePercentBonus;
    public float PhysicalPenetrationPercentBonus;
    public float PhysicalResistancePercentBonus;
    public float SpeedPercentBonus;
    [Space]
    public EquipmentType EquipmentType;

    public void Equip(Character c)
    {
        if (this.ActionPointBonus != 0)
        {
            c.ActionPoint.AddModifier(new StatisticModifier(this.ActionPointBonus, StatisticModifierType.Flat, this));
        }
        if (this.CriticalRateBonus != 0)
        {
            c.CriticalRate.AddModifier(new StatisticModifier(this.CriticalRateBonus, StatisticModifierType.Flat, this));
        }
        if (this.HealthPointBonus != 0)
        {
            c.HealthPoint.AddModifier(new StatisticModifier(this.HealthPointBonus, StatisticModifierType.Flat, this));
        }
        if (this.MagicalDamageBonus != 0)
        {
            c.MagicalDamage.AddModifier(new StatisticModifier(this.MagicalDamageBonus, StatisticModifierType.Flat, this));
        }
        if (this.MagicalPenetrationBonus != 0)
        {
            c.MagicalPenetration.AddModifier(new StatisticModifier(this.MagicalPenetrationBonus, StatisticModifierType.Flat, this));
        }
        if (this.MagicalResistanceBonus != 0)
        {
            c.MagicalResistance.AddModifier(new StatisticModifier(this.MagicalResistanceBonus, StatisticModifierType.Flat, this));
        }
        if (this.PhysicalDamageBonus != 0)
        {
            c.PhysicalDamage.AddModifier(new StatisticModifier(this.PhysicalDamageBonus, StatisticModifierType.Flat, this));
        }
        if (this.PhysicalPenetrationBonus != 0)
        {
            c.PhysicalPenetration.AddModifier(new StatisticModifier(this.PhysicalPenetrationBonus, StatisticModifierType.Flat, this));
        }
        if (this.PhysicalResistanceBonus != 0)
        {
            c.PhysicalResistance.AddModifier(new StatisticModifier(this.PhysicalResistanceBonus, StatisticModifierType.Flat, this));
        }
        if (this.SpeedBonus != 0)
        {
            c.Speed.AddModifier(new StatisticModifier(this.SpeedBonus, StatisticModifierType.Flat, this));
        }

        if (this.ActionPointPercentBonus != 0)
        {
            c.ActionPoint.AddModifier(new StatisticModifier(this.ActionPointPercentBonus, StatisticModifierType.PercentAdd, this));
        }
        if (this.CriticalRatePercentBonus != 0)
        {
            c.CriticalRate.AddModifier(new StatisticModifier(this.CriticalRatePercentBonus, StatisticModifierType.PercentAdd, this));
        }
        if (this.HealthPointPercentBonus != 0)
        {
            c.HealthPoint.AddModifier(new StatisticModifier(this.HealthPointPercentBonus, StatisticModifierType.PercentAdd, this));
        }
        if (this.MagicalDamagePercentBonus != 0)
        {
            c.MagicalDamage.AddModifier(new StatisticModifier(this.MagicalDamagePercentBonus, StatisticModifierType.PercentAdd, this));
        }
        if (this.MagicalPenetrationPercentBonus != 0)
        {
            c.MagicalPenetration.AddModifier(new StatisticModifier(this.MagicalPenetrationPercentBonus, StatisticModifierType.PercentAdd, this));
        }
        if (this.MagicalResistancePercentBonus != 0)
        {
            c.MagicalResistance.AddModifier(new StatisticModifier(this.MagicalResistancePercentBonus, StatisticModifierType.PercentAdd, this));
        }
        if (this.PhysicalDamagePercentBonus != 0)
        {
            c.PhysicalDamage.AddModifier(new StatisticModifier(this.PhysicalDamagePercentBonus, StatisticModifierType.PercentAdd, this));
        }
        if (this.PhysicalPenetrationPercentBonus != 0)
        {
            c.PhysicalPenetration.AddModifier(new StatisticModifier(this.PhysicalPenetrationPercentBonus, StatisticModifierType.PercentAdd, this));
        }
        if (this.PhysicalResistancePercentBonus != 0)
        {
            c.PhysicalResistance.AddModifier(new StatisticModifier(this.PhysicalResistancePercentBonus, StatisticModifierType.PercentAdd, this));
        }
        if (this.SpeedPercentBonus != 0)
        {
            c.Speed.AddModifier(new StatisticModifier(this.SpeedPercentBonus, StatisticModifierType.PercentAdd, this));
        }
    }

    public void Unequip(Character c)
    {
        c.ActionPoint.RemoveAllModifiersFromSource(this);
        c.CriticalRate.RemoveAllModifiersFromSource(this);
        c.HealthPoint.RemoveAllModifiersFromSource(this);
        c.MagicalDamage.RemoveAllModifiersFromSource(this);
        c.MagicalPenetration.RemoveAllModifiersFromSource(this);
        c.MagicalResistance.RemoveAllModifiersFromSource(this);
        c.PhysicalDamage.RemoveAllModifiersFromSource(this);
        c.PhysicalPenetration.RemoveAllModifiersFromSource(this);
        c.PhysicalResistance.RemoveAllModifiersFromSource(this);
        c.Speed.RemoveAllModifiersFromSource(this);
    }
}