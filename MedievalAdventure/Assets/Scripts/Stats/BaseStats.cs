/* -------------------------------------------------------------- */
/* -----------All rights reserved to Medieval Adventure---------- */
/* -------------------------------------------------------------- */

using System.Collections.Generic;
using UnityEngine;

public class BaseStats : MonoBehaviour
{
    [SerializeField]
    public Stats ActionPoints;

    [SerializeField]
    public Stats CriticalRates;

    [SerializeField]
    public Stats Heal;

    [SerializeField]
    public Stats MagicalDamages;

    [SerializeField]
    public Stats MagicalPenetrations ;

    [SerializeField]
    public Stats MagicalResistances;

    [SerializeField]
    public Stats PhysicalDamages ;

    [SerializeField]
    public Stats PhysicalPenetrations ;

    [SerializeField]
    public Stats PhysicalResistances ;

    [SerializeField]
    public Stats Speed ;

    private List<Stats> allStats;

    private void Awake()
    {
        //connexion a la bdd
        StatsBdd statsBdd = new StatsBdd();

        //recuperation de toute les stats dans la bdd
        allStats = statsBdd.AllStats();

        //Insertion des donnees de la bdd dans les differentes stats
        this.ActionPoints = this.allStats[0];
        this.CriticalRates = this.allStats[1];
        this.Heal = this.allStats[2];
        this.MagicalDamages = this.allStats[3];
        this.MagicalPenetrations = this.allStats[4];
        this.MagicalResistances = this.allStats[5];
        this.PhysicalDamages = this.allStats[6];
        this.PhysicalPenetrations = this.allStats[7];
        this.PhysicalResistances = this.allStats[8];
        this.Speed = this.allStats[9];
    }
}
