using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamChange : MonoBehaviour
{

    public Camera Main;
    public Camera pullCam;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "2ndCam")
        {
            Main.enabled = false;
            pullCam.enabled = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "2ndCam")
        {
            Main.enabled = true;
            pullCam.enabled = false;
        }
    }
}
