using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Winner : MonoBehaviour {

    private string winnerBoi;
    private int winnerIndex;

    private ScoreKeeper scoreKeeper;

	// Use this for initialization
	void Start () {
        scoreKeeper = GameObject.Find("ScoreKeeper").GetComponent<ScoreKeeper>();
	}
	
	// Update is called once per frame
	void Update () {
        scoreKeeper.SetRoundWinner(winnerIndex);
	}
    
    public void SetWinnerIndex(int index)
    {
        winnerIndex = index;
    }

    public int GetWinnerIndex()
    {
        return winnerIndex;  
    }

    public void SetWinnerName(string winner)
    {
        winnerBoi = winner;
    }

    public string GetWinnerName()
    {
        return winnerBoi;
    }
}
