using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    public float force;
    public float radius;
    public GameObject Patlama;


    private void Start()
    {
        GetComponent<Rigidbody>().AddForce(transform.forward * 1000f);
    }


    private void OnCollisionEnter(Collision collision)
    {
        Instantiate(Patlama, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
        Vector3 explotionPos = transform.position;
        Collider[] colliders = Physics.OverlapSphere(explotionPos, radius);
        foreach(Collider collider in colliders)
        {
            Rigidbody rb = collider.GetComponent<Rigidbody>();

            
            if (rb != null)
            {
                rb.AddExplosionForce(force, explotionPos, radius, 0.05f, ForceMode.Impulse);
                if(collider.gameObject.tag == "AnaObje")
                {

                    //Destroy(collider.gameObject);
                    collider.gameObject.GetComponent<Cogaltma1>().DestroyObj();
                }
            }
        }
        Destroy(gameObject);
    }


}
