using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    
    private static GameManager instance = null;

    public delegate void ResetBallAction ();
	public static event ResetBallAction ResetBall;
	public delegate void GameOverAction ();
	public static event GameOverAction GameOver;

    public AudioSource audioSource;
    public GameObject ball;
    public GameObject explosionEffect;
    public AudioClip explosion;
    public Vector3 ballStartPos;
    public int lives;
    public int score;

    public static GameManager Instance
    {
        get { return instance; }
    }

    void Awake()
    {
        GetThisGameManager();
    }

    void Update () {

		if (lives == 0 && GameOver != null) {
            if ((PlayerPrefs.HasKey("HighestScore") && PlayerPrefs.GetInt("HighestScore") < score) || !PlayerPrefs.HasKey("HighestScore")) {
                PlayerPrefs.SetInt("HighestSCore", score);
                PlayerPrefs.Save();
            }

            GameOver();
		}

        if (ball.transform.position.x < -10.0f || ball.transform.position.y < -10.0f || ball.transform.position.z < -10.0f ||
            ball.transform.position.x > 10.0f || ball.transform.position.y > 10.0f || ball.transform.position.z > 10.0f) {
            lives--;
            if (lives > 0 && ResetBall != null)
            {
                ReplaceBall();
                ResetBall();
            }
            else {
                ball.SetActive(false);
            }
        }

	}

    void GetThisGameManager()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }
    }

    public void PlayAudioClip(AudioClip sound)
    {
        audioSource.PlayOneShot(sound);
    }

    public void ReplaceBall()
    {
        ball.transform.position = ballStartPos;
    }

}
