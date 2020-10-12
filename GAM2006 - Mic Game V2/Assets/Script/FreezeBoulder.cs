using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeBoulder : MonoBehaviour
{
    public GameObject soundScript;
    public float countdown;
    public Rigidbody boulderRB;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.GetComponent<BoxCollider>().enabled = true;
        if (soundScript.GetComponent<ListenIn>().ourLevel >= 3)
        {
            countdown = soundScript.GetComponent<ListenIn>().ourLevel * 5;
        }
        if (countdown >= 2)
        {
            countdown -= Time.deltaTime;
            boulderRB.constraints = RigidbodyConstraints.FreezeAll;

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Boulders")
        {
            boulderRB = other.gameObject.GetComponent<Rigidbody>();
        }
    }

}
