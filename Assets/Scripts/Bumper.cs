using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bumper : MonoBehaviour {

    public float bumperForce;
    public int bumperValue;
    public AudioClip sound;

	void OnCollisionEnter (Collision hit)
    {
        if (hit.gameObject.tag == "Ball") {
            foreach (ContactPoint c in hit.contacts)
            {
                GameManager.Instance.score += bumperValue;
                c.otherCollider.GetComponent<Rigidbody>().AddForce(-1 * c.normal * bumperForce, ForceMode.Impulse);
                GameManager.Instance.PlayAudioClip(sound);
            }
        }
    }
}
