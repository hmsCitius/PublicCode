using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cogaltma1 : MonoBehaviour
{

    public GameObject obje;



    public GameObject DestroyObject1;

    public GameObject CreateParticle;

    
   








    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Cogaltici")
        {
            
            GameObject FriendObj = Instantiate(obje, new Vector3(transform.position.x + Random.Range(-1f, 1f),
                transform.position.y,
                transform.position.z + Random.Range(-0.2f, 0.2f)),
                Quaternion.identity);
            FriendObj.transform.parent = GameObject.FindWithTag("Respawn").transform;
            Destroy(collision.gameObject);

            GameObject particle = Instantiate(CreateParticle, new Vector3(FriendObj.gameObject.transform.position.x ,
                FriendObj.gameObject.transform.position.y,
                FriendObj.gameObject.transform.position.z +1f),
                Quaternion.identity);
            Destroy(particle, 0.5f);
            
            

        }

        if (collision.gameObject.tag == "Mermi")
        {
            Destroy(collision.gameObject);
            DestroyObj();
        }

        if (collision.gameObject.tag == "Destroy")
        {
            DestroyObj();
        }

        
    }

    public void DestroyObj()
    {
        Instantiate(DestroyObject1, new Vector3(transform.position.x,
            transform.position.y,
            transform.position.z),
            Quaternion.identity);
        Destroy(gameObject);
    }



    private void LateUpdate()
    {
        if(transform.position.z >= 434)
        {
            gameObject.GetComponent<FinishCharacterMove>().enabled = true;
            gameObject.GetComponent<CharacterMove>().enabled = false;
            gameObject.GetComponent<FireScript>().enabled = false;
            GetComponent<Animator>().SetTrigger("FinishDancce");
        }
    }





}
