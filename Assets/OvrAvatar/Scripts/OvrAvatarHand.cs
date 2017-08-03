using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class OvrAvatarHand : MonoBehaviour
{
    GameObject ball; 
    void Start()
    {
       ball = GameObject.FindGameObjectWithTag("ball");

    }

    private void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger) && OVRInput.Get(OVRInput.Button.PrimaryHandTrigger))
        {
            Debug.Log("PrimaryIndexTrigger");
            /*  ball.transform.parent = this.transform;
              ball.transform.position = Camera.main.transform.forward+ new Vector3(0,0.5f,1f);
              ball.GetComponent<Rigidbody>().useGravity = false;
              ball.GetComponent<Rigidbody>().isKinematic = true;*/
            globalFlock.moveCircle(); 


}
        if (OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger) && OVRInput.Get(OVRInput.Button.SecondaryHandTrigger)){
            Debug.Log("SecondaryHand");
            /*  ball.transform.parent = this.transform;
              ball.transform.position = Camera.main.transform.forward + new Vector3(0, 0.5f, 1f);
              ball.GetComponent<Rigidbody>().useGravity = false;
              ball.GetComponent<Rigidbody>().isKinematic = true;*/
            globalFlock.goFlock(); 
        }
        if (OVRInput.Get(OVRInput.Button.One) || OVRInput.Get(OVRInput.Button.Three))
            {
            ball.transform.parent = null;
          /*  ball.GetComponent<Rigidbody>().useGravity = true;
            ball.GetComponent<Rigidbody>().isKinematic = false; */
        }
        if (OVRInput.Get(OVRInput.Button.Two) || OVRInput.Get(OVRInput.Button.Four))
        {
            Debug.Log("Button 2");
           /* ball.transform.parent = null;
            ball.GetComponent<Rigidbody>().useGravity = true;
            ball.GetComponent<Rigidbody>().isKinematic = false;
            ball.GetComponent<Rigidbody>().AddForce(Camera.main.transform.forward * 100f); */ 
        }

    }








}