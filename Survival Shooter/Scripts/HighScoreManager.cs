using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreManager : MonoBehaviour {

    public Text text;
	void Awake () {
        text = GetComponent<Text>();
        text.text ="High Score:"+ PlayerPrefs.GetInt("HighScore", 0).ToString();
	}
	
}
