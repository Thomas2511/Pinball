using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartChuteDoor : MonoBehaviour {

    public GameObject parent;

    void OnEnable()
    {
        GameManager.ResetBall += BallIsReset;
        BallDetector.BallIsInPlay += BallInPlay;
    }

    void OnDisable()
    {
        GameManager.ResetBall -= BallIsReset;
        BallDetector.BallIsInPlay -= BallInPlay;
    }

    void BallIsReset()
    {
        StartCoroutine(MoveDoor(false));
    }

    void BallInPlay()
    {
        StartCoroutine(MoveDoor(true));
    }

    IEnumerator MoveDoor(bool close)
    {

        Vector3 relativePos = parent.transform.InverseTransformPoint(this.transform.position);

        if (close)
        {
            while (relativePos.y > 0.25f)
            {
                this.transform.Translate(-Vector3.up * Time.deltaTime);
                relativePos = parent.transform.InverseTransformPoint(this.transform.position);
                yield return new WaitForSeconds(0.02f);
            }
        }
        else
        {
            while (relativePos.y < 0.75f)
            {
                this.transform.Translate(Vector3.up * Time.deltaTime);
                relativePos = parent.transform.InverseTransformPoint(this.transform.position);
                yield return new WaitForSeconds(0.02f);
            }
        }
    }
}
