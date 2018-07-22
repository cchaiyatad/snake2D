using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class snakeController : MonoBehaviour {

    public GameObject snake;
    public float period = 0.5f;

    private float[] currentMovement = { 0, 1 };
    private Vector3 currentPosition;
    private int lastCount;
    private float nextActionTime = 0.0f;

    void Update()
    {

        if (Time.time > nextActionTime)
        {
            nextActionTime = period + Time.time;

            currentPosition = this.gameObject.transform.GetChild(0).position;
            lastCount = this.gameObject.transform.childCount - 1;

            Destroy(this.gameObject.transform.GetChild(lastCount).gameObject);

            UpdateSnake(new Vector3(currentPosition.x + currentMovement[0], currentPosition.y + currentMovement[1], currentPosition.z));

        }
    }

    void UpdateSnake(Vector3 vector3)
    {
        GameObject newSnake = Instantiate(snake, vector3, transform.rotation) as GameObject;
        newSnake.transform.SetParent(this.transform);
        newSnake.transform.SetAsFirstSibling();
    }

}

