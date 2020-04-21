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
        List<string> mob = new List<string>(mobBdd.FindById(idMob));
        try
        {
        Name = mob[1];
        Description = mob[2];
        ActionPoints.Value = Int32.Parse(mob[3]);
        CriticalRates.Value = Int32.Parse(mob[4]);
        Heal.Value = Int32.Parse(mob[5]);
        MagicalDamages.Value = Int32.Parse(mob[6]);
        MagicalPenetrations.Value = Int32.Parse(mob[7]);
        MagicalResistances.Value = Int32.Parse(mob[8]);
        PhysicalDamages.Value = Int32.Parse(mob[9]);
        PhysicalPenetrations.Value = Int32.Parse(mob[10]);
        PhysicalResistances.Value = Int32.Parse(mob[11]);
        Speed.Value = Int32.Parse(mob[12]);
        }
        catch (Exception)
        {
            Debug.Log("Error Parse Id Mob = " + mob[0]);
        }
        
    }

}