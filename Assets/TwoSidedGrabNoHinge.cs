using UnityEngine;
using System.Collections;

public class TwoSidedGrabNoHinge: MonoBehaviour
{

    private DetectGrabbableObject grab1;
    private DetectGrabbableObject grab2;

    public GameObject grabbedObject;

    public bool grabbing;

    private ThrowScript throwScript;

    // Use this for initialization
    void Start()
    {
        throwScript = GetComponent<ThrowScript>();
        grab1 = transform.FindChild("LRotationBase").GetComponentInChildren<DetectGrabbableObject>();
        grab2 = transform.FindChild("RRotationBase").GetComponentInChildren<DetectGrabbableObject>();

    }

    // Update is called once per frame
    void Update()
    {

        if (grabbing && grab1.currentlyGrabbedObject && grab1.currentlyGrabbedObject == grab2.currentlyGrabbedObject)
        {   
            grabbedObject = grab1.currentlyGrabbedObject;
            grabbedObject.transform.SetParent(GameObject.Find("Grabber").transform);
            grabbedObject.GetComponent<Rigidbody>().isKinematic = true;

            throwScript.StartTrackingObject(grabbedObject);
        }

        if (!grabbing && grabbedObject)
        {   
            grabbedObject.transform.SetParent(null);
            grabbedObject.GetComponent<Rigidbody>().isKinematic = false;
            throwScript.ThrowObject();
            throwScript.StopTrackingObject();
            grabbedObject = null;
        }

    }




}
