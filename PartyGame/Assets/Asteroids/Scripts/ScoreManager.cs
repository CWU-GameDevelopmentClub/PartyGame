using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour {

    public TextMeshProUGUI[] scoreUI;
    public GameObject[] players;

    // Use this for initialization
	void Start () {
        for (int i = 0; i < players.Length; i++)
        {
            scoreUI[i].enabled = true;          
            scoreUI[i].text = players[i].tag + ": " + players[i].GetComponentInChildren<Weapon>().getScore(); 
        }
	}
	
	// Update is called once per frame
	void Update () {
        for (int i = 0; i < players.Length; i++)
        {
            scoreUI[i].text = players[i].tag + ": " + players[i].GetComponentInChildren<Weapon>().getScore();
        }
    }

  
}
