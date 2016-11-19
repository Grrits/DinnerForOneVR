namespace VRTK.Examples
{
    using UnityEngine;

    public class Grabby : VRTK_InteractableObject
    {
        public HingeJoint grabbyR, grabbyL;
        public TwoSidedGrab g;
        public bool grabbing;

        public override void StartUsing(GameObject usingObject)
        {
            base.StartUsing(usingObject);
            Grab();
        }

        public override void StopUsing(GameObject usingObject)
        {
            base.StopUsing(usingObject);
            Ungrab();
        }

        protected override void Start()
        {
            base.Start();
            grabbyR = GameObject.Find("GrabbyR").gameObject.GetComponent<HingeJoint>();
            grabbyL = GameObject.Find("GrabbyL").gameObject.GetComponent<HingeJoint>();
            
        }

        private void Grab()
        {
            g.grabbing = true;
            Debug.Log("PRESS");
            JointMotor jr = grabbyR.motor;
            JointMotor jl = grabbyL.motor;
            jr.force = 200;
            jl.force = 200;
            jr.targetVelocity = 500;
            jl.targetVelocity = -500;
            jr.freeSpin = false;
            jl.freeSpin = false;
            grabbyR.motor = jr;
            grabbyL.motor = jl;
            grabbyR.useMotor = true;
            grabbyL.useMotor = true;
        }

        private void Ungrab()
        {
            g.grabbing = false;
            Debug.Log("UNPRESS");
            JointMotor jr = grabbyR.motor;
            JointMotor jl = grabbyL.motor;
            jr.force = 100;
            jl.force = 100;
            jr.targetVelocity = -90;
            jl.targetVelocity = 90;
            jr.freeSpin = false;
            jl.freeSpin = false;
            grabbyR.motor = jr;
            grabbyL.motor = jl;
            grabbyR.useMotor = true;
            grabbyL.useMotor = true;
        }
    }
}