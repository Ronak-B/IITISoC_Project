using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MainMenuManager : MonoBehaviour
{
    
    public GameObject MainMenu;
    public GameObject Story;
    public GameObject Tutorial;


    public void PlayGame()
    {
        MainMenu.SetActive(false);
        Story.SetActive(true);
        Debug.Log("Check");
    }

    public void EnterGame()
    {
        SceneManager.LoadScene("level 02");
    }
    public void QuitGame()
    {
        Application.Quit();
    }

    public void Options()
    {
        MainMenu.SetActive(false);
        Tutorial.SetActive(true);
    }
	
}
