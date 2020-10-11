using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PullBoulder : MonoBehaviour
{
    public GameObject soundScript;

    public GameObject pullBoulder;
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
            Vector3 targetx;
            targetx.x = this.transform.position.x;
            Vector3 targetz;
            targetz.z = this.transform.position.z;

            Vector3 target = new Vector3(targetx.x, pullBoulder.transform.position.y, targetz.z);
            pullBoulder.transform.position = Vector3.MoveTowards(transform.position ,target, soundScript.GetComponent<ListenIn>().ourLevel);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Boulders")
        {
            pullBoulder = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Boulders")
        {
            pullBoulder = null;
        }
    }
}
