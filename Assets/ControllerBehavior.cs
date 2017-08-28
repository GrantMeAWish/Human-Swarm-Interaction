using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ControllerBehavior : MonoBehaviour {

    /*initialize attributes of camera-rig
        * path: absolute path of txt file to write to
        * OLDPos: previous y position  
        * NEWyPos: current y position
        * start: when to start invokeing writeToText method*/

    string path = "C:\\Users\\Hiro\\alextest\\Assets\\BehaviorData\\ControllerData.csv";

    bool start = true;

    GameObject leftController;
    GameObject rightController;
    GameObject headset;

    Vector3 leftContPos;
    Vector3 rightContPos;
    Vector3 headsetPos;

    // Use this for initialization
    void Start() {
        leftController = GameObject.Find("hand_left");
        rightController = GameObject.Find("hand_right");
        headset = GameObject.Find("CenterEyeAnchor");

        leftContPos = leftController.transform.position;
        rightContPos = rightController.transform.position;
        headsetPos = headset.transform.position;
    }

    // Update is called once per frame
    void Update() {
        if (start) {
            start = false;
            InvokeRepeating("write", 0f, 0.5f);
        }
    }

    /* write the direction the camera is facing, and y position to txt file
     * also detects when user is crouching and writes to txt*/
    void write() {
        leftContPos = leftController.transform.position;
        rightContPos = rightController.transform.position;
        headsetPos = headset.transform.position;
        //Debug.Log("left" + leftContPos.x);
        //Debug.Log("right" + rightContPos.x);
        //Debug.Log(headsetPos);
        //Debug.Log(Mathf.Abs(leftContPos.x - rightContPos.x)); 
        if ((Mathf.Abs(leftContPos.x - rightContPos.x) <= 3) 
            && (Mathf.Abs(headsetPos.y - leftContPos.y) <= 2)
            && (Mathf.Abs(headsetPos.y - rightContPos.y) <= 2)) {
            //Debug.Log("USER IS COVERING");
        }
    }
}
