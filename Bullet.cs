using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Bullet : MonoBehaviour
{
    


    private void Start()
    {
        Destroy(gameObject, 0.5f);
    }

    



    void Update()
    {
        transform.Translate(Vector3.forward * 75f * Time.deltaTime);
    }

}