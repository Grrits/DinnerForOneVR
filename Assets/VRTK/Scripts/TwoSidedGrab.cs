using UnityEngine;
using System.Collections;

public class TwoSidedGrab : MonoBehaviour {

    private DetectGrabbableObject grab1;
    private DetectGrabbableObject grab2;
    public HingeJoint grabbyR, grabbyL;

    GameObject grabbedObject;

    public bool grabbing;

	// Use this for initialization
	void Start () {
        grab1 = transform.FindChild("GrabbyL").GetComponent<DetectGrabbableObject>();
        grab2 = transform.FindChild("GrabbyR").GetComponent<DetectGrabbableObject>();

    }
	
	// Update is called once per frame
	void Update () {

        if(grabbing && grab1.currentlyGrabbedObject && grab1.currentlyGrabbedObject == grab2.currentlyGrabbedObject)
        {
            grabbedObject = grab1.currentlyGrabbedObject;
            Debug.Log(grabbedObject);
            grabbedObject.transform.SetParent(GameObject.Find("Grabber").transform);
            Debug.Log(GameObject.Find("Grabber"));
            grabbedObject.GetComponent<Rigidbody>().isKinematic = true;
            //Grab();
        }

        if(!grabbing && grabbedObject)
        {
            grabbedObject.transform.SetParent(null);
            grabbedObject.GetComponent<Rigidbody>().isKinematic = false;
            grabbedObject = null;
        }
	
	}

    private void Grab()
    {
        JointMotor jr = grabbyR.motor;
        JointMotor jl = grabbyL.motor;
        jr.force = 0;
        jl.force = 0;
        jr.targetVelocity = 0;
        jl.targetVelocity = 0;
        jr.freeSpin = false;
        jl.freeSpin = false;
        grabbyR.motor = jr;
        grabbyL.motor = jl;
        grabbyR.useMotor = true;
        grabbyL.useMotor = true;
    }

}
