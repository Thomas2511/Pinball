using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerBar : MonoBehaviour {

    public float _maxPower;

    void OnEnable()
    {
        BallDetector.BallIsInPlay += BallInPlay;
    }

    void OnDisable()
    {
        BallDetector.BallIsInPlay -= BallInPlay;
    }

    void BallInPlay()
    {
        StartCoroutine(EmptyPowerBar());
    }

    IEnumerator EmptyPowerBar()
    {
        while (this.GetComponent<Image>().fillAmount > 0.0f)
        {
            this.GetComponent<Image>().fillAmount -= 0.1f;

            SetColorFromAmount(this.GetComponent<Image>().fillAmount);

            yield return new WaitForSeconds(0.05f);
        }
    }

	public void UpdatePowerBar(float power)
    {
        float currentAmount = (power * 100.0f / _maxPower) / 100.0f;

        SetColorFromAmount(currentAmount);

        this.GetComponent<Image>().fillAmount = currentAmount;
    }

    void SetColorFromAmount(float amount)
    {
        if (amount < 0.1f) { this.GetComponent<Image>().color = new Color(1.0f, 1.0f, 0.0f); }
        else if (amount < 0.25f) { this.GetComponent<Image>().color = new Color(1.0f, 0.8f, 0.0f); }
        else if (amount < 0.5f) { this.GetComponent<Image>().color = new Color(1.0f, 0.6f, 0.0f); }
        else if (amount < 0.75f) { this.GetComponent<Image>().color = new Color(1.0f, 0.4f, 0.0f); }
        else if (amount < 1.0f) { this.GetComponent<Image>().color = new Color(1.0f, 0.2f, 0.0f); }
        else if (amount >= 1.0f) { this.GetComponent<Image>().color = new Color(1.0f, 0.0f, 0.0f); }
    }
}
