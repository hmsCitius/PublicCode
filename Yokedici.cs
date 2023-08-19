using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Yokedici : MonoBehaviour
{
    
    void Start()
    {
        foreach (Transform child in transform)
        {
            if (child.tag == "Cop")
            {
                Destroy(child.gameObject);
            }
        }
    }

    
}
