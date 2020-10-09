using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushonBoulder : MonoBehaviour
{
    public GameObject soundScript;
    public bool inTriger;

    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
 
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (inTriger == true && soundScript.GetComponent<ListenIn>().ourLevel > 2)
        {
            if (player.transform.eulerAngles.y == 0 || player.transform.eulerAngles.y == 360 || player.transform.eulerAngles.y == -360)
            {
                print("0");
                this.transform.Translate(0, 0, soundScript.GetComponent<ListenIn>().ourLevel);
            }
            else if (player.transform.eulerAngles.y == 180)
            {
                print("180");
                this.transform.Translate(0, 0, -soundScript.GetComponent<ListenIn>().ourLevel);
            }
            else if (player.transform.eulerAngles.y == 90 || player.transform.eulerAngles.y == -270)
            {
                print("90");
                this.transform.Translate(soundScript.GetComponent<ListenIn>().ourLevel, 0, 0);
            }
            else if (player.transform.eulerAngles.y == 270 || player.transform.eulerAngles.y == -90)
            {
                print("270");
                this.transform.Translate(-soundScript.GetComponent<ListenIn>().ourLevel, 0, 0);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {

            inTriger = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            inTriger = false;
        }
    }
}
