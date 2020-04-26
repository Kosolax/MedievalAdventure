using UnityEngine;
using MySql.Data.MySqlClient;

public class ManagerBdd
{
    public MySqlConnection connection;


    public string[] title = new string[10];
    public string[] text = new string[10];

    public int[] numberPrefab = new int[10];

    public int[] gain = new int[10];

    public int[] id = new int[10];

    int indexTab = 0;

    // Constructeur
    public ManagerBdd()
    {
        this.InitConnexion();
    }

    // Méthode pour initialiser la connexion
    public void InitConnexion()
    {
        // Création de la chaîne de connexion
        string connectionString = "SERVER=127.0.0.1; DATABASE=quete; UID=root; PASSWORD=root";
        this.connection = new MySqlConnection(connectionString);
    }

    public void FindDataQuest()
    {
        InitConnexion();

        try
        {
            // Ouverture de la connexion SQL
            this.connection.Open();

            // Création d'une commande SQL en fonction de l'objet connection
            MySqlCommand cmd = this.connection.CreateCommand();

            //Debug.Log("Etat de la connexion: " + connection.State);

            // Requête SQL
            cmd.CommandText = "SELECT * FROM description WHERE Status = 0";

            MySqlDataReader myReader;
            myReader = cmd.ExecuteReader();
  
            if(myReader.Read())
            {
                title[0] = myReader.GetString("Titre");
                text[0] = myReader.GetString("Texte");
                id[0] = myReader.GetInt32("ID");
                Debug.Log("essaie de lire Title: " + title[0]);
            }
            else
            {
                Debug.Log("plus de données");
                title[0] = "No quest for you!";
                text[0] = "";
            }

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

    public int FindCurrentQuest()
    {
        InitConnexion();

        indexTab = 0;

        try
        {
            // Ouverture de la connexion SQL
            this.connection.Open();

            // Création d'une commande SQL en fonction de l'objet connection
            MySqlCommand cmd = this.connection.CreateCommand();

            //Debug.Log("Etat de la connexion: " + connection.State);

            // Requête SQL
            cmd.CommandText = "SELECT * FROM description WHERE Status = 1";

            MySqlDataReader myReader;
            myReader = cmd.ExecuteReader();

            while (myReader.Read())
            {
                title[indexTab] = myReader.GetString("Titre");
                id[indexTab] = myReader.GetInt32("ID");
                numberPrefab[indexTab] = myReader.GetInt32("NumberPrefabs");
                gain[indexTab] = myReader.GetInt32("Recompense");

                //Debug.Log("essaie de lire Title: " + title[indexTab]);
                indexTab++; 
            }
            
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
        
            return indexTab;
    }

    public int FindFinishQuest()
    {
        InitConnexion();

        indexTab = 0;

        try
        {
            // Ouverture de la connexion SQL
            this.connection.Open();

            // Création d'une commande SQL en fonction de l'objet connection
            MySqlCommand cmd = this.connection.CreateCommand();

            // Requête SQL
            cmd.CommandText = "SELECT * FROM description WHERE Status = 2";

            MySqlDataReader myReader;
            myReader = cmd.ExecuteReader();

            while (myReader.Read())
            {
                title[indexTab] = myReader.GetString("Titre");
                //Debug.Log("essaie de lire Title: " + title[indexTab]);
                indexTab++;
            }

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

        return indexTab;
    }

    public void updateData(int id, int status)
    {
        InitConnexion();

        try
        {
            // Ouverture de la connexion SQL
            this.connection.Open();
           
            // Création d'une commande SQL en fonction de l'objet connection
            MySqlCommand cmd = this.connection.CreateCommand();

           // Debug.Log("test id : "  + id[0]);

 
            // Requête SQL
            cmd.CommandText = "UPDATE description SET Status = "+ status +" WHERE ID = "+id;

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
}
