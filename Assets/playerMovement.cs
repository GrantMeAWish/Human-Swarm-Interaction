﻿using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

    public float speed = 5.0F;
    public float rotateSpeed = 5.0F;

    public float deadzoneX = 0.2F;
    public float deadzoneY = 0.2F;

    CharacterController controller;

    // Use this for initialization
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        //grab frame input
        float moveX = Input.GetAxis("Mouse X");
        float moveY = Input.GetAxis("Mouse Y");

        //define local vectors
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 backward = transform.TransformDirection(Vector3.back);
        Vector3 left = transform.TransformDirection(Vector3.left);
        Vector3 right = transform.TransformDirection(Vector3.right);

        //initialize movement for frame; default to nothing
        Vector3 movement = Vector3.zero;

        //handle X translation
        if (moveX > deadzoneX)
        {
            movement += left;
        }
        else if (moveX < -deadzoneX)
        {
            movement += right;
        }

        //handle Y translation
        if (moveY > deadzoneY)
        {
            movement += forward;
        }
        else if (moveY < -deadzoneY)
        {
            movement += backward;
        }

        //move!
        controller.SimpleMove(movement * speed);
    }
}