using UnityEngine;
using System.Collections;

public class DetectGrabbableObject : MonoBehaviour {

    public GameObject currentlyGrabbedObject;

    void OnTriggerEnter(Collider other) {

        if (other.gameObject.CompareTag("grabbable") && (currentlyGrabbedObject == null)) {
            currentlyGrabbedObject = other.gameObject;
        }
    }


    void OnTriggerExit(Collider other) {
        if (other.gameObject == currentlyGrabbedObject) {
            
            currentlyGrabbedObject = null;
        }
    }
}
