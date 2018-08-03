using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameController : MonoBehaviour {

    public bool isNoFood = true;
    public GameObject Food;
    public GameObject Snakes;
    public GameObject Snake;
    public GameObject PauseUI;
    public GameObject GameOverMenu;
    public Text ScoreText;
    public Text HighScoreText;

    private GameObject snakes;
    private SnakeController snakeController;
    private List<Vector3> snakeLocation;
    private bool isPause = false;
    private bool isLose = false;
    

	// Use this for initialization
	void Start () {
        snakes = GameObject.Find("Snakes");
        snakeController = snakes.gameObject.GetComponent<SnakeController>();
        StartGame();
	}

    void Update()
    {
        if (isNoFood) {
            isNoFood = false;
            AddFood();
        }

        if(Input.GetKeyDown(KeyCode.P) && !isLose)
        {
            StopOrResumeGame();
        }
    }

    public void StartGame()
    {
        Time.timeScale = 1;
        isLose = false;
        Destroy(GameObject.Find("Food(Clone)"));
        isNoFood = true;
        for (int i = Snakes.transform.childCount - 1; i >= 0; i--)
        {
            Destroy(Snakes.transform.GetChild(i).gameObject);
        }

        GameObject snake = Instantiate(Snake, new Vector3(Random.Range(-5, 5) + 0.5f, Random.Range(-5, 5) + 0.5f, 0), new Quaternion());
        snake.transform.SetParent(Snakes.transform);
    }
    
    public void StopOrResumeGame()
    {
        PauseUI.SetActive(!isPause);
        Time.timeScale = isPause ? 1 : 0;
        snakeController.isPress = isPause ? false : true;
        isPause = !isPause;
    }

    public void Lose()
    {
        Time.timeScale = 0;
        isLose = true;
        GameOverMenu.SetActive(true);

        int score = GameObject.Find("Snakes").transform.childCount;
        int highScore = PlayerPrefs.GetInt("HighScore", 0);
        highScore = highScore > score ? highScore : score;
        ScoreText.text = "Your score is " +  score.ToString();
        HighScoreText.text = "Your high score is " + highScore.ToString();
        PlayerPrefs.SetInt("HighScore", highScore);    
    }

    public void EnterMainMenu()
    {
        SceneManager.LoadScene("MainMenuScene");
    }

    public void Exit()
    {
        Application.Quit();
    }

    private void AddFood()
    {
        float xPosition = 0;
        float yPosition = 0;
        bool isFinish = false;

        snakeLocation = snakeController.snakeLocation;
        while (!isFinish)
        {
            xPosition = Random.Range(-5, 5) + 0.5f ;
            for(int i = 0; i<snakeLocation.Count; i++)
            {
                if(xPosition == snakeLocation[i].x)
                {
                    break;
                }
            }
            isFinish = true;
        }

        isFinish = false;
        while (!isFinish)
        {
            yPosition = Random.Range(-5, 5) + 0.5f;
            for (int i = 0; i < snakeLocation.Count; i++)
            {
                if (yPosition == snakeLocation[i].y)
                {
                    break;
                }
            }
            isFinish = true;
        }

        Instantiate(Food, new Vector3(xPosition, yPosition, 0),new Quaternion());

    }
}
