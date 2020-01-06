/* -------------------------------------------------------------- */
/* -----------All rights reserved to Medieval Adventure---------- */
/* -------------------------------------------------------------- */

using UnityEngine;

public abstract class AbstractBaseStats : MonoBehaviour
{
    private Stats actionPoints;

    private Stats criticalRates;

    private Stats healPoStatss;

    private Stats magicalDamages;

    private Stats magicalPenetrations;

    private Stats magicalResistances;

    private Stats physicalDamages;

    private Stats physicalPenetrations;

    private Stats physicalResistances;

    private Stats speed;

    public Stats ActionPoints { get => actionPoints; set => actionPoints = value; }

    public Stats CriticalRates { get => criticalRates; set => criticalRates = value; }

    public Stats HealPoStatss { get => healPoStatss; set => healPoStatss = value; }

    public Stats MagicalDamages { get => magicalDamages; set => magicalDamages = value; }

    public Stats MagicalPenetrations { get => magicalPenetrations; set => magicalPenetrations = value; }

    public Stats MagicalResistances { get => magicalResistances; set => magicalResistances = value; }

    public Stats PhysicalDamages { get => physicalDamages; set => physicalDamages = value; }

    public Stats PhysicalPenetrations { get => physicalPenetrations; set => physicalPenetrations = value; }

    public Stats PhysicalResistances { get => physicalResistances; set => physicalResistances = value; }

    public Stats Speed { get => speed; set => speed = value; }
}
