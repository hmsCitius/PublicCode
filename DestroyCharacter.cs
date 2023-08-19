using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyCharacter : MonoBehaviour
{
    private void Start()
    {
        transform.parent = GameObject.Find("DestroyCharacters").transform;
        Destroy(gameObject, 1f);
    }

    private void Update()
    {
        GetComponent<Rigidbody>().AddForce(0, 100, -100,ForceMode.Acceleration);
    }

}
