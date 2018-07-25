using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeController : MonoBehaviour {

    public GameObject snake;
    public float period = 0.5f;

    private float[] currentMovement = { 0, 1 };
    private Vector3 currentPosition;
    private int lastCount;
    private float nextActionTime = 0.0f;

    void Update()
    { 
        if (currentMovement[0] == 0)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                currentMovement[0] = -1;
                currentMovement[1] = 0;
                UpdateSnake();
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow)) 
            {
                currentMovement[0] = 1;
                currentMovement[1] = 0;
                UpdateSnake();
            }
        }

        else if (currentMovement[1] == 0)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                currentMovement[0] = 0;
                currentMovement[1] = 1;
                UpdateSnake();
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                currentMovement[0] = 0;
                currentMovement[1] = -1;
                UpdateSnake();
            }
        }

        if (Time.time > nextActionTime)
        {
            UpdateSnake();            
        }
        
    }

    void UpdateSnake()
    {
        nextActionTime = period + Time.time;

        currentPosition = this.gameObject.transform.GetChild(0).position;
        lastCount = this.gameObject.transform.childCount - 1;

        Destroy(this.gameObject.transform.GetChild(lastCount).gameObject);

        float newXPosition = Mathf.Abs(currentPosition.x + currentMovement[0]) <= 4.5 ? currentPosition.x + currentMovement[0] : -1 * currentPosition.x;
        float newYPosition = Mathf.Abs(currentPosition.y + currentMovement[1]) <= 4.5 ? currentPosition.y + currentMovement[1] : -1 * currentPosition.y;

        GameObject newSnake = Instantiate(snake, new Vector3(newXPosition, newYPosition, currentPosition.z), transform.rotation) as GameObject;
        newSnake.transform.SetParent(this.transform);
        newSnake.transform.SetAsFirstSibling();
    }

}

