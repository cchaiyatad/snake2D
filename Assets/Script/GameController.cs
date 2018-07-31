using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public bool isNoFood = true;
    public GameObject Food;
    public GameObject Snakes;
    public GameObject Snake;

    private GameObject snakes;
    private SnakeController snakeController;
    private List<Vector3> snakeLocation;
    private bool isPause = false;
    private bool isLose = false;
    

	// Use this for initialization
	void Start () {
        snakes = GameObject.Find("Snakes");
        snakeController = snakes.gameObject.GetComponent<SnakeController>();
        StratGame();
	}

    void Update()
    {
        if (isNoFood) {
            isNoFood = false;
            AddFood();
        }

        if(Input.GetKeyDown(KeyCode.P) && !isLose)
        {
            Time.timeScale = isPause ? 1 : 0;
            snakeController.isPress = isPause ? false : true;
            isPause = !isPause;
        }
    }

    public void StratGame()
    {
        for(int i = Snakes.transform.childCount - 1; i >= 0; i--)
        {
            Destroy(Snakes.transform.GetChild(i));
        }
        GameObject snake = Instantiate(Snake, new Vector3(Random.Range(-5, 5) + 0.5f, Random.Range(-5, 5) + 0.5f, 0), new Quaternion());
        snake.transform.SetParent(Snakes.transform);
    }

    public void Lose()
    {
        Time.timeScale = 0;
        isLose = true;
        
        Debug.Log(GameObject.Find("Snakes").transform.childCount);
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
