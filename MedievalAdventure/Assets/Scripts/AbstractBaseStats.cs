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

    public Stats ActionPoints { get => this.actionPoints; set => this.actionPoints = value; }

    public Stats CriticalRates { get => this.criticalRates; set => this.criticalRates = value; }

    public Stats HealPoStatss { get => this.healPoStatss; set => this.healPoStatss = value; }

    public Stats MagicalDamages { get => this.magicalDamages; set => this.magicalDamages = value; }

    public Stats MagicalPenetrations { get => this.magicalPenetrations; set => this.magicalPenetrations = value; }

    public Stats MagicalResistances { get => this.magicalResistances; set => this.magicalResistances = value; }

    public Stats PhysicalDamages { get => this.physicalDamages; set => this.physicalDamages = value; }

    public Stats PhysicalPenetrations { get => this.physicalPenetrations; set => this.physicalPenetrations = value; }

    public Stats PhysicalResistances { get => this.physicalResistances; set => this.physicalResistances = value; }

    public Stats Speed { get => this.speed; set => this.speed = value; }
}
