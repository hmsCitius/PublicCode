using UnityEngine;


public class FireScript : MonoBehaviour
{
    
    
    
    
    [SerializeField] private Transform donecekKisim;
    [SerializeField] private GameObject mermiSablonu;
    [SerializeField] private Transform atisNoktasi;

    

    

    


    

    

    private void Update()
    {
        
        if(User.Ates == true)
        {
            AtisYap();
        }


    }
    void AtisYap()
    {
       Instantiate(mermiSablonu, atisNoktasi.position, atisNoktasi.rotation);
    }
    
    
}