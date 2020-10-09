using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushonBoulder : MonoBehaviour
{
    public GameObject soundScript;
    public bool inTriger;
    public bool levelisHigh;
    public float moveSpeed;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        moveSpeed = soundScript.GetComponent<ListenIn>().ourLevel;

        if (soundScript.GetComponent<ListenIn>().ourLevel >= 2)
        {
            levelisHigh = true;
        }
        if (soundScript.GetComponent<ListenIn>().ourLevel < 2)
        {
            levelisHigh = false;
        }

        if (inTriger == true && levelisHigh == true)
        {
            if (player.transform.eulerAngles.y == 0 || player.transform.eulerAngles.y == 360 || player.transform.eulerAngles.y == -360)
            {
               // transform.Translate(0, 0, soundScript.GetComponent<ListenIn>().ourLevel);
                transform.Translate(0, 0, moveSpeed * Time.deltaTime);
            }
            else if (player.transform.eulerAngles.y == 180)
            {
               // transform.Translate(0, 0, -soundScript.GetComponent<ListenIn>().ourLevel);
                transform.Translate(0, 0, -moveSpeed * Time.deltaTime);
            }
            else if (player.transform.eulerAngles.y == 90 || player.transform.eulerAngles.y == -270)
            {
                //transform.Translate(soundScript.GetComponent<ListenIn>().ourLevel, 0, 0);
                transform.Translate(moveSpeed * Time.deltaTime, 0, 0);
            }
            else if (player.transform.eulerAngles.y == 270 || player.transform.eulerAngles.y == -90)
            {
               // transform.Translate(-soundScript.GetComponent<ListenIn>().ourLevel, 0, 0);
                transform.Translate(-moveSpeed * Time.deltaTime, 0, 0);
            }
        }
    }

    private void OnTriggerStay(Collider other)
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
