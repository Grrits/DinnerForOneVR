using UnityEngine;
using System.Collections;

public class MakePushAxisVisible : MonoBehaviour {

    private enum ControllerSide {
        left,
        right
    }

    public float triggerAxis;
    
    //public ControllerSide side;
    
    private SteamVR_TrackedObject trackedObject;

    private SteamVR_Controller.Device device;

    void Start()
    {
        trackedObject = GetComponent<SteamVR_TrackedObject>();

    }

    void Update() {
        device = SteamVR_Controller.Input((int)trackedObject.index);
        triggerAxis = device.GetAxis(Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger).x;
        float value = 1 - triggerAxis;

    }

    public float GetButtonPressAmount() {
        return triggerAxis;
    }


}
