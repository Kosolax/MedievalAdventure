/* -------------------------------------------------------------- */
/* -----------All rights reserved to Medieval Adventure---------- */
/* -------------------------------------------------------------- */

using System;
using UnityEngine;

[Serializable]
public class Stats
{
    public int Id { get; set; }

    public readonly string Description;

    public readonly string PathIcone;

    public readonly string Title;

    public int Value;

    public Stats(string description, string pathIcone, string title, int value)
    {
        this.Description = description;
        this.PathIcone = pathIcone;
        this.Title = title;
        this.Value = value;
    }

    public Stats(int id, string description, string pathIcone, string title, int value)
    {
        this.Id = id;
        this.Description = description;
        this.PathIcone = pathIcone;
        this.Title = title;
        this.Value = value;
    }
    
}

