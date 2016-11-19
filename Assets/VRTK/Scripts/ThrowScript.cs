using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ThrowScript : MonoBehaviour {

    private GameObject trackedObject;

    public List<float> lastSpeeds = new List<float>();

    public List<Vector3> lastDirections = new List<Vector3>();

    private Vector3 lastFramePosition;



    //avg last 5 frames direction -> add everything and have final vector
    //avg last 10 frames speed 

    public void StartTrackingObject(GameObject obj) {
        trackedObject = obj;
        lastFramePosition = trackedObject.transform.position;
    }

    void Update()
    {
        if (trackedObject) {
                lastSpeeds.Add((trackedObject.transform.position - lastFramePosition).magnitude / Time.deltaTime);
            if(lastSpeeds.Count > 15)
            {
                lastSpeeds.RemoveAt(0);
            }

            lastDirections.Add((trackedObject.transform.position - lastFramePosition).normalized);

            if (lastDirections.Count > 10) {
                lastDirections.RemoveAt(0);
            }
        }
    }



    public void ThrowObject()
    {
        float avgSpeed = 0f;
        foreach (float speed in lastSpeeds) {
            avgSpeed += speed;
        }

        avgSpeed = Mathf.Clamp(0f, 100f, (avgSpeed / lastSpeeds.Count));

       
        Vector3 direction = Vector3.zero;
        foreach (Vector3 dir in lastDirections)
        {
            direction += dir;
        }

        direction = direction.normalized;

        Debug.Log(avgSpeed + " " + direction);

        //do the colliders block the ball sometimes? -> change layer of thrown object
        trackedObject.GetComponent<Rigidbody>().AddForce(avgSpeed * direction * 10f);

    }

    public void StopTrackingObject()
    {
        trackedObject = null;
    }
}
