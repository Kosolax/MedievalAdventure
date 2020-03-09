using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class MobBdd : Bdd
{

    // Méthode pour ajouter un contact
    public void AddStat(Mob mob)
    {
        try
        {
            // Ouverture de la connexion SQL
            this.connection.Open();

            // Création d'une commande SQL en fonction de l'objet connection
            MySqlCommand cmd = this.connection.CreateCommand();

            // Requête SQL
            cmd.CommandText = "INSERT INTO mob (name, description, actionPoint, criticalRate, heal, magicalDamage, magicalPenetration, magicalResistance, physicalDamage, physicalPenetration, physicalResistance, speed) VALUES (@name, @description, @actionPoint, @criticalRate, @heal, @magicalDamage, @magicalPenetration, @magicalResistance, @physicalDamage, @physicalPenetration, @physicalResistance, @speed)";

            // utilisation de l'objet contact passé en paramètre
            cmd.Parameters.AddWithValue("@title", mob.Name);
            cmd.Parameters.AddWithValue("@description", mob.Description);
            cmd.Parameters.AddWithValue("@actionPoint", mob.ActionPoints);
            cmd.Parameters.AddWithValue("@criticalRate", mob.CriticalRates);
            cmd.Parameters.AddWithValue("@heal", mob.Heal);
            cmd.Parameters.AddWithValue("@magicalDamage", mob.MagicalDamages);
            cmd.Parameters.AddWithValue("@magicalPenetration", mob.MagicalPenetrations);
            cmd.Parameters.AddWithValue("@magicalResistance", mob.MagicalResistances);
            cmd.Parameters.AddWithValue("@physicalDamage", mob.PhysicalDamages);
            cmd.Parameters.AddWithValue("@physicalPenetration", mob.PhysicalPenetrations);
            cmd.Parameters.AddWithValue("@physicalResistance", mob.PhysicalResistances);
            cmd.Parameters.AddWithValue("@speed", mob.Speed);

            // Exécution de la commande SQL
            cmd.ExecuteNonQuery();

            // Fermeture de la connexion
            this.connection.Close();
        }
        catch
        {

            // Gestion des erreurs :
            // Possibilité de créer un Logger pour les exceptions SQL reçus
            // Possibilité de créer une méthode avec un booléan en retour pour savoir si le contact à été ajouté correctement.
        }
    }

    public List<String> FindByName(int idMob)
    {
        try
        {
            // Ouverture de la connexion SQL
            this.connection.Open();

            // Création d'une commande SQL en fonction de l'objet connection
            MySqlCommand cmd = this.connection.CreateCommand();

            // Requête SQL
            cmd.CommandText = "SELECT * FROM mob WHERE id = "+ idMob;

            // Exécution de la commande SQL
            IDataReader reader = cmd.ExecuteReader();

            List<string> mob = new List<string>();
            while (reader.Read())
            {
                mob.Add(String.Format("{0}", reader[1]));
                mob.Add(String.Format("{0}", reader[2]));
                mob.Add(String.Format("{0}", reader[3]));
                mob.Add(String.Format("{0}", reader[4]));
                mob.Add(String.Format("{0}", reader[5]));
                mob.Add(String.Format("{0}", reader[6]));
                mob.Add(String.Format("{0}", reader[7]));
                mob.Add(String.Format("{0}", reader[8]));
                mob.Add(String.Format("{0}", reader[9]));
                mob.Add(String.Format("{0}", reader[10]));
                mob.Add(String.Format("{0}", reader[11]));
                mob.Add(String.Format("{0}", reader[12]));
            }

            this.connection.Close();
            return mob;
        }
        catch
        {
            // Gestion des erreurs :
            // Possibilité de créer un Logger pour les exceptions SQL reçus
            // Possibilité de créer une méthode avec un booléan en retour pour savoir si le contact à été ajouté correctement.
        }

        return null;
    }

    public int UpdateStatMob(int idMob, String nameStat, int updateValeur)
    {
        try
        {
            // Ouverture de la connexion SQL
            this.connection.Open();

            // Création d'une commande SQL en fonction de l'objet connection
            MySqlCommand cmd = this.connection.CreateCommand();

            // Requête SQL
            cmd.CommandText = "UPDATE mob SET '"+ nameStat + "' = "+ updateValeur + " WHERE id = " + idMob;

            // Exécution de la commande SQL
            IDataReader reader = cmd.ExecuteReader();

            List<string> mob = new List<string>();
            while (reader.Read())
            {
                mob.Add(String.Format("{0}", reader[1]));
                mob.Add(String.Format("{0}", reader[2]));
                mob.Add(String.Format("{0}", reader[3]));
                mob.Add(String.Format("{0}", reader[4]));
                mob.Add(String.Format("{0}", reader[5]));
                mob.Add(String.Format("{0}", reader[6]));
                mob.Add(String.Format("{0}", reader[7]));
                mob.Add(String.Format("{0}", reader[8]));
                mob.Add(String.Format("{0}", reader[9]));
                mob.Add(String.Format("{0}", reader[10]));
                mob.Add(String.Format("{0}", reader[11]));
                mob.Add(String.Format("{0}", reader[12]));
            }

            this.connection.Close();
        }
        catch
        {
            // Gestion des erreurs :
            // Possibilité de créer un Logger pour les exceptions SQL reçus
            // Possibilité de créer une méthode avec un booléan en retour pour savoir si le contact à été ajouté correctement.
        }

        return 0
            ;
    }
}
