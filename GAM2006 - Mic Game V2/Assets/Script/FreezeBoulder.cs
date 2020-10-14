using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public class FreezeBoulder : MonoBehaviour
{
    public GameObject soundScript;
    public float countdown;
    public List<Rigidbody> boulderRB;

    public bool active;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<BoxCollider>().enabled = true;
        if (soundScript.GetComponent<ListenIn>().ourLevel >= 3 && active == false)
        {
            countdown = soundScript.GetComponent<ListenIn>().ourLevel * 2;
        }
        if (countdown >= 0)
        {
            countdown -= Time.deltaTime;
            active = true;
            foreach (Rigidbody a in boulderRB)
            {
                a.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY;
                print("freeze");
            }

        }

        else if (countdown <= 0)
        {
            active = false;
            foreach (Rigidbody a in boulderRB)
            {
                a.GetComponent<Rigidbody>().constraints = ~RigidbodyConstraints.FreezePositionY;
                print("unfreeze");
                boulderRB.Remove(a);
            }
        }
       
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Boulders")
        {
            boulderRB.Add (other.gameObject.GetComponent<Rigidbody>());
            boulderRB = boulderRB.Distinct().ToList();
        }
    }

}
