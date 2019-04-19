using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;


public class Lobby : MonoBehaviour {

    public Slider roundSlider;
    public TextMeshProUGUI roundsText;

	// Use this for initialization
	void Start () {

        roundsText.text = "Rounds: 1";
	}
	
	// Update is called once per frame
	void Update () {

        roundsText.text = "Rounds: " + roundSlider.value;
      
	}

    public void Back()
    {
        SceneManager.LoadScene("Menu");
    }
}
