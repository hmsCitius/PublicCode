using UnityEngine;

public class TakipCube : MonoBehaviour
{
    public GameObject MainBritish;
    public GameObject MainGerman;

    public GameObject YellowBritish;
    public GameObject YellowGerman;

    public GameObject BlueBritish;
    public GameObject BlueGerman;

    public GameObject SpecialBritish;
    public GameObject SpecialGerman;

    public float Zamanlayici = 1f;

    public bool isDone;


    private void Start()
    {
        User.Karakterolustur = false;
        isDone = false;
    }




    private void LateUpdate()
    {


        if (isDone == false)
        {
            if(User.Karakterolustur == true)
            {
                Debug.Log("Karakter olusturma true oldu.");
                /*
                if (User.isCustomMaterial == true)
                {
                    GameObject BritishM = Instantiate(MainBritish, new Vector3(-0.5f, 0f, 1.2f), Quaternion.identity);
                    GameObject GermanM = Instantiate(MainGerman, new Vector3(0.5f, 0f, 1.2f), Quaternion.identity);

                    BritishM.transform.parent = GameObject.FindWithTag("Respawn").transform;
                    GermanM.transform.parent = GameObject.FindWithTag("Respawn").transform;
                }
                else if (User.isBlueMaterial == true)
                {
                    GameObject BritishB = Instantiate(BlueBritish, new Vector3(-0.5f, 0f, 1.2f), Quaternion.identity);
                    GameObject GermanB = Instantiate(BlueGerman, new Vector3(0.5f, 0f, 1.2f), Quaternion.identity);

                    BritishB.transform.parent = GameObject.FindWithTag("Respawn").transform;
                    GermanB.transform.parent = GameObject.FindWithTag("Respawn").transform;
                }
                else if (User.isYellowMaterial == true)
                {
                    GameObject BritishY = Instantiate(YellowBritish, new Vector3(-0.5f, 0f, 1.2f), Quaternion.identity);
                    GameObject GermanY = Instantiate(YellowGerman, new Vector3(0.5f, 0f, 1.2f), Quaternion.identity);

                    BritishY.transform.parent = GameObject.FindWithTag("Respawn").transform;
                    GermanY.transform.parent = GameObject.FindWithTag("Respawn").transform;
                }
                else if (User.isSpecialMaterial == true)
                {
                    GameObject BritishC = Instantiate(SpecialBritish, new Vector3(-0.5f, 0f, 1.2f), Quaternion.identity);
                    GameObject GermanC = Instantiate(SpecialGerman, new Vector3(0.5f, 0f, 1.2f), Quaternion.identity);

                    BritishC.transform.parent = GameObject.FindWithTag("Respawn").transform;
                    GermanC.transform.parent = GameObject.FindWithTag("Respawn").transform;
                }
                else
                {
                    GameObject British1 = Instantiate(MainBritish, new Vector3(-0.5f, 0f, 1.2f), Quaternion.identity);
                    GameObject German1 = Instantiate(MainGerman, new Vector3(0.5f, 0f, 1.2f), Quaternion.identity);

                    British1.transform.parent = GameObject.FindWithTag("Respawn").transform;
                    German1.transform.parent = GameObject.FindWithTag("Respawn").transform;
                }
                isDone = false;




                */

                int a = PlayerPrefs.GetInt("CharColour", 0);

                if (a == 0)
                {
                    GameObject BritishM = Instantiate(MainBritish, new Vector3(-0.5f, 0f, 1.2f), Quaternion.identity);
                    GameObject GermanM = Instantiate(MainGerman, new Vector3(0.5f, 0f, 1.2f), Quaternion.identity);

                    BritishM.transform.parent = GameObject.FindWithTag("Respawn").transform;
                    GermanM.transform.parent = GameObject.FindWithTag("Respawn").transform;
                }
                else if (a == 2)
                {
                    GameObject BritishB = Instantiate(BlueBritish, new Vector3(-0.5f, 0f, 1.2f), Quaternion.identity);
                    GameObject GermanB = Instantiate(BlueGerman, new Vector3(0.5f, 0f, 1.2f), Quaternion.identity);

                    BritishB.transform.parent = GameObject.FindWithTag("Respawn").transform;
                    GermanB.transform.parent = GameObject.FindWithTag("Respawn").transform;
                }
                else if (a == 1)
                {
                    GameObject BritishY = Instantiate(YellowBritish, new Vector3(-0.5f, 0f, 1.2f), Quaternion.identity);
                    GameObject GermanY = Instantiate(YellowGerman, new Vector3(0.5f, 0f, 1.2f), Quaternion.identity);

                    BritishY.transform.parent = GameObject.FindWithTag("Respawn").transform;
                    GermanY.transform.parent = GameObject.FindWithTag("Respawn").transform;
                }
                else if (a == 3)
                {
                    GameObject BritishC = Instantiate(SpecialBritish, new Vector3(-0.5f, 0f, 1.2f), Quaternion.identity);
                    GameObject GermanC = Instantiate(SpecialGerman, new Vector3(0.5f, 0f, 1.2f), Quaternion.identity);

                    BritishC.transform.parent = GameObject.FindWithTag("Respawn").transform;
                    GermanC.transform.parent = GameObject.FindWithTag("Respawn").transform;
                }
                else
                {
                    GameObject British1 = Instantiate(MainBritish, new Vector3(-0.5f, 0f, 1.2f), Quaternion.identity);
                    GameObject German1 = Instantiate(MainGerman, new Vector3(0.5f, 0f, 1.2f), Quaternion.identity);

                    British1.transform.parent = GameObject.FindWithTag("Respawn").transform;
                    German1.transform.parent = GameObject.FindWithTag("Respawn").transform;
                }

                isDone = true;


            }









        }


    }
}
