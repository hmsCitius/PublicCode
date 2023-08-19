using UnityEngine;
using UnityEngine.UI;

public class CameraMove : MonoBehaviour
{
    public float speed;
    public UnityEngine.UI.Text Level;
    public Text Level_WinPanel;
    public Text Level_LosePanel;


    private void Start()
    {
        User.Level = PlayerPrefs.GetInt("Level");
        Level.text = "Level: "+User.Level + "";
        Level_WinPanel.text = "Level: " + User.Level + "";
        Level_LosePanel.text = "Level: " + User.Level + "";
    }



    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "CameraFinish")
        {
            User.Level += 1;
            PlayerPrefs.SetInt("Level", User.Level);
            speed = 3.5f;
            

        }
    }


    




}
