using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class User : MonoBehaviour
{

    public static long User_Coin;
    public static int Level;


    public GameObject Settings;
    private bool SettingsTrue = false;


    public Text Gemtxt;
    public static int UserGem;

    [Header("Text Panel")]
    public Text Level_WinPanel;
    public Text Level_LosePanel;
    public Text Leveltxt;



    [Header("Main Panel Button")]
    public GameObject DailyButtonObj;
    public GameObject BonusButtonObj;
    public GameObject OutfitsButtonObj;

    public static bool Ates = true;
    public float AtesTime = 1f;
    public static bool ReklamÝzleme;


    [Header("Materials")]
    public static bool isCustomMaterial;
    public static bool isYellowMaterial;
    public static bool isBlueMaterial;
    public static bool isSpecialMaterial;

    [Header("Materials2")]
    public Material CustomMaterial;
    public Material YellowMaterial;
    public Material BlueMaterial;
    public Material SpecialMaterial;


    public static int isYellowOpen;
    public static int isBlueOpen;
    public static int isSpecialOpen;


    public Text ReklamText;
    public static int KalanReklam;

    public static bool isGameReturn = false;




    public static Material CharacterMaterial;

    public static bool Karakterolustur;

    public int CharColourInt;

    public GameObject Gem;

    public static int ReklamsizInt;



    //public DynamicJoystick dynamicJoystick;



    private void Start()
    {
        UserGem = PlayerPrefs.GetInt("GemKey", 0);

        //dynamicJoystick = FindObjectOfType<DynamicJoystick>();

        //floatingJoystick = FindObjectOfType<FloatingJoystick>();
        Time.timeScale = 0;


        User.Level = PlayerPrefs.GetInt("Level", 1);
        Leveltxt.text = "Level: " + User.Level + "";

        Level_WinPanel.text = "Level: " + (User.Level + 1) + "";
        Level_LosePanel.text = "Level: " + User.Level + "";


        ReklamÝzleme = false;
        Karakterolustur = false;
        CharColourInt = PlayerPrefs.GetInt("CharColour", 0);
        if (CharColourInt == 0)
        {
            isCustomMaterial = true;
            isYellowMaterial = false;
            isBlueMaterial = false;
            isSpecialMaterial = false;
        }
        else if (CharColourInt == 1)
        {
            isCustomMaterial = false;
            isYellowMaterial = true;
            isBlueMaterial = false;
            isSpecialMaterial = false;
        }
        if (CharColourInt == 2)
        {
            isCustomMaterial = false;
            isYellowMaterial = false;
            isBlueMaterial = true;
            isSpecialMaterial = false;
        }
        else if (CharColourInt == 3)
        {
            isCustomMaterial = false;
            isYellowMaterial = false;
            isBlueMaterial = false;
            isSpecialMaterial = true;
        }




    }

    private void LateUpdate()
    {

        AtesTime -= Time.deltaTime;
        if (AtesTime <= 0)
        {
            Ates = true;
            AtesTime = 1f;
        }
        else
        {
            Ates = false;
        }

        if (isCustomMaterial == true)
        {
            CharacterMaterial = CustomMaterial;
        }
        else if (isYellowMaterial == true)
        {
            CharacterMaterial = YellowMaterial;
        }
        else if (isBlueMaterial == true)
        {
            CharacterMaterial = BlueMaterial;
        }
        else if (isSpecialMaterial == true)
        {
            CharacterMaterial = SpecialMaterial;
        }
        else
        {
            return;
        }

        if (Input.GetMouseButton(1))
        {
            GameStopStart();
        }


        KalanReklam = PlayerPrefs.GetInt("ReklamKey", 10);
        ReklamText.text = ("If you watch " + KalanReklam + " more ads, you can unlock clothes.");




        isYellowOpen = PlayerPrefs.GetInt("YellowKey", 0);
        isBlueOpen = PlayerPrefs.GetInt("BlueKey", 0);
        isSpecialOpen = PlayerPrefs.GetInt("SpecialKey", 0);

        ReklamsizInt = PlayerPrefs.GetInt("ReklamsizIntKey", 3);

        Gemtxt.text = UserGem + "";

    }





    public static void CustomSkin()
    {
        isCustomMaterial = true;
        isYellowMaterial = false;
        isBlueMaterial = false;
        isSpecialMaterial = false;
        PlayerPrefs.SetInt("CharColour", 0);

    }
    public static void YellowSkin()
    {
        isCustomMaterial = false;
        isYellowMaterial = true;
        isBlueMaterial = false;
        isSpecialMaterial = false;
        PlayerPrefs.SetInt("CharColour", 1);
        if (isYellowOpen == 0)
        {
            PlayerPrefs.SetInt("ReklamKey", 10);
        }
        PlayerPrefs.SetInt("YellowKey", 1);
    }
    public static void BlueSkin()
    {
        isCustomMaterial = false;
        isYellowMaterial = false;
        isBlueMaterial = true;
        isSpecialMaterial = false;
        PlayerPrefs.SetInt("CharColour", 2);
        if (isBlueOpen == 0)
        {
            PlayerPrefs.SetInt("ReklamKey", 10);
        }
        PlayerPrefs.SetInt("BlueKey", 1);

    }
    public static void SpecialSkin()
    {
        isCustomMaterial = false;
        isYellowMaterial = false;
        isBlueMaterial = false;
        isSpecialMaterial = true;
        PlayerPrefs.SetInt("CharColour", 3);
        PlayerPrefs.SetInt("SpecialKey", 1);
    }








    // Butonlar

    public void RetryScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


    public void GameStopStart()
    {

        if (Time.timeScale == 0) // Oyun durdurulmuþsa devam ettir
        {
            isGameReturn = true;
            Time.timeScale = 1;
            GameObject.Find("Play_Button").SetActive(false);
            //GameObject.Find("Bonus_Button").SetActive(false);
            GameObject.Find("Outfits_Button").SetActive(false);
            //floatingJoystick.SetActive(true);
            //dynamicJoystick.GetComponent<Image>().raycastTarget = enabled;
            if (!Karakterolustur)
            {
                Karakterolustur = true;
            }
           



        }
        else // Durdurulmamýþsa durdur
        {
            Time.timeScale = 0;
            isGameReturn = false;
            
        }

    }




    public void Sound()
    {
        if (PlayerPrefs.GetInt("SoundKey", 1) == 1)
        {
            GameObject Cam = GameObject.FindGameObjectWithTag("MainCamera");
            AudioListener al = Cam.GetComponent<AudioListener>();
            al.enabled = true;
            PlayerPrefs.SetInt("SoundKey", 0);
        }
        else
        {
            GameObject Cam = GameObject.FindGameObjectWithTag("MainCamera");
            AudioListener al = Cam.GetComponent<AudioListener>();
            al.enabled = false;
            PlayerPrefs.SetInt("SoundKey", 1);
        }

    }

    public static void Menu()
    {
        int a = SceneManager.GetActiveScene().buildIndex;
        if (a != 8)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);



            User.Level += 1;
            PlayerPrefs.SetInt("Level", User.Level);

            UserGem += GemCube.GemToplam * FinishCharacterMove.FinishCarpan;
            PlayerPrefs.SetInt("GemKey", UserGem);

        }
        else
        {
            SceneManager.LoadScene(0);


            User.Level += 1;
            PlayerPrefs.SetInt("Level", User.Level);

            UserGem += GemCube.GemToplam * FinishCharacterMove.FinishCarpan;
            PlayerPrefs.SetInt("GemKey", UserGem);
        }





    }

    public static void ReklamsizMenu()
    {
        int a = SceneManager.GetActiveScene().buildIndex;
        if (a != 8)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

            User.Level += 1;
            PlayerPrefs.SetInt("Level", User.Level);

            ReklamsizInt -= 1;
            PlayerPrefs.SetInt("ReklamsizIntKey", ReklamsizInt);
            Debug.Log(ReklamsizInt);
        }
        else
        {
            SceneManager.LoadScene(0);

            User.Level += 1;
            PlayerPrefs.SetInt("Level", User.Level);

            ReklamsizInt -= 1;
            PlayerPrefs.SetInt("ReklamsizIntKey", ReklamsizInt);
            Debug.Log(ReklamsizInt);
        }





    }






    public void SoundButton()
    {
        if (SettingsTrue == false)
        {
            Settings.transform.GetChild(0).gameObject.SetActive(true);

            SettingsTrue = true;

        }
        else
        {
            Settings.transform.GetChild(0).gameObject.SetActive(false);

            SettingsTrue = false;
        }
    }


    public void DailyButton()
    {
        DailyButtonObj.SetActive(true);
    }
    public void DailyButtonExit()
    {
        DailyButtonObj.SetActive(false);
    }



    public void BonusButton()
    {
        BonusButtonObj.SetActive(true);
    }
    public void BonusButtonExit()
    {
        BonusButtonObj.SetActive(false);
    }

    public void OutfitsButton()
    {
        OutfitsButtonObj.SetActive(true);
    }
    public void OutfitsButtonExit()
    {
        OutfitsButtonObj.SetActive(false);
    }

    public void BonusOdul()
    {
        UserGem += Random.Range(400, 650);
        PlayerPrefs.SetInt("GemKey", User.UserGem);
        Gemtxt.text = UserGem + "";
        Time.timeScale = 0;
    }



    public void SpecialSkinNoAdsButton()
    {
        GameObject SpecialObj = GameObject.Find("SoldierBritish 6");
        Debug.Log(SpecialObj);
        Debug.Log("RequestRewardAds();Oyuncuya odul verildi.");
        Time.timeScale = 0;
        SpecialObj.GetComponent<FCP_ExampleScript>().MainRenk();

    }



    // Butonlar Bitis
}














