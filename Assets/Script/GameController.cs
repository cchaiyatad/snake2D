using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public bool isNoFood = false;
    public GameObject Food;

    private GameObject snakes;
    private SnakeController snakeController;
    private List<Vector3> snakeLocation;
    

	// Use this for initialization
	void Start () {
        snakes = GameObject.Find("Snakes");
        snakeController = snakes.gameObject.GetComponent<SnakeController>();
	}

    void Update()
    {
        if (isNoFood) {
            isNoFood = false;
            Debug.Log("is no food");

            AddFood();
        }
    }


    public static void Lose()
    {
        Time.timeScale = 0;

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
            Debug.Log(xPosition + "x");
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
