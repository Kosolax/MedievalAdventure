using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManagerQuest : MonoBehaviour
{
    ManagerBdd managerBdd;

    public Text textTitle;
    public Text textTextChoose;
    public Text textTitleFinish;


    public Text textTitleCurrent;

    public Inventory inventory;

    public Text textSuccessQuest;

    // Start is called before the first frame update
    void Start()
    {
        managerBdd = new ManagerBdd();
    }

    public void buttonAccept()
    {
        managerBdd.updateData(managerBdd.id[0],1);

        buttonChooseQuest();
    }

    public void buttonChooseQuest()
    {
        managerBdd.FindDataQuest();

        textTitle.text = "" + managerBdd.title[0];
        textTextChoose.text = "" + managerBdd.text[0];
    }

    public void buttonCurrentQuest()
    {
        textTitleCurrent.text = "";

        for (int i=1; i <= managerBdd.FindCurrentQuest(); i++)
        {
            textTitleCurrent.text += "Quest " + i + ": " + managerBdd.title[i - 1] + '\n';
        }
    }

    public void buttonFinishQuest()
    {
        textTitleFinish.text = "";

        for (int i = 1; i <= managerBdd.FindFinishQuest(); i++)
        {
            textTitleFinish.text += "Quest Finish " + i + ": " + managerBdd.title[i - 1] + '\n';
        }
    }

    public bool SuccessQuest()
    {
       for(int i = 1; i <= managerBdd.FindCurrentQuest(); i++)
        {
            if(inventory.nbApple >= managerBdd.numberPrefab[i-1])
            {
                managerBdd.updateData(managerBdd.id[i-1],2);
                inventory.nbApple -= managerBdd.numberPrefab[i - 1];

                inventory.nbGold += managerBdd.gain[i - 1];

                textSuccessQuest.text = "Success you gain is : " + managerBdd.gain[i-1];

                return true;
            }
        }

        return false;
    }






}
