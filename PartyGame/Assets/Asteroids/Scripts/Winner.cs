using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Winner : MonoBehaviour {

    private string winnerBoi;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetWinner(string winner)
    {
        winnerBoi = winner;
    }

    public string GetWinner()
    {
        return winnerBoi;
    }
}
