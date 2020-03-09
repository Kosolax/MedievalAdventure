using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Mob : MonoBehaviour
{
    protected string name;
    protected List<Item> items;
    public int hp = 100;
    public int currentLevel = 3;
       
    // Start is called before the first frame update
    void Start()
    {
        items = new List<Item>();

        Item item1 = new Item("cuir");
    
        Item item2 = new Item("viande");
      

        items.Add(item1);
        items.Add(item2);
    }

    // Update is called once per frame
    void Update()
    {
        

        if (Input.GetKeyDown(KeyCode.K))
        {
            MobDie();
        }
    }

    void MobDie()
    {
        if(hp == 0)
        {
            Debug.Log("Mort" + hp);

        }
        // on utilise la fonction gain d'expérience --> hériter de la class xp
        // récupérer la liste d'item --> ajouter à l'inventaire du joueur
        // ajouter after effect et suppression du mob
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "Player")
        {
            hp = 0;
            MobDie();
        }
        
    }
}
