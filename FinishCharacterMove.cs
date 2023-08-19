using UnityEngine;

public class FinishCharacterMove : MonoBehaviour
{
    public float CharacterSpeed = 30f;
    public static bool FinishCharacterFinish;
    public static int FinishCarpan;


    private void Start()
    {
        FinishCharacterFinish = false;
        FinishCarpan = 1;
        transform.rotation = Quaternion.identity;
    }

    private void Update()
    {
        transform.Translate(Vector3.forward * CharacterSpeed * Time.deltaTime);
        if (transform.position.x <= -2.30f)
        {
            transform.position = new Vector3(-2.30f, transform.position.y, transform.position.z);
        }
        else if (transform.position.x >= 1.95f)
        {
            transform.position = new Vector3(1.95f, transform.position.y, transform.position.z);
        }

        if (FinishCharacterFinish == true)
        {
            CharacterSpeed = 0f;
            GetComponent<Animator>().SetBool("Finishchest", true);
        }
            
        

    }


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "FinishEnemy")
        {
            GetComponent<Cogaltma1>().DestroyObj();
        }
        if(collision.gameObject.tag == "FinishChest")
        {
            collision.gameObject.GetComponent<Animator>().SetBool("Finish", true);
            FinishCharacterFinish = true;
        }


        if(collision.gameObject.tag == "2x")
        {
            FinishCarpan = 2;
            
        }
        if (collision.gameObject.tag == "3x")
        {
            FinishCarpan = 3;
            
        }
        if (collision.gameObject.tag == "4x")
        {
            FinishCarpan = 4;
            
        }
        if (collision.gameObject.tag == "5x")
        {
            FinishCarpan = 5;
            
        }

    }

}