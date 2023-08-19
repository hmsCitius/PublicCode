using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayGame : MonoBehaviour
{

    public List<GameObject> characters = new List<GameObject>();

    [SerializeField] private GameObject Controller;

    public static bool isGame;

    [Header("Music")]
    [SerializeField] private GameObject MusicGameObject;
    [SerializeField] private GameObject GamePlayMusicGameObject;
    private void Awake()
    {
        isGame = false;
    }

    public void GameStart()
    {
        int characterint = PlayerPrefs.GetInt("playercharacter", 0);

        Controller.SetActive(true);
        isGame = true;
        MusicGameObject.SetActive(false);
        GamePlayMusicGameObject.SetActive(true);
        


        for(int i = 0; i< GetComponent<ChangeCharacter>().CharacterHolderGameObject.transform.childCount; i++)
        {
            if(i == characterint)
            {
                Instantiate(characters[i], new Vector3(10.5f, 2.30f, -6.72f), Quaternion.identity);

            }
        }


    }




}
