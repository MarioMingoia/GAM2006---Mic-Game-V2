﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform target;
    public float smoothTime = 0.3f;

    private Vector3 velocity = Vector3.zero;
    private void Start()
    {
        target = GameObject.Find("Player").transform;
    }

    void Update()
    {
        Vector3 goalPos = target.position;
        goalPos.y = transform.position.y;
        transform.position = Vector3.SmoothDamp(transform.position, goalPos, ref velocity, smoothTime);
    }
}
