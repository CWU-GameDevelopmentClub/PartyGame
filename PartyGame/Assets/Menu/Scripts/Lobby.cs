using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;


public class Lobby : MonoBehaviour {

    public Slider roundSlider;
    public TextMeshProUGUI roundsText;
    private RoundManager roundManager;

	// Use this for initialization
	void Start () {

        roundsText.text = "Rounds: 1";
        roundManager = GameObject.Find("RoundManager").GetComponent<RoundManager>();
	}
	
	// Update is called once per frame
	void Update () {

        roundsText.text = "Rounds: " + roundSlider.value;
        roundManager.SetRounds(roundSlider.value);
	}

    public void Play()
    {
        roundManager.NextRound();
    }

    public void Back()
    {
        SceneManager.LoadScene("Menu");
    }

}
