using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Mob : CharactereBaseStats
{
    public int id;
    public string Name;
    public string Description ;

    public Mob()
    {
    }

    public Mob(string name, string description, int actionPoint, int criticalRate, int heal, int magicalDamage, int magicalPenetration, int magicalResistance, int physicalDamage, int physicalPenetration, int physicalResistance, int speed)
    {
        this.Name = name;
        this.Description = description;
        ActionPoints.Value = actionPoint;
        CriticalRates.Value = criticalRate;
        Heal.Value = heal;
        MagicalDamages.Value = magicalDamage;
        MagicalPenetrations.Value = magicalPenetration;
        MagicalResistances.Value = magicalResistance;
        PhysicalDamages.Value = physicalDamage;
        PhysicalPenetrations.Value = physicalPenetration;
        PhysicalResistances.Value = physicalResistance;
        Speed.Value = speed;
    }
    
    protected void GenerateMob(int idMob)
    {
        MobBdd mobBdd = new MobBdd();
        List<string> mob = new List<string>(mobBdd.FindByName(idMob));
        Name = mob[0];
        Description = mob[1];
        ActionPoints.Value = Int32.Parse(mob[2]);
        CriticalRates.Value = Int32.Parse(mob[3]);
        Heal.Value = Int32.Parse(mob[4]);
        MagicalDamages.Value = Int32.Parse(mob[5]);
        MagicalPenetrations.Value = Int32.Parse(mob[6]);
        MagicalResistances.Value = Int32.Parse(mob[7]);
        PhysicalDamages.Value = Int32.Parse(mob[8]);
        PhysicalPenetrations.Value = Int32.Parse(mob[9]);
        PhysicalResistances.Value = Int32.Parse(mob[10]);
        Speed.Value = Int32.Parse(mob[11]);
    }

}