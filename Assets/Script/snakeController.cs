using System.Collections.Generic;
using UnityEngine;

public class SnakeController : MonoBehaviour {

    public GameObject snake;
    public float period = 0.5f;
    public List<Vector3> snakeLocation;
    public bool isEating = false;
    public bool isPress = false;

    private float[] currentMovement = { 0, 1 };
    private Vector3 currentPosition;
    private int lastCount;
    private float nextActionTime = 0.0f;
    private AudioSource[] sounds;
    private AudioSource turnSound;
    private AudioSource eatFoodSound;

    void Start()
    {
        sounds = GetComponents<AudioSource>();
        turnSound = sounds[0];
        eatFoodSound = sounds[1];
    }
    
    void Update()
    { 
        if(!isPress)
        {
            if (currentMovement[0] == 0)
            {
                if (Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    SetTurning(-1, 0);
                }
                else if (Input.GetKeyDown(KeyCode.RightArrow))
                {
                    SetTurning(1, 0);
                }
            }

            else if (currentMovement[1] == 0)
            {
                if (Input.GetKeyDown(KeyCode.UpArrow))
                {
                    SetTurning(0, 1);
                }
                else if (Input.GetKeyDown(KeyCode.DownArrow))
                {
                    SetTurning(0, -1);
                }
            }
        }
        

        if (Time.time > nextActionTime)
        {
            UpdateSnake();
            isPress = false;
        }
        
    }

    void UpdateSnake()
    {
        nextActionTime = period + Time.time;

        currentPosition = this.gameObject.transform.GetChild(0).position;
        lastCount = this.gameObject.transform.childCount - 1;

        if (!isEating)
        {
            Destroy(this.gameObject.transform.GetChild(lastCount).gameObject);
        }

        isEating = false;
        float newXPosition = Mathf.Abs(currentPosition.x + currentMovement[0]) <= 4.5 ? currentPosition.x + currentMovement[0] : -1 * currentPosition.x;
        float newYPosition = Mathf.Abs(currentPosition.y + currentMovement[1]) <= 4.5 ? currentPosition.y + currentMovement[1] : -1 * currentPosition.y;

        GameObject newSnake = Instantiate(snake, new Vector3(newXPosition, newYPosition, currentPosition.z), transform.rotation) as GameObject;
        newSnake.transform.SetParent(this.transform);
        newSnake.transform.SetAsFirstSibling();

        snakeLocation.Clear(); 
        for(int i = 0; i < this.gameObject.transform.childCount - 1; i++) {
            snakeLocation.Add(this.gameObject.transform.GetChild(i).position);            
        }
    }

    private void SetTurning(int x, int y)
    {
        currentMovement[0] = x;
        currentMovement[1] = y;
        isPress = true;
        turnSound.Play();
    }

    public void EatFood()
    {
        eatFoodSound.Play();
    }
}

