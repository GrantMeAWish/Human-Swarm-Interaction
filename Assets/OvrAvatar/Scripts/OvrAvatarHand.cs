using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class OvrAvatarHand : MonoBehaviour
{
    GameObject interBall; 
    void Start()
    {
       interBall = GameObject.FindGameObjectWithTag("interactive");

    }

    private void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger) && OVRInput.Get(OVRInput.Button.PrimaryHandTrigger))
        {
            Debug.Log("PrimaryIndexTrigger");
             interBall.transform.parent = this.transform;
              interBall.transform.position = Camera.main.transform.forward+ new Vector3(0,0.5f,1f);
              interBall.GetComponent<Rigidbody>().useGravity = false;
              interBall.GetComponent<Rigidbody>().isKinematic = true;
            //globalFlock.moveCircle(); 


}
        if (OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger) && OVRInput.Get(OVRInput.Button.SecondaryHandTrigger)){
            Debug.Log("SecondaryHand");
             interBall.transform.parent = this.transform;
              interBall.transform.position = Camera.main.transform.forward + new Vector3(0, 0.5f, 1f);
              interBall.GetComponent<Rigidbody>().useGravity = false;
              interBall.GetComponent<Rigidbody>().isKinematic = true;         
            //globalFlock.goFlock(); 
        }
        if ((OVRInput.Get(OVRInput.Button.One) || OVRInput.Get(OVRInput.Button.Three)) && (interBall.transform.parent != null))
            {
            interBall.transform.parent = null;
            interBall.GetComponent<Rigidbody>().useGravity = true;
            interBall.GetComponent<Rigidbody>().isKinematic = false; 
        }
        if ((OVRInput.Get(OVRInput.Button.Two) || OVRInput.Get(OVRInput.Button.Four)) && (interBall.transform.parent != null))
        {
            Debug.Log("Button 2");
            interBall.transform.parent = null;
            interBall.GetComponent<Rigidbody>().useGravity = true;
            interBall.GetComponent<Rigidbody>().isKinematic = false;
            interBall.GetComponent<Rigidbody>().AddForce(Camera.main.transform.forward * 5000f); 
        }

    }








}