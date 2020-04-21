/* -------------------------------------------------------------- */
/* -----------All rights reserved to Medieval Adventure---------- */
/* -------------------------------------------------------------- */

using MySql.Data.MySqlClient;
using UnityEngine;

public class Bdd : MonoBehaviour
{
    protected MySqlConnection connection;

    // Constructeur
    public Bdd()
    {
        this.InitConnexion();
    }

    // Méthode pour initialiser la connexion
    private void InitConnexion()
    {
        // Création de la chaîne de connexion
        string connectionString = "SERVER=127.0.0.1; DATABASE=banquedb; UID=root; PASSWORD=;";
        this.connection = new MySqlConnection(connectionString);
    }
}
