using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Mob : MonoBehaviour
{
    protected string mobName;
    [SerializeField] private List<ItemsList> items = new List<ItemsList>(); 

    public int hpMax = 100;
    public int hp = 100;
    public int lvl = 3;
    public Salle salle ;

    // Start is called before the first frame update
    void Start()
    {
        salle = GetComponentInParent<Salle>();

    }

// Update is called once per frame
void Update()
    {
        
    }

    void DieBy()
    {
      
        //ajoute items player
        for (int i = 0; i < this.items.Count; i++)
        {
            if (this.items[i].IsDropped())
            {
                int stack = this.items[i].RandomStack();
                for ( int j = 0 ; j < stack ; j++)
                {
                    salle.itemsMap.Add(this.items[i].GetItem());
                }
            }
        }

        // Implémantation du gain xp 
        Destroy(this.gameObject, 0f);
        Debug.Log("--------- NEXT MOB ----------");
        
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "Player")
        {

            Mob[] mobs = salle.GetComponentsInChildren<Mob>();
            this.DieBy();
            salle.UpdateMobs(mobs.Length - 1);

        }
        
    }
}

