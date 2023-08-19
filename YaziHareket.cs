using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YaziHareket : MonoBehaviour
{
    private bool ileri = false;
    private float zaman;

    private void Start()
    {
        ileri = true;
        zaman = 1f;
    }
    void Update()
    {
        if (ileri)
        {
            zaman -= Time.deltaTime;
            if(zaman >= 0)
            {
                transform.Translate(Vector3.back * 1f * Time.deltaTime);
            }
            else
            {
                ileri = false;
                zaman = 1;
            }
        }
        else
        {
            zaman -= Time.deltaTime;
            if (zaman >= 0)
            {
                transform.Translate(Vector3.forward * 1f * Time.deltaTime);
            }
            else
            {
                ileri = true;
                zaman = 1;
            }
        }
    }
}
