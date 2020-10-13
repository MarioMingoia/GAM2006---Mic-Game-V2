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
        player.GetComponent<BoxCollider>().enabled = false;

        if (soundScript.GetComponent<ListenIn>().ourLevel >= 1)
        {
            levelisHigh = true;
            moveSpeed = soundScript.GetComponent<ListenIn>().ourLevel;

        }
        if (soundScript.GetComponent<ListenIn>().ourLevel < 1)
        {
            levelisHigh = false;
        }

        if (inTriger == true && levelisHigh == true)
        {
            if (player.transform.eulerAngles.y == 0 || player.transform.eulerAngles.y == 360 || player.transform.eulerAngles.y == -360)
            {
                transform.Translate(0, 0, moveSpeed * Time.deltaTime);
            }
            else if (player.transform.eulerAngles.y == 180)
            {
                transform.Translate(0, 0, -moveSpeed * Time.deltaTime);
            }
            else if (player.transform.eulerAngles.y == 90 || player.transform.eulerAngles.y == -270)
            {
                transform.Translate(moveSpeed * Time.deltaTime, 0, 0);
            }
            else if (player.transform.eulerAngles.y == 270 || player.transform.eulerAngles.y == -90)
            {
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Wall")
        {          
            GetComponent<Rigidbody>().constraints = ~RigidbodyConstraints.FreezePosition;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        float force = 30;

        // If the object we hit is the enemy
        if (collision.gameObject.tag == "Wall")
        {
            // Calculate Angle Between the collision point and the player
            Vector3 dir = collision.contacts[0].point - transform.position;
            // We then get the opposite (-Vector3) and normalize it
            dir = -dir.normalized;
            // And finally we add force in the direction of dir and multiply it by force. 
            // This will push back the player
            GetComponent<Rigidbody>().AddForce(dir * force);
            print("wall");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            inTriger = false;
        }

        if (other.gameObject.tag == "Wall")
        {

            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        }
    }
}
