using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class RoundTimer : MonoBehaviour {

    private TextMeshProUGUI timerText;
    public float roundTime = 60;

	// Use this for initialization
	void Start () {
        timerText = GetComponent<TextMeshProUGUI>();    
        timerText.text = "Timer: "; 
	}
	
	// Update is called once per frame
	void Update () {
        roundTime -=  Time.deltaTime;
        timerText.text = "Timer: " + (int) roundTime;

        if(roundTime <= 0)
        {
            timerText.text = "END GAME";
        }
	}
}
