using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Oculus.Platform;
using Oculus.Platform.Models;

public class PlayerController : PlatformManager {

    //secondary camera to debug and view scene from above
    public Camera spyCamera;

    //OVRCameraRig for the main player so we can disable it
    private GameObject cameraRig;

    private bool showUI = true;

    public override void Awake()
    {
        base.Awake();
        cameraRig = localPlayerHead.gameObject;
    }

    // Use this for initialization
    public override void Start ()
    {
        OVRManager.instance.trackingOriginType = OVRManager.TrackingOrigin.EyeLevel;
        base.Start();
        spyCamera.enabled = false;
    }

    // Update is called once per frame
    public override void Update ()
    {
        base.Update();
        checkInput();
    }

    // Check for input from the touch controllers
    void checkInput()
    {
        if (UnityEngine.Application.platform == RuntimePlatform.Android) 
        {
            // GearVR Controller

            //bring up friend invite list
            if (OVRInput.GetDown(OVRInput.Button.Back)) 
            {
                Rooms.LaunchInvitableUserFlow(roomManager.roomID);
            }
            
            //toggle camera
            if (OVRInput.GetDown(OVRInput.Button.PrimaryTouchpad)) 
            {
                ToggleCamera();
            }

            //toggle help UI
            if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger)) 
            {
                ToggleUI();
            }
        }
        else 
        {
            // PC Touch 

            //bring up friend invite list
            if (OVRInput.GetDown(OVRInput.Button.Three)) 
            {
                Rooms.LaunchInvitableUserFlow(roomManager.roomID);
            }
            
            //toggle camera
            if (OVRInput.GetDown(OVRInput.Button.Four)) 
            {
                ToggleCamera();
            }

            //toggle help UI
            if (OVRInput.GetDown(OVRInput.Button.PrimaryThumbstick)) 
            {
                ToggleUI();
            }
        }
    }

    void ToggleCamera()
    {
        spyCamera.enabled = !spyCamera.enabled;
        localAvatar.ShowThirdPerson = !localAvatar.ShowThirdPerson;
        cameraRig.SetActive(!cameraRig.activeSelf);
    }

    void ToggleUI()
    {
        showUI = !showUI;
        helpPanel.SetActive(showUI);
        localAvatar.ShowLeftController(showUI);
    }
}
