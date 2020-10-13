using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enterAreaPull : MonoBehaviour
{

    public GameObject MainCam;
    public GameObject pullCam;
    // Start is called before the first frame update
    void Start()
    {
        MainCam = GameObject.Find("MainCamera");
        pullCam = GameObject.Find("Pullcamera");
        pullCam.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "2ndCam")
        {
            MainCam.gameObject.SetActive(false);
            pullCam.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "2ndCam")
        {
            MainCam.gameObject.SetActive(true);
            pullCam.gameObject.SetActive(false);
        }
    }
}
