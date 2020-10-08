using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Push : MonoBehaviour
{
    public GameObject soundScript;
    public Transform objecttoPush;
    public bool inTriger;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (inTriger == true && soundScript.GetComponent<ListenIn>().ourLevel > 1)
        {
            if (this.transform.eulerAngles.y == 0 || this.transform.eulerAngles.y == 360 || this.transform.eulerAngles.y == -360)
            {
                print("0");
                objecttoPush.Translate(0,0,soundScript.GetComponent<ListenIn>().ourLevel);
            }
            else if (this.transform.eulerAngles.y == 180)
            {
                print("180");
                objecttoPush.Translate(0, 0, -soundScript.GetComponent<ListenIn>().ourLevel);
            }
            else if (this.transform.eulerAngles.y == 90 || this.transform.eulerAngles.y == -270)
            {
                print("90");
                objecttoPush.Translate(soundScript.GetComponent<ListenIn>().ourLevel, 0, 0);
            }
            else if (this.transform.eulerAngles.y == 270 || this.transform.eulerAngles.y == -90)
            {
                print("270");
                objecttoPush.Translate(-soundScript.GetComponent<ListenIn>().ourLevel, 0, 0);
            }
        }
        if (inTriger == false)
        {
           
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Boulders")
        {
            objecttoPush = other.gameObject.transform;

            inTriger = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Boulders")
        {
            objecttoPush = null;
            inTriger = false;
        }
    }
}
