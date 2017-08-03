using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goalController : MonoBehaviour {

    //goal movement speed
    public float speed;
    public float delta = 1.5f;  // Amount to move left and right from the start point
    private Vector3 startPos;
    public static Vector3 currentPos;
    public static GameObject ball;
    public float bounds;
    Vector3 pos;
    bool start = true; 

    //apply physics to goal marker
    private Rigidbody rb;

	// Use this for initialization
	void Start () {
        pos = new Vector3(Random.Range(-bounds, bounds),
                          Random.Range(-
                          bounds, bounds),
                          Random.Range(-bounds, bounds));
        rb = GetComponent<Rigidbody>();
        startPos = transform.position; 
	}

    void Update()
    {
        if (start) {
            InvokeRepeating("randomizePos", 0f, 5f);
            start = false; 
        }

    }

    void randomizePos() {
        transform.position = pos;
        pos = new Vector3(Random.Range(-bounds, bounds),
                  Random.Range(-
                  bounds, bounds),
                  Random.Range(-bounds, bounds));
    }
}
