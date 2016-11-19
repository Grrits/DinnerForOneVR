namespace VRTK.Examples
{
    using UnityEngine;

    public class NoHingeGrab : VRTK_InteractableObject
    {
        public GameObject grabbyR, grabbyL;
        public TwoSidedGrabNoHinge g;
        public bool grabbing;

        Vector3 startRotationL, startRotationR;

        //public MakePushAxisVisible makePushAxisVisible;

        float lastKnownFloatForAngle = 0;
        private bool lastKnownAngleSet = false;

        protected override void Start()
        {
            base.Start();
            grabbyR = GameObject.Find("RRotationBase").gameObject;
            grabbyL = GameObject.Find("LRotationBase").gameObject;
            startRotationL = grabbyL.transform.localEulerAngles;
            startRotationR = grabbyR.transform.localEulerAngles;
        }

        protected override void FixedUpdate()
        {
            if (GetGrabbingObject())
            {
                float currentTriggerPosition = GetGrabbingObject().GetComponent<MakePushAxisVisible>().triggerAxis + 0.2f;


                //if the value is sufficiently high we assume the player wants to grab something and enable the grabbing on twosidedgrabnohinge
                if (currentTriggerPosition > 0.25f)
                {
                    g.grabbing = true;


                    if (currentTriggerPosition < lastKnownFloatForAngle && lastKnownAngleSet) {
                        g.grabbing = false;
                        lastKnownAngleSet = false;
                    }

                }
                else {
                    g.grabbing = false;
                }


                if (!g.grabbedObject)
                    {   
                        SetClawOrientation(currentTriggerPosition);
                        lastKnownFloatForAngle = currentTriggerPosition;

                } else {

                    if (!lastKnownAngleSet)
                        {
                            lastKnownAngleSet = true;
                        }
                    }

                }
        }

        void SetClawOrientation(float position) {

            //eventually set a maximum speed to steer towards the desired position! it might help with the "glitching through objects"
            grabbyL.transform.localEulerAngles = Vector3.Lerp(startRotationL, Vector3.zero, position + 0.02f);
            grabbyR.transform.localEulerAngles = - grabbyL.transform.localEulerAngles;
        }

        /*
        public override void StartUsing(GameObject usingObject)
        {
            Debug.Log("started using");
            base.StartUsing(usingObject);
            Grab();
        }

        public override void StopUsing(GameObject usingObject)
        {
            base.StopUsing(usingObject);
            Ungrab();
        }

        

        private void Grab()
        {
            g.grabbing = true;
            Debug.Log("PRESS");

            
        }

        private void Ungrab()
        {
            g.grabbing = false;
            Debug.Log("UNPRESS");
            
        }
        */



    }
}