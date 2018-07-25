using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	
    public static void Lose()
    {
        Time.timeScale = 0;

        Debug.Log(GameObject.Find("Snakes").transform.childCount);
    }
}
