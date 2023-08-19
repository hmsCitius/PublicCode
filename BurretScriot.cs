using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class BurretScriot : MonoBehaviour
{
    [SerializeField] private float atisMesafesi = 3f;
    
    private Transform hedef;
    [SerializeField] private Transform donecekKisim;
    


    private NavMeshAgent Agent;

    public GameObject GermanDestroyObject;
    public int can = 100;
    [SerializeField] private bool isDead;


    public GameObject Coin;

    private void DestroyObj()
    {
        GameObject y = Instantiate(GermanDestroyObject, new Vector3(transform.position.x,
            transform.position.y,
            transform.position.z), Quaternion.identity);
        Destroy(y, 1);

        GameObject x = Instantiate(Coin, new Vector3(transform.position.x + Random.Range(-0.5f, 0.5f),
            transform.position.y + 1f,
            transform.position.z), Quaternion.identity);
        Destroy(x, 0.5f);
        Destroy(gameObject);
    }
   


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            can -= 20;
        }
        if (collision.gameObject.tag == "AnaObje")
        {
            can -= 20;
        }



    }



    private void Start()
    {
        InvokeRepeating("DusmaniBul", 0f, 0.5f);
        Agent = transform.GetComponent<NavMeshAgent>();
        isDead = false;

    }
    private void Update()
    {
        if (can <= 0)
        {
            if (!isDead)
            {
                DestroyObj();
                Destroy(Agent);
                isDead = true;
            }
            
        }

        if (hedef == null) return;
        Quaternion hedefeBak = Quaternion.LookRotation(hedef.position - transform.position);
        donecekKisim.rotation = Quaternion.Euler(0f, hedefeBak.eulerAngles.y, 0f);
        
        
        if(can>= 0)
        {
            Agent.SetDestination(hedef.transform.position);
        }
        


        

    }
    
    void DusmaniBul()
    {
        string[] dusmanEtiketleri = { "AnaObje" };
        List<GameObject> dusmanlar = new List<GameObject>();
        for (int i = 0; i < dusmanEtiketleri.Length; i++)
        {
            GameObject[] dusmanlarArray = GameObject.FindGameObjectsWithTag(dusmanEtiketleri[i]);
            for (int ii = 0; ii < dusmanlarArray.Length; ii++)
            {
                dusmanlar.Add(dusmanlarArray[ii]);
            }
        }
        float enKisaMesafe = Mathf.Infinity;
        GameObject enYakinDusman = null;
        foreach (var dusman in dusmanlar)
        {
            float dusmanaUzaklik = Vector3.Distance(transform.position, dusman.transform.position);
            if (dusmanaUzaklik < enKisaMesafe)
            {
                enKisaMesafe = dusmanaUzaklik;
                enYakinDusman = dusman;
            }
        }
        if (enYakinDusman != null && enKisaMesafe <= atisMesafesi)
        {
            hedef = enYakinDusman.transform;
        }
        else hedef = null;
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, atisMesafesi);
    }
}