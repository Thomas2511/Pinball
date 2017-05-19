using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallDetector : MonoBehaviour {

    public delegate void BallInPlayAction();
    public static event BallInPlayAction BallIsInPlay;

    void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.tag == "Ball" && BallIsInPlay != null)
        {
            BallIsInPlay();
        }
    }
}
