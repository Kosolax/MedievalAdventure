using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public string ItemName;

    public Item(string name)
    {
        this.ItemName = name;
    }
}
