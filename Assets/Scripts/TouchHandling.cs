using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchHandling : MonoBehaviour {

	bool _isBallInPlay;
    bool _isBallMoving;
	bool _gameOver;
	float _power;
	Vector2 _startPos;

	public List<Flipper> leftFlipper;
	public PowerBar powerBar;
	public List<Flipper> rightFlipper;

	void Start () {
		_isBallInPlay = false;
        _isBallMoving = false;
        _gameOver = false;
	}
		
	void OnEnable() {
		GameManager.ResetBall += ResetBallInPlay;
        BallDetector.BallIsInPlay += BallInPlay;
		GameManager.GameOver += GameIsOver;
        GameMenu.Restart += RestartGame;
	}

	void OnDisable() {
		GameManager.ResetBall -= ResetBallInPlay;
        BallDetector.BallIsInPlay -= BallInPlay;
        GameManager.GameOver -= GameIsOver;
        GameMenu.Restart -= RestartGame;
    }

	void ResetBallInPlay() {
		_isBallInPlay = false;
        foreach (Flipper f in leftFlipper)
        {
            f.ResetFlipper();
        }
        foreach (Flipper f in rightFlipper)
        {
            f.ResetFlipper();
        }
    }

    void BallInPlay() {
        _isBallInPlay = true;
    }

	void GameIsOver() {
		_gameOver = true;
	}

    void RestartGame() {
        _gameOver = false;
    }

	void Update () {
        //If game is over no more Input is registered
		if (_gameOver) {
			return;
		}

        //Testing if ball is moving to prevent multiple ball AddForce
        if (GameManager.Instance.ball.GetComponent<Rigidbody>().velocity.magnitude > 0.1f) {
            _isBallMoving = true;
        }
        else {
            _isBallMoving = false;
        }

        if (_isBallInPlay) {
			ActivateFlippers ();
		}
		else if (!_isBallMoving && !_isBallInPlay) {
            SpringWindUp ();
		}

	}

	void ActivateFlippers () {

        //Mouse Input for quick testing
        /*if (Input.GetMouseButtonDown(0))
        {
            foreach (Flipper f in leftFlipper)
            {
                f.ActivateFlipper();
            }
        }
        if (Input.GetMouseButtonDown(1))
        {
            foreach (Flipper f in rightFlipper)
            {
                f.ActivateFlipper();
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            foreach (Flipper f in leftFlipper)
            {
                f.ResetFlipper();
            }
        }
        if (Input.GetMouseButtonUp(1))
        {
            foreach (Flipper f in rightFlipper)
            {
                f.ResetFlipper();
            }
        }*/
        //End Mouse Input for quick testing

        //Flipper activation on tap
        foreach (Touch t in Input.touches) {
            switch (t.phase) {
                case TouchPhase.Began:
                    if (t.position.x < (Screen.width / 2.0f)) {
                        foreach (Flipper f in leftFlipper)
                        {
                            f.ActivateFlipper();
                        }
                    }
                    else if (t.position.x >= (Screen.width / 2.0f)) {
                        foreach (Flipper f in rightFlipper)
                        {
                            f.ActivateFlipper();
                        }
                    }
                    break;

                case TouchPhase.Moved:
                    break;

                case TouchPhase.Ended:
                    if (t.position.x < Screen.width / 2.0f) {
                        foreach (Flipper f in leftFlipper)
                        {
                            f.ResetFlipper();
                        }
                    }
                    else if (t.position.x >= Screen.width / 2.0f) {
                        foreach (Flipper f in rightFlipper)
                        {
                            f.ResetFlipper();
                        }
                    }
                    break;

            }
        }

	}

	void SpringWindUp () {
		
        //Mouse Input for quick testing
        /*if (Input.GetMouseButtonDown(0)) {
            _startPos = Input.mousePosition;
        }
        if (Input.GetMouseButton(0)) {
            _power = Mathf.Clamp(Mathf.Abs(Input.mousePosition.y - _startPos.y) * 0.1f, 0.0f, 60.0f);
            powerBar.GetComponent<PowerBar>().UpdatePowerBar(_power);
        }
        if (Input.GetMouseButtonUp(0)) {
            _power = Mathf.Clamp(Mathf.Abs(Input.mousePosition.y - _startPos.y) * 0.1f, 0.0f, 60.0f);
            GameManager.Instance.explosionEffect.GetComponent<ParticleSystem>().Play();
            GameManager.Instance.PlayAudioClip(GameManager.Instance.explosion);
            GameManager.Instance.ball.GetComponent<Rigidbody>().AddForce(Vector3.forward * _power, ForceMode.Impulse);
        }*/
        //End Mouse Input for quick testing

        //Touch to ball power
        if (Input.touchCount == 1) {
			Touch touch = Input.GetTouch (0);

			switch (touch.phase) {
			case TouchPhase.Began:
				_startPos = touch.position;
				break;

			case TouchPhase.Moved:
				_power = Mathf.Clamp(Mathf.Abs(Input.mousePosition.y - _startPos.y) * 0.1f, 0.0f, 60.0f);
                powerBar.GetComponent<PowerBar>().UpdatePowerBar (_power);
				break;

			case TouchPhase.Ended:
                GameManager.Instance.explosionEffect.GetComponent<ParticleSystem>().Play();
                GameManager.Instance.PlayAudioClip(GameManager.Instance.explosion);
                GameManager.Instance.ball.GetComponent<Rigidbody>().AddForce(Vector3.forward * _power, ForceMode.Impulse);
                break;
			}
		}

	}

}
