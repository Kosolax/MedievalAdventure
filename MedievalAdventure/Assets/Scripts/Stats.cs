/* -------------------------------------------------------------- */
/* -----------All rights reserved to Medieval Adventure---------- */
/* -------------------------------------------------------------- */

using UnityEngine;

public class Stats : MonoBehaviour
{
    private string name;

    private int values;

    private string description;

    private Sprite icone;

    public string Name { get => name; set => name = value; }

    public int Values { get => values; set => values = value; }

    public string Description { get => description; set => description = value; }

    public Sprite Icone { get => icone; set => icone = value; }
}
