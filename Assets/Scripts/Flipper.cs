using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flipper : MonoBehaviour {

    public void ActivateFlipper()
    {
        JointMotor newMotor = new JointMotor();
        newMotor.force = 1000.0f;
        newMotor.targetVelocity = 1000.0f;

        this.GetComponent<HingeJoint>().motor = newMotor;
    }

    public void ResetFlipper()
    {
        JointMotor newMotor = new JointMotor();
        newMotor.force = 1000.0f;
        newMotor.targetVelocity = -1000.0f;

        this.GetComponent<HingeJoint>().motor = newMotor;
    }

}
