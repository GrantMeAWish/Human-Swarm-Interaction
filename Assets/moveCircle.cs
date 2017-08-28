using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveCircle : MonoBehaviour
{

    public float speed = 10f;
    public float delta = 20f;  // Amount to move left and right from the start point
    private Vector3 startPos;
    public float rotSpeed = 4.0f; 
    private Vector3 targetPos = new Vector3(0,10,50f); 
    public Vector3 currentPos;
    float x, y;
    float targetZ = 20f;
    float timeCounter;
    float targetX, targetY; 

    // Use this for initialization
    void Start()
    {
        timeCounter = Random.Range(10f, 30f); 
        speed = Random.Range(speed - 1, speed + 1);
        targetX = delta * Mathf.Cos(timeCounter);
        targetY = delta * Mathf.Sin(timeCounter) + 10;
        targetPos = new Vector3(targetX, targetY, targetZ);





    }

    // Update is called once per frame
    void Update()
    {
        if (this.transform.position.z < 30)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation,
                                      Quaternion.LookRotation(targetPos),
                                      rotSpeed * Time.deltaTime);
            transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
            //transform.LookAt(targetPos);
            //Debug.Log("Moving 30"); 
            
            
        }
        else
        {        
           // Debug.Log("Circle"); 
            timeCounter += Time.deltaTime;
            x = delta * Mathf.Cos(timeCounter * speed);
            y = delta * Mathf.Sin(timeCounter * speed);
            transform.position = new Vector3(x, y, transform.position.z);

        }

    }
}