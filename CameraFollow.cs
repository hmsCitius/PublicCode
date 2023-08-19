using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public GameObject FollowObject;
    public Vector3 DistanceObject;
    public Vector3 FinishDistanceObject;
    public Transform Hedef;
    public static bool Finish = false;

    

    private void Start()
    {
        FollowObject = GameObject.FindGameObjectWithTag("Takip");
        Finish = false;
    }

    private void LateUpdate()
    {
        if(Finish == true)
        {
            if(FinishCharacterMove.FinishCharacterFinish == false)
            {
                FollowObject = GameObject.FindGameObjectWithTag("AnaObje");
            }
            else
            {
                FollowObject = GameObject.FindGameObjectWithTag("FinishChest");
                FinishDistanceObject = new Vector3(0, 12, -35f);
            }
            

        }

        
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "CameraFinish")
        {
            Finish = true;
           
        }
    }
    


    private void FixedUpdate()
    {
        if(Finish == false)
        {
            if(CharacterControl.CharacterCount > 0)
            {
                this.transform.position = Vector3.Lerp(this.transform.position, FollowObject.transform.position + DistanceObject, Time.fixedDeltaTime);
            }
            else
            {
                gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
                Debug.Log("False Kod");
            }
            
            
        }
        else
        {
            this.transform.position = Vector3.Lerp(this.transform.position, FollowObject.transform.position + FinishDistanceObject, Time.fixedDeltaTime);
            transform.rotation = Quaternion.Euler(10f, 0f, 0f);
            if(FollowObject == null)
            {
                gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
                Debug.Log("Kod");
            }
            
        }        
    }

}
