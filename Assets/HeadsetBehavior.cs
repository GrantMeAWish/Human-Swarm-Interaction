using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class HeadsetBehavior : MonoBehaviour {

    /*initialize attributes of camera-rig
     * path: absolute path of txt file to write to
     * OLDPos: previous y position  
     * NEWyPos: current y position
     * start: when to start invokeing writeToText method*/

    string path = "C:\\Users\\Hiro\\alextest\\Assets\\BehaviorData\\HeadsetData.csv";
    float OLDyPos;
    float NEWyPos;
    bool start = true;
    string isCrouch = "F";
    Vector3 camDirec;

	// Use this for initialization
	void Start () {
        StreamWriter sw  = File.CreateText(path);
        sw.WriteLine("Time, Y Position, Is Ducking, X Direction, Y Direction, Z Direction");
        OLDyPos = this.transform.position.y;
        NEWyPos = this.transform.position.y;
        camDirec = this.transform.forward;
        sw.Close();
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
        StreamWriter sw = File.AppendText(path);
        NEWyPos = this.transform.position.y;
        if (NEWyPos - OLDyPos <= -2f) {
            //sw.WriteLine("User is ducking");
            Debug.Log("USER IS DUCKING!");
            isCrouch = "T";
        } else {
            isCrouch = "F";
        }

        sw.WriteLine(Time.time + "," + NEWyPos + "," + isCrouch + "," + camDirec.x + "," 
            + camDirec.y + "," + camDirec.z);

      
        OLDyPos = NEWyPos;
        sw.Close(); 

    }
}
