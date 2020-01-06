/* -------------------------------------------------------------- */
/* -----------All rights reserved to Medieval Adventure---------- */
/* -------------------------------------------------------------- */

using UnityEngine;

public class Stats : MonoBehaviour
{
    private string description;

    private Sprite icone;

    private string title;

    private int value;

    public string Description { get => this.description; set => this.description = value; }

    public Sprite Icone { get => this.icone; set => this.icone = value; }

    public string Title { get => this.title; set => this.title = value; }

    public int Value { get => this.value; set => this.value = value; }
}
