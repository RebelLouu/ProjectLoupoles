﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ChangeLevel : MonoBehaviour {

    public string sceneToLoad = "main";
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void changeLevel()
    {
        SceneManager.LoadScene(sceneToLoad);
    }

    public void restartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    private void OnTriggerEnter2D(Collider2D collision)

    {
        if (collision.transform.tag == "Player")
        {
            changeLevel();
        }
    }
    
    
}
