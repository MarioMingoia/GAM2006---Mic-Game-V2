using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnBoulder : MonoBehaviour
{
    public Vector3 RespawnPoint;
    public bool isDead;

    public Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        RespawnPoint = this.transform.position;
        rb = this.gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead == true)
        {
            rb.constraints = RigidbodyConstraints.FreezeAll;
            transform.position = RespawnPoint;
            rb.constraints = ~RigidbodyConstraints.FreezePositionY;
            isDead = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "KillPlayer")
        {
            isDead = true;
        }
    }
}
