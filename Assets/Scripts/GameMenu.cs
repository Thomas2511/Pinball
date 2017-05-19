using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour {

    public delegate void RestartAction();
    public static event RestartAction Restart;

    void OnEnable() {
        GameManager.GameOver += OpenMenu;
    }

    void OnDisable() {
        GameManager.GameOver -= OpenMenu;
    }

    public void OpenMenu() {
        if (this.GetComponent<CanvasGroup>().alpha == 1) {
            this.GetComponent<CanvasGroup>().alpha = 0;
            this.GetComponent<CanvasGroup>().interactable = false;
            this.GetComponent<CanvasGroup>().blocksRaycasts = false;
            Time.timeScale = 1;
        }
        else {
            this.GetComponent<CanvasGroup>().alpha = 1;
            this.GetComponent<CanvasGroup>().interactable = true;
            this.GetComponent<CanvasGroup>().blocksRaycasts = true;
            Time.timeScale = 0;
        }
    }

    public void RestartGame() {
        Time.timeScale = 1;
        SceneManager.LoadScene("UbisoftFlipper");
    }

    public void ExitGame() {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }
}
