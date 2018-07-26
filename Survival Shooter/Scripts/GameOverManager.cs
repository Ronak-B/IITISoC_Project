using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour {

    public PlayerHealth playerHealth;
    public GameObject bg1;
    public GameObject bg2;
    public GameObject pauseMenu;
    public GameObject MiniMap;
    public HighScoreManager highScoreManager;

    Animator anim;
   

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if(playerHealth.getCurrentHealth()<=0)
        {
            bg1.GetComponent<AudioSource>().Stop();
            bg2.GetComponent<AudioSource>().Stop();
            pauseMenu.SetActive(false);
            MiniMap.SetActive(false);
            anim.SetTrigger("GameOver");
            if(ScoreManager.score>PlayerPrefs.GetInt("HighScore"))
            {
                PlayerPrefs.SetInt("HighScore", ScoreManager.score);
                highScoreManager.text.text = "High Score:" + ScoreManager.score.ToString();
            }
            if(Input.GetKeyDown(KeyCode.Escape))
            {
                SceneManager.LoadScene("MainMenu");
            }
            
        }
    }
}
