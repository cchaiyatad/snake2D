using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeBehavior : MonoBehaviour {

    private GameObject snakes;
    private SnakeController snakeController;

	void Start () {
        snakes = GameObject.Find("Snakes");
        snakeController = snakes.GetComponent<SnakeController>();
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Snake"))
        {
            GameController.Lose();
        }
        else if (collision.gameObject.CompareTag("Food"))
        {
            snakeController.isEating = true;
            Destroy(collision.gameObject);
        }
    }
}
