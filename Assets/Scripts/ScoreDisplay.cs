using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour {

	void Start () {
        this.GetComponent<Text>().text = 0.ToString();
	}
	
	void Update () {
        this.GetComponent<Text>().text = GameManager.Instance.score.ToString();
    }
}
