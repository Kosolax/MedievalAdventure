/* -------------------------------------------------------------- */
/* -----------All rights reserved to Medieval Adventure---------- */
/* -------------------------------------------------------------- */

using System;
using UnityEngine;

[Serializable]
public class Stats
{
    [SerializeField]
    private string description;

    [SerializeField]
    private Sprite icone;

    [SerializeField]
    private string title;

    [SerializeField]
    private int value;

    public String getDescription()
    {
        return description;
    }

    public Sprite getIcone()
    {
        return icone;
    }

    public String getTitle()
    {
        return title;
    }

    public int getValue()
    {
        return value;
    }

    public void setDescription(String Descrtiption)
    {
        description = Descrtiption;
    }

    public void setIcone(Sprite Icone)
    {
        icone = Icone;
    }

    public void setTitle(string Title)
    {
        title = Title;
    }

    public void setValue(int Value)
    {
        value = Value;
    }
}
