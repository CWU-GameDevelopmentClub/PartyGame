using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

    private Button playButton;

	// Use this for initialization
	void Start () {

        playButton = GetComponentInChildren<Button>();

	}
	
	// Update is called once per frame
	void Update () {
		
	}
        
    public void Play()
    {
        SceneManager.LoadScene("LevelSelect");
    }
   
}
