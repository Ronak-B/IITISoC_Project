using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class OptionsManager : MonoBehaviour {

    public AudioMixer audio;
    public GameObject MainMenu;
    public GameObject OptionsMenu;
   

    public void SetVolume(float volume)
    {
        audio.SetFloat("Volume", volume);
    }
    public void MainMenuCall()
    {
        MainMenu.SetActive(true);
        OptionsMenu.SetActive(false);
    }
}
