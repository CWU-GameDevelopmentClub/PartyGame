using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    private int[] scores;
    private string[] rankings;
    private int roundWinner;
    private string FINAL_WINNER;

    // Start is called before the first frame update
    void Start()
    {
        scores = new int[2];
        rankings = new string[2];

        for(int i = 0; i < scores.Length; i++)
        {
            scores[i] = 0;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateRankings();
        DontDestroyOnLoad(this.gameObject);
    }

    public void UpdateScores()
    {    
        scores[roundWinner]++;
    }

    private void UpdateRankings()
    {
        if (scores[0] > scores[1])
        {
            rankings[0] = "Player 1";
            rankings[1] = "Player 2";
        }
        else
        {
            rankings[0] = "Player 2";
            rankings[1] = "Player 1";
        }

        FINAL_WINNER = rankings[0];
    }

    public int[] GetScores()
    {
        return scores;
    }

    public void SetRoundWinner(int index)
    {
        roundWinner = index;
    }

    private int GetRoundWinner()
    {
        return roundWinner;
    }

    public string GetFinalWinner()
    {
        return FINAL_WINNER;
    }
}
