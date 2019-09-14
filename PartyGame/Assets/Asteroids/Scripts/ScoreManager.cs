using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour {

    public TextMeshProUGUI[] scoreUI;
    public GameObject[] players;
    private int[] scores;
    private int maxScore = -1;

    public Winner winnerWinner;

    // Use this for initialization
	void Start () {
        scores = new int[players.Length];
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

        for(int i = 0; i < players.Length; i++)
        {
            scores[i] = players[i].GetComponentInChildren<Weapon>().getScore();
            if(scores[i] > maxScore)
            {
                maxScore = scores[i];
                winnerWinner.SetWinner(players[i].tag);
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                 }
        }

    }

  
}
