using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerInterfaceQuest : MonoBehaviour
{
    public GameObject panelQuest;
    public GameObject panelChooseQuest;
    public GameObject panelCurrentQuest;
    public GameObject panelFinishQuest;
    public GameObject panelSuccessQuest;

    public PNJ pnj;


    // Start is called before the first frame update
    void Start()
    {
        initCanvas();
    }

    void initCanvas()
    {
        closeInterfaceQuest();
        closeChooseQuest();
        closeFinishQuest();
        closeCurrentQuest();
        closeSuccessQuest();
    }

    // Update is called once per frame

    public void showInterfaceQuest()
    {
        pnj.inCanvas = true;
        panelQuest.SetActive(true);
        closeChooseQuest();
        closeFinishQuest();
        closeCurrentQuest();
        closeSuccessQuest();
    }

    public void closeInterfaceQuest()
    {
        pnj.inCanvas = false;
        panelQuest.SetActive(false);
    }

    public void showSuccessQuest()
    {
        panelSuccessQuest.SetActive(true);
    }

    public void closeSuccessQuest()
    {
        panelSuccessQuest.SetActive(false);
    }

    public void showChooseQuest()
    {
        panelChooseQuest.SetActive(true);
        closeInterfaceQuest();
    }

    public void closeChooseQuest()
    {
        panelChooseQuest.SetActive(false);
    }

    public void showCurrentQuest()
    {
        panelCurrentQuest.SetActive(true);
        closeInterfaceQuest();
    }

    public void closeCurrentQuest()
    {
        panelCurrentQuest.SetActive(false);
    }

    public void showFinishQuest()
    {
        panelFinishQuest.SetActive(true);
        closeInterfaceQuest();
    }

    public void closeFinishQuest()
    {
        panelFinishQuest.SetActive(false);
    }

    public void buttonBack()
    {
        showInterfaceQuest();
    }

    public void buttonQuit()
    {
        closeInterfaceQuest();
    }
}
