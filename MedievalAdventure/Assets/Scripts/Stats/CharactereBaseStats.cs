using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharactereBaseStats : BaseStats
{

    protected Stats level = new Stats("Niveau du personnage", null, "Niveau", 0);

    public void Damage(int damageAD, int damageAP, int penetrationAD, int penetrationAP)
    {
        int DamageHeal = 0;

        DamageHeal = (damageAD * damageAD / (PhysicalResistances.Value - penetrationAD)) + (damageAP * damageAP / (MagicalResistances.Value - penetrationAP));
        Heal.Value = Heal.Value - DamageHeal;
    }
    
}
