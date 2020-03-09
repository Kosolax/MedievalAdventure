using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitBdd : MonoBehaviour
{



    protected Stats ActionPoints = new Stats("Permet de faire des actions et de bouger", null, "Point d'Action", 0);


    protected Stats CriticalRates = new Stats("Permet de realiser des coups critiques", null, "Taux de Critique", 0);

    protected Stats Heal = new Stats("Points de vie", null, "Vie", 0);


    protected Stats MagicalDamages = new Stats("Puissance magique", null, "Dommage Magique", 0);


    protected Stats MagicalPenetrations = new Stats("Permet de d'ignorer la resistance magique", null, "Penetration Magique", 0);


    protected Stats MagicalResistances = new Stats("Permet de recevoir moins de degats magiques", null, "Resistance Magique", 0);

 
    protected Stats PhysicalDamages = new Stats("Degat Physique", null, "Dommage Physique", 0);


    protected Stats PhysicalPenetrations = new Stats("Permet d'ignorer la resistance physique", null, "Penetration Physique", 0);


    protected Stats PhysicalResistances = new Stats("Permet de recevoir moins de degats physiques", null, "Resistance Physique", 0);


    protected Stats Speed = new Stats("Permet de derminer l'ordre des tours", null, "Vitesse", 0);


    private void Start()
    {

        StatsBdd statsBdd = new StatsBdd();

        statsBdd.AddStat(ActionPoints);
        statsBdd.AddStat(CriticalRates);
        statsBdd.AddStat(Heal);
        statsBdd.AddStat(MagicalDamages);
        statsBdd.AddStat(MagicalPenetrations);
        statsBdd.AddStat(MagicalResistances);
        statsBdd.AddStat(PhysicalDamages);
        statsBdd.AddStat(PhysicalPenetrations);
        statsBdd.AddStat(PhysicalResistances);
        statsBdd.AddStat(Speed);

    }
}
