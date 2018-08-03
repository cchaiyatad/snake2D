using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour {

    public Text highScoreText;

    public void OpenGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void SetHighScoreText()
    {
        int highScore = PlayerPrefs.GetInt("HighScore", 0);
        highScoreText.text = "Your high score is " + highScore.ToString();
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
