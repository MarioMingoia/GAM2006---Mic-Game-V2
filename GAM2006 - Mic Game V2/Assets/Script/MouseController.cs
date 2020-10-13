﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;


public class MouseController : MonoBehaviour
{
    public List<GameObject> pushScript;
    public MonoBehaviour freezeScript;
    public MonoBehaviour pullScript;

    public int count;

    public RawImage freeze;
    public RawImage pull;
    public RawImage push;
    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject fooObj in GameObject.FindGameObjectsWithTag("Boulders"))
        {
            pushScript.Add(fooObj);
            fooObj.GetComponent<PushonBoulder>().enabled = true;
        }

        freezeScript = GameObject.FindGameObjectWithTag("Player").GetComponent<FreezeBoulder>();
        pullScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PullBoulder>();
        }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            count--;
            print(count);
           

            print("left");

        }
        else if (Input.GetMouseButtonDown(1))
        {
            count++;
            print(count);
            
            print("right");
        }
        if (count == 0)
        {
            count = 3;
        }
        if (count == 1)
        {
            foreach (GameObject fooObj in pushScript)
            {
                pushScript = pushScript.Distinct().ToList();
                pushScript.Add(fooObj);
                fooObj.GetComponent<PushonBoulder>().enabled = true;
            }
            pullScript.enabled = false;
            freezeScript.enabled = false;
            push.enabled = true;
            pull.enabled = false;
            freeze.enabled = false;

        }
        else if (count ==2)
        {
            foreach (GameObject fooObj in pushScript)
            {
                pushScript = pushScript.Distinct().ToList();
                pushScript.Add(fooObj);
                fooObj.GetComponent<PushonBoulder>().enabled = false;
            }
            pullScript.enabled = true;
            freezeScript.enabled = false;
            push.enabled = false;
            pull.enabled = true;
            freeze.enabled = false;
        }
        else if (count == 3)
        {
            foreach (GameObject fooObj in pushScript)
            {
                pushScript = pushScript.Distinct().ToList();
                pushScript.Add(fooObj);
                fooObj.GetComponent<PushonBoulder>().enabled = false;
            }
            pullScript.enabled = false;
            freezeScript.enabled = true;
            push.enabled = false;
            pull.enabled = false;
            freeze.enabled = true;
        }
        if (count == 4)
        {
            count = 1;
        }
    }
}
