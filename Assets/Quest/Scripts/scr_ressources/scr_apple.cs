using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_apple : MonoBehaviour
{
    public Inventory inventory;
    public PNJ pnj;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        if(!pnj.inCanvas)
        {
            inventory.nbApple++;
            Destroy(this.gameObject);
        }
   
    }
}
