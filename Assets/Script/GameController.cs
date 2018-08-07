using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameController : MonoBehaviour {

    public bool isNoFood = true;
    public GameObject food;
    public GameObject snakes;
    public GameObject snake;
    public GameObject pauseUI;
    public GameObject gameOverMenu;
    public Text scoreText;
    public Text highScoreText;

    private SnakeController snakeController;
    private AudioSource themeSound;
    private List<Vector3> snakeLocation;
    private bool isPause = false;
    private bool isLose = false;
    

	// Use this for initialization
	void Start () {
        snakeController = snakes.gameObject.GetComponent<SnakeController>();
        themeSound = GameObject.Find("ThemeSound").GetComponent<AudioSource>();
        themeSound.volume = 0.15f;
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
        for (int i = snakes.transform.childCount - 1; i >= 0; i--)
        {
            Destroy(snakes.transform.GetChild(i).gameObject);
        }

        isNoFood = true;
        GameObject newSnake = Instantiate(snake, new Vector3(Random.Range(-5, 5) + 0.5f, Random.Range(-5, 5) + 0.5f, 0), new Quaternion());
        newSnake.transform.SetParent(snakes.transform);
    }
    
    public void StopOrResumeGame()
    {
        pauseUI.SetActive(!isPause);
        Time.timeScale = isPause ? 1 : 0;
        snakeController.isPress = isPause ? false : true;
        themeSound.volume = isPause ? 0.15f : 0.0f;
        isPause = !isPause;
    }

    public void Lose()
    {
        Time.timeScale = 0;
        isLose = true;
        gameOverMenu.SetActive(true);

        int score = GameObject.Find("Snakes").transform.childCount;
        int highScore = PlayerPrefs.GetInt("HighScore", 0);
        highScore = highScore > score ? highScore : score;
        scoreText.text = "Your score is " +  score.ToString();
        highScoreText.text = "Your high score is " + highScore.ToString();
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

        Instantiate(food, new Vector3(xPosition, yPosition, 0),new Quaternion());

    }
}
