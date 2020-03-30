using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    public Text textNbApple;
    public Text textNbGold;

    public int nbApple;
    public int nbGold;

    public int levelExp;

    // Update is called once per frame
    void Update()
    {
        textNbApple.text = "Number Of Apple: " + nbApple;

        textNbGold.text = "Number Of Gold :" + nbGold;
    }
}
