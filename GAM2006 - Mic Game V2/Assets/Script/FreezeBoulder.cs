using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeBoulder : MonoBehaviour
{
    public GameObject soundScript;

    public Rigidbody boulderRB;
    public float countdown;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (soundScript.GetComponent<ListenIn>().ourLevel >= 1)
        {
            if (boulderRB != null)
            {
                boulderRB.useGravity = false;
            }          
        }
        if (boulderRB == null)
        {
            boulderRB.useGravity = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Boulders")
        {
            boulderRB = other.gameObject.GetComponent<Rigidbody>();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Boulders")
        {
            boulderRB = null;
        }
    }
}
