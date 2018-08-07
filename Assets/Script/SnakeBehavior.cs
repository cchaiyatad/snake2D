using UnityEngine;

public class SnakeBehavior : MonoBehaviour {

    private GameObject snakes;
    private GameObject gameController;

    private SnakeController snakeController;
    private GameController gameControllerScript;

	void Start () {
        snakes = GameObject.Find("Snakes");
        snakeController = snakes.GetComponent<SnakeController>();

        gameController = GameObject.Find("GameController");
        gameControllerScript = gameController.GetComponent<GameController>();
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Snake"))
        {
            gameControllerScript.Lose();
        }
        else if (collision.gameObject.CompareTag("Food"))
        {
            snakeController.isEating = true;
            gameControllerScript.isNoFood = true;
            Destroy(collision.gameObject);
            snakeController.EatFood();
        }
    }
}
