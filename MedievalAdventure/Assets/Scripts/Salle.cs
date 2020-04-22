using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Salle : MonoBehaviour
{
    public List<Item> itemsMap = new List<Item>();
    public Component[] mobs;
    
    // Start is called before the first frame update
    void Start()
    {
        mobs = GetComponentsInChildren<Mob>();
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    public void UpdateMobs(int nb)
    {
        Player player = GUIElement.FindObjectOfType<Player>();
        if (nb == 0)
        {
            player.items.AddRange(itemsMap);
        }
    }
}
