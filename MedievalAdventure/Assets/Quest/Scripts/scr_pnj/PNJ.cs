using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PNJ : MonoBehaviour
{
    public bool inCanvas = false;

    public GameObject interfaceQuest;

    public GameObject panelChooseQuest;

    public ManagerInterfaceQuest managerInterfaceQuest;

    public ManagerQuest managerQuest;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void OnMouseDown()
    {
        if(!inCanvas)
        {
            if (managerQuest.SuccessQuest())
            {
                managerInterfaceQuest.showSuccessQuest();
            }
            else
            {
                managerInterfaceQuest.showInterfaceQuest();
            }
        } 
    }

    public void ContinueSuccessQuest()
    {
        managerInterfaceQuest.showInterfaceQuest();
    }

 
}
