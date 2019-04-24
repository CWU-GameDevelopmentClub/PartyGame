using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelect : MonoBehaviour {

	// Use this for initialization
	void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void PlayLevel(string level)
    {
        SceneManager.LoadScene(level);
    }

    public void Back()
    {
        SceneManager.LoadScene("Menu");
    }
}
