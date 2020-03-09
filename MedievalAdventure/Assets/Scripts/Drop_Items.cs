using System.Collections;
using UnityEngine;
using System;

[Serializable]
public class ItemsList
{
    public Item item;
    [Range(0, 100)] public float taux ;
    public Rarete rarete ; 
    

    public Item GetItem()
    {
        return this.item;
    }

    public float GetTaux()
    {
        return this.taux;
    }

    public bool IsDropped()
    {
        float chance = UnityEngine.Random.Range(0, 100);

        if(chance <= this.GetTaux())
        {
            return true;
        } 
        return false;       
    }

    public int RandomStack()
    {
        float chance = UnityEngine.Random.Range(0, 100);
        switch(rarete)
        {
            case Rarete.commun:

                if (chance <= 5)
                {
                    return 4;
                }
                else if (chance <= 20)
                {
                    return 3;
                }
                else if (chance <= 50)
                {
                    return 2;
                }
                else
                {
                    return 1;
                }
                
            case Rarete.rare:

                if (chance <= 10)
                {
                    return 2;
                }
                else
                {
                    return 1;
                }
               
            default:
                return 1;
        }  
    }
}
