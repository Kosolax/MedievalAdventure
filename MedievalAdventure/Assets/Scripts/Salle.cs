/* -------------------------------------------------------------- */
/* -----------All rights reserved to Medieval Adventure---------- */
/* -------------------------------------------------------------- */

using System.Collections.Generic;
using UnityEngine;

public class Salle : MonoBehaviour
{
    public List<Item> itemsMap = new List<Item>();

    public Component[] mobs;

    // Start is called before the first frame update
    internal void Start()
    {
        mobs = GetComponentsInChildren<Mob>();
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
