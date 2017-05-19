using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighestScore : MonoBehaviour {

	void Start () {
        if (PlayerPrefs.HasKey("HighestScore")) {
            this.GetComponent<Text>().text = "Highest Score: " + PlayerPrefs.GetInt("HighestScore").ToString();
            this.GetComponent<CanvasGroup>().alpha = 1;
        }
        else {
            this.GetComponent<CanvasGroup>().alpha = 0;
        }
	}
}
