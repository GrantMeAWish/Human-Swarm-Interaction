﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class globalFlock : MonoBehaviour {
    GameObject ball; 
	//read in the bug and goal prefabs
	public GameObject bugPrefab;
	public GameObject goalPrefab;
    int index = 0; 

    private bool isStart = true; 

	//instantiating colony box dimensions
	public static int colonySize = 50;
    
    //instantiating the swarm colony
    static int numBugs = 200;
	public static GameObject[] allBugs = new GameObject[numBugs];

    public int[] behaviorStates = {1, 2, 3, 4, 5, 6, 7, 8 }; 

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

		for (int i = 0; i < numBugs; i++) {
			allBugs[i].GetComponent<flock>().lowerBound = speedMult + 0.5f;
			allBugs[i].GetComponent<flock>().upperBound = speedMult + 1f;
        }
    }

    public void RotSpeed(float speedMult) {

        for (int i = 0; i < numBugs; i++) {
            allBugs[i].GetComponent<flock>().rotSpeed = speedMult + 1f;
        }
    }

    public void Uniformity(float neighborDist) {

        for (int i = 0; i < numBugs; i++) {
            allBugs[i].GetComponent<flock>().neighborDist = neighborDist + 1f;
        }
    }



    public void  Behavior(float behaviorType) {

        int behaviorInt = (int) behaviorType;

        switch (behaviorInt) {
            case 1:
                BugSpeed(5f);
                RotSpeed(5f); 
                Uniformity(5f); 
                break;
            case 2:
                BugSpeed(10f);
                RotSpeed(5f);
                Uniformity(5f);
                break;
            case 3:
                BugSpeed(15f);
                RotSpeed(5f);
                Uniformity(5f);
                break;
            case 4:
                BugSpeed(20f);
                RotSpeed(8f);
                Uniformity(5f);
                break;
            case 5:
                BugSpeed(25f);
                RotSpeed(11f);
                Uniformity(5f);
                break;
            case 6:
                BugSpeed(30f);
                RotSpeed(14f);
                Uniformity(5f);
                break;
            case 7:
                BugSpeed(35f);
                RotSpeed(17f);
                Uniformity(5f);
                break;
            case 8:
                BugSpeed(40f);
                RotSpeed(22f);
                Uniformity(5f);
                break;


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
    void Start() {
        ball = GameObject.FindGameObjectWithTag("ball");

        for (int i = 0; i < numBugs; i += 1) {
            Vector3 pos = new Vector3(Random.Range(-colonySize + transform.position.x, transform.position.x + colonySize),
                                      Random.Range(-colonySize + transform.position.y, colonySize + transform.position.y),
                                      Random.Range(-colonySize + transform.position.z, colonySize + transform.position.z));
            allBugs[i] = (GameObject)Instantiate(bugPrefab, pos, Quaternion.identity);
            allBugs[i].GetComponent<flock>().lowerBound = lowerBound;
            allBugs[i].GetComponent<flock>().upperBound = upperBound;
            allBugs[i].AddComponent<playAudio>();
            allBugs[i].AddComponent<moveCircle>();
            allBugs[i].GetComponent<moveCircle>().enabled = false;

        }
        behaviorStates = ShuffleArray(behaviorStates);

        InvokeRepeating("RandomBehavior", 0f, 5f);
        
	}

    public void RandomBehavior() {
        Debug.Log("Behavior " + behaviorStates[index]);
        Behavior(behaviorStates[index]);
        index += 1; 

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

    int[] ShuffleArray(int[] array) {
        System.Random r = new System.Random();
        for (int i = array.Length; i > 0; i--) {
            int j = r.Next(i); 
            int k = array[j];
            array[j] = array[i - 1];
            array[i - 1] = k;
        }
        return array;
    }
}
