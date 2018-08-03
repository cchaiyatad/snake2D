using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour {

    public Text HighScoreText;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OpenGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void SetHighScoreText()
    {
        int highScore = PlayerPrefs.GetInt("HighScore", 0);
        HighScoreText.text = "Your high score is " + highScore.ToString();
    }

    public void ResetHighScore()
    {
        PlayerPrefs.DeleteKey("HighScore");
        SetHighScoreText();
    }

    public void Exit()
    {
        Application.Quit();
    }
}
