using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuManager : MonoBehaviour {

    public bool gamePaused = false;
    public GameObject pauseMenuUI;
    public GameObject HUD;
    public GameObject Player;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gamePaused) Resume();
            else Pause();
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        gamePaused = false;
        Debug.Log("resume");
        Player.SetActive(true);
        Time.timeScale = 1f;
        HUD.SetActive(true);
    }
    public void Pause()
    {
        Player.SetActive(false);
        Time.timeScale = 0f;
        pauseMenuUI.SetActive(true);
        HUD.SetActive(false);
        gamePaused = true;

    }
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void Quit()
    {
        Application.Quit();
    }
}
