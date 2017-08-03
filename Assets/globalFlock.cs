﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class globalFlock : MonoBehaviour {
    GameObject ball; 
	//read in the bug and goal prefabs
	public GameObject bugPrefab;
	public GameObject goalPrefab;

	//instantiating colony box dimensions
	public static int colonySize = 30;
    
    //instantiating the swarm colony
    static int numBugs = 100;
	public static GameObject[] allBugs = new GameObject[numBugs];

	//instantiating goal position
	public static Vector3 goalPos = Vector3.zero;

    //distance from camera to destination point
    public float cameraDist;

    //instantiating speed boundaries
    public float lowerBound;
    public float upperBound;

    //set bug speedMult to be the slider's multiplier
    public void BugSpeed(float speedMult) 
    {
        Debug.Log(speedMult);

		for (int i = 0; i < numBugs; i++) {
			allBugs[i].GetComponent<flock>().lowerBound = speedMult + 0.5f;
			allBugs[i].GetComponent<flock>().upperBound = speedMult + 1f;
            allBugs[i].GetComponent<flock>().rotSpeed = speedMult + 1f;
        }
    }

    public static void moveCircle()
    {
        for(int i = 0; i < numBugs; i += 1)
        {
            allBugs[i].GetComponent<flock>().enabled = false;
            allBugs[i].GetComponent<moveCircle>().enabled = true;
        }
    }

    public static void goFlock()
    {
        for (int i = 0; i < numBugs; i += 1)
        {
            allBugs[i].GetComponent<flock>().enabled = true;
            allBugs[i].GetComponent<moveCircle>().enabled = false;  
        }
    }

    // Use this for initialization
    void Start()
	{
        ball = GameObject.FindGameObjectWithTag("ball");

        for (int i = 0; i < numBugs; i += 1)
		{
			Vector3 pos = new Vector3(Random.Range(-colonySize + transform.position.x, transform.position.x + colonySize),
									  Random.Range(-colonySize + transform.position.y , colonySize + transform.position.y),
									  Random.Range(-colonySize + transform.position.z, colonySize + transform.position.z));
            allBugs[i] = (GameObject)Instantiate(bugPrefab, pos, Quaternion.identity);
			allBugs[i].GetComponent<flock>().lowerBound = lowerBound;
			allBugs[i].GetComponent<flock>().upperBound = upperBound;
            allBugs[i].AddComponent<playAudio>();
            allBugs[i].AddComponent<moveCircle>();
            allBugs[i].GetComponent<moveCircle>().enabled = false;   

        }
	}

	// Update is called once per frame
	void Update()
	{
        /*
        //move goal to another location within the colony at random timeframes
        if (Random.Range(0, 10000) < 50)
		{
			goalPos = new Vector3(Random.Range(-colonySize, colonySize),
									  Random.Range(-colonySize, colonySize),
									  Random.Range(-colonySize, colonySize));
            goalPrefab.transform.position = goalPos;
        } */
        /*
        //allow bugs to follow user-controlled goal marker
        goalPos = goalPrefab.transform.position; */

        //allow bugs to follow camera view
        //goalPos = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, cameraDist));
        goalPos = ball.transform.position; 
    }
}
