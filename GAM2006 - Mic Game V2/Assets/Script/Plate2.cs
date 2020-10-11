using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plate2 : MonoBehaviour
{
    public bool startFalling;
    public GameObject fallBoulder1;
    public Rigidbody fallBoulder1rb;
    public GameObject fallBoulder2;
    public Rigidbody fallBoulder2rb;
    // Start is called before the first frame update
    void Start()
    {
        fallBoulder1rb = fallBoulder1.GetComponent<Rigidbody>();
        fallBoulder1rb.constraints = RigidbodyConstraints.FreezeAll;
        fallBoulder2rb = fallBoulder2.GetComponent<Rigidbody>();
        fallBoulder2rb.constraints = RigidbodyConstraints.FreezeAll;
    }

    // Update is called once per frame
    void Update()
    {
        if (startFalling == true)
        {
            fallBoulder1rb.constraints = ~RigidbodyConstraints.FreezePositionY;
            fallBoulder2rb.constraints = ~RigidbodyConstraints.FreezePositionY;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            startFalling = true;
        }
    }
}
