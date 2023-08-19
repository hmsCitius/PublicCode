using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OutfitsButton : MonoBehaviour
{

    private int KalanReklam;

    private int isYellowOpen;
    private int isBlueOpen;
    private int isSpecialOpen;
    

    void LateUpdate()
    {

        KalanReklam = PlayerPrefs.GetInt("ReklamKey", 10);

        
        

        if(KalanReklam <= 0)
        {
            for(int i = 0; i < 3; i++)
            {
                transform.GetChild(i).GetComponent<Button>().interactable = true;
            }
        }
        else
        {
            for (int i = 0; i < 3; i++)
            {
                /*
                if(User.isYellowOpen == 1)
                {
                    transform.GetChild(0).GetComponent<Button>().interactable = true;
                }
                else
                {
                    transform.GetChild(0).GetComponent<Button>().interactable = false;
                }

                if (User.isBlueOpen == 1)
                {
                    transform.GetChild(1).GetComponent<Button>().interactable = true;
                }
                else
                {
                    transform.GetChild(1).GetComponent<Button>().interactable = false;
                }

                if (User.isSpecialOpen == 1)
                {
                    transform.GetChild(2).GetComponent<Button>().interactable = true;
                }
                else
                {
                    transform.GetChild(2).GetComponent<Button>().interactable = true;
                }
                */
            }
        }
    }
}
