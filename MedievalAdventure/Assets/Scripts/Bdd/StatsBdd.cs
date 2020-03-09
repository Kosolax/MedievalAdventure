/* -------------------------------------------------------------- */
/* -----------All rights reserved to Medieval Adventure---------- */
/* -------------------------------------------------------------- */

using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Data;

public class StatsBdd : Bdd
{
    // Méthode pour ajouter un contact
    public void AddStat(Stats stats)
    {
        try
        {
            // Ouverture de la connexion SQL
            this.connection.Open();

            // Création d'une commande SQL en fonction de l'objet connection
            MySqlCommand cmd = this.connection.CreateCommand();

            // Requête SQL
            cmd.CommandText = "INSERT INTO stat (title, icone, value, description) VALUES (@title, @icone, @value, @description)";

            // utilisation de l'objet contact passé en paramètre
            cmd.Parameters.AddWithValue("@title", stats.Title);
            cmd.Parameters.AddWithValue("@icone", stats.PathIcone);
            cmd.Parameters.AddWithValue("@value", stats.Value);
            cmd.Parameters.AddWithValue("@description", stats.Description);

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

    public List<Stats> AllStats()
    {
        try
        {
            // Ouverture de la connexion SQL
            this.connection.Open();

            // Création d'une commande SQL en fonction de l'objet connection
            MySqlCommand cmd = this.connection.CreateCommand();

            // Requête SQL
            cmd.CommandText = "SELECT * FROM stat ORDER BY id";

            List<Stats> stats = new List<Stats>();

            // Exécution de la commande SQL
            IDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Stats stat = new Stats((int)reader["id"], reader["description"].ToString(), reader["icone"].ToString(), reader["title"].ToString(), (int)reader["value"]);
                stats.Add(stat);
            }
            // Fermeture de la connexion
            this.connection.Close();

            return stats;
        }
        catch
        {
            // Gestion des erreurs :
            // Possibilité de créer un Logger pour les exceptions SQL reçus
            // Possibilité de créer une méthode avec un booléan en retour pour savoir si le contact à été ajouté correctement.
        }

        return null;
    }
}
