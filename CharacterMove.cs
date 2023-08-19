using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour
{
    [SerializeField] private float CharacterSpeed;
    /*
    public DynamicJoystick dynamicJoystick;
    
    */


    Touch parmak;
    Rigidbody rb;
    public float turnSpeed = 3;
    
    [Header("Limit RotY")]
    [SerializeField] private float maxYRot = 15f;
    [SerializeField] private float minYRot = -15f;
    
    

    private void Awake()
    {
        CharacterSpeed = 8f;
        rb = GetComponent<Rigidbody>();

    }
    
    private void LimitRot()
    {
        Vector3 headEulerAngles = transform.rotation.eulerAngles;
        headEulerAngles.y = (headEulerAngles.y > 180) ? headEulerAngles.y - 360 : headEulerAngles.y;
        headEulerAngles.y = Mathf.Clamp(headEulerAngles.y, minYRot, maxYRot);







        transform.rotation = Quaternion.Euler(headEulerAngles);
    }
    
    




    private void FixedUpdate()
    {


        transform.Translate(Vector3.forward * CharacterSpeed * Time.deltaTime);
        

        
        if (Input.touchCount > 0)
        {
            parmak = Input.GetTouch(0);





            if(gameObject.tag == "Takip")
            {
                return;
            }
            else
            {
                if (parmak.phase == TouchPhase.Moved)
                {

                    transform.position = new Vector3(transform.position.x + parmak.deltaPosition.x * 0.15f * Time.deltaTime,
                        transform.position.y,
                        transform.position.z);





                    transform.Rotate(new Vector3(
                    0f,
                    transform.rotation.y + parmak.deltaPosition.x * 0.05f, 0f
                    ));
                    LimitRot();



                }

                else
                {
                    transform.rotation = Quaternion.identity;
                }
            }
            

        }


        if (Input.GetKey("a"))
        {



            GetLeft();



        }
        else if (Input.GetKey("d"))
        {

            

            GetRight();

        }

        else
        {
            transform.rotation = Quaternion.identity;
        }


    }


    public void GetRight()
    {


        transform.Translate(Vector3.right * 5f * Time.deltaTime);

    }

    public void GetLeft()
    {

        transform.Translate(Vector3.left * 5f * Time.deltaTime);
       


    }

}














/*

using UnityEngine;
using UnityEngine.AI;

public class CharacterMove : MonoBehaviour
{
    private float CharacterSpeed;

    public float Zaman;

    public Quaternion rotation = Quaternion.identity;

    public DynamicJoystick dynamicJoystick;
    public float rotateHorizontal;
    public float RotateSpeed;

    Touch parmak;

    public NavMeshAgent nv;
    
    [Header("Limit RotY")]
    [SerializeField]private float maxYRot = 45f;
    [SerializeField]private float minYRot = -45f;
    

    private void Start()
    {
        //InvokeRepeating("Deneme", 0f, 1f);
        nv = GetComponent<NavMeshAgent>();
        //Destroy(nv);
        CharacterSpeed = 10f;
        //dynamicJoystick = FindObjectOfType<DynamicJoystick>();
    }
    
    private void LimitRot()
    {
        Vector3 headEulerAngles = transform.rotation.eulerAngles;
        headEulerAngles.y = (headEulerAngles.y > 180) ? headEulerAngles.y - 360 : headEulerAngles.y;
        headEulerAngles.y = Mathf.Clamp(headEulerAngles.y, minYRot, maxYRot);







        transform.rotation = Quaternion.Euler(headEulerAngles);
    }
    
    public void Deneme()
    {
        
        Debug.Log(dynamicJoystick.Horizontal);
    }



    private void FixedUpdate()
    {
        
        transform.Translate(Vector3.forward * CharacterSpeed * Time.deltaTime);
        
        
        if(transform.position.x >= -186.8f)
        {
            transform.position = new Vector3(-186.7f, transform.position.y,transform.position.z);
            
        }
        else if (transform.position.x <= -191.6f)
        {
            transform.position = new Vector3(-191.5f, transform.position.y, transform.position.z);
        }
        else
        {
            return;
        }
        

        
        

        if (transform.position.x <= -2.30f)
        {
            transform.position = new Vector3(-2.30f, transform.position.y, transform.position.z);
        }
        else if (transform.position.x >= 1.95f)
        {
            transform.position = new Vector3(1.95f, transform.position.y, transform.position.z);
        }

        
        if(dynamicJoystick.Horizontal < 0.30 && dynamicJoystick.Horizontal > -0.30)
        {
            transform.rotation = Quaternion.identity;
        }
        else
        {
            
            rotateHorizontal = dynamicJoystick.Horizontal;
            transform.Rotate(0, rotateHorizontal, 0);
            LimitRot();
        }
        
        
        
        
        


        if (Input.touchCount > 0 && Input.touchCount < 2)
        {
            
            parmak = Input.GetTouch(0);
            rotateHorizontal = parmak.deltaPosition.x * RotateSpeed * Time.deltaTime;
            transform.Rotate(0f, rotateHorizontal, 0f);
            

            
            rotateHorizontal = dynamicJoystick.Horizontal;
            transform.Rotate(0, rotateHorizontal, 0);
            LimitRot();
            


            rotateHorizontal = dynamicJoystick.Horizontal * 5f;
            transform.Rotate(0, rotateHorizontal, 0);
            

            
            if (parmak.phase == TouchPhase.Moved)
            {
                transform.position = new Vector3(transform.position.x + parmak.deltaPosition.x,
                    transform.position.y,
                    transform.position.z);
                
                transform.Rotate(new Vector3(
                transform.rotation.x,
                transform.rotation.y + parmak.deltaPosition.x * 0.25f, 0f
                ));
                
                LimitRot();
            }
            

        }
        
        else
        {
            transform.rotation = Quaternion.identity;
        }
        
        

        
        if(parmak.deltaPosition.x > 50.0f)
        {
            sag = true;
            sol = false;
            Zaman -= Time.deltaTime;
            if (Zaman > 0)
            {
                transform.Rotate(new Vector3(0f, 10f, 0f) * 4f * Time.deltaTime);
            }
            else
            {
                Zaman = 1.2f;
            }
        }
        else if(parmak.deltaPosition.x < -50.0f)
        {
            sol = true;
            sag = false;
            Zaman -= Time.deltaTime;
            if(Zaman > 0)
            {
                transform.Rotate(new Vector3(0f, -10f, 0f) * 4f * Time.deltaTime);
            }
            else
            {
                Zaman = 1.2f;
            }
        }
        else
        {
            transform.rotation = Quaternion.identity;
        }
        

        
        else
        {
            transform.rotation = Quaternion.identity;
        }
        










        if (Input.GetKey("a"))
        {
            
            Debug.Log(Zaman);
            Zaman -= Time.deltaTime;
            

            GetLeft();



        }
        else if (Input.GetKey("d"))
        {
            
            Debug.Log(Zaman);
            Zaman -= Time.deltaTime;
            

            GetRight();

        }
                
        else
        {
            transform.rotation = Quaternion.identity;
        }
       


        
        if (Input.GetKeyUp("a"))
        {
            transform.rotation = Quaternion.identity;
        }
        else if (Input.GetKeyUp("d"))
        {
            transform.rotation = Quaternion.identity;
        }

        






    }

    public void GetRight()
    {

        
        //transform.Rotate(new Vector3(0f, 10f, 0f) * 50f * Time.deltaTime);


    }

    public void GetLeft()
    {

        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0f, -20f, 0), .5f);
        //transform.Rotate(new Vector3(0f, -10f, 0f) * 50f * Time.deltaTime);



    }


}



***** FÝXED UPDATE ÝÇÝNE ATILACAK KOD
*
*
*
        
        transform.Translate(Vector3.forward * CharacterSpeed * Time.deltaTime);
        Debug.Log(dynamicJoystick.Horizontal);

        if(dynamicJoystick.Horizontal > 0.30f)
            {
            transform.Translate(Vector3.right * CharacterSpeed / 2 * Time.deltaTime);
        }
            else if (dynamicJoystick.Horizontal < -0.30f)
        {
            transform.Translate(Vector3.left * CharacterSpeed / 2 * Time.deltaTime);
        }

        if (Input.touchCount > 0)
        {
            parmak = Input.GetTouch(0);


            



            if (parmak.phase == TouchPhase.Moved)
            {
                
                transform.position = new Vector3(transform.position.x + parmak.deltaPosition.x * 0.05f * Time.deltaTime,
                    transform.position.y,
                    transform.position.z);
                
                


                /*
                transform.Rotate(new Vector3(
                0f,
                transform.rotation.y + parmak.deltaPosition.x * 0.05f, 0f
                ));

                LimitRot();
                
                }
            /*
            else
            {
                transform.rotation = Quaternion.identity;
            }
            */
/*         
 }


 if (Input.GetKey("a"))
{
transform.Translate(Vector3.left * 5f * Time.deltaTime);

}
if (Input.GetKey("d"))
{
transform.Translate(Vector3.right * 5f * Time.deltaTime);

}

*/


