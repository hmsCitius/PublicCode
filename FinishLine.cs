using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLine : MonoBehaviour
{

    public GameObject WinPanel;
    public static bool isFinish;

    private void Awake()
    {
        isFinish = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            WinPanel.SetActive(true);
            isFinish = true;
        }
    }

    
}
