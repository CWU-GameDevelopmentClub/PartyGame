using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    private int[] scores;
    private string[] rankings;
    private int roundWinner;

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
        
        DontDestroyOnLoad(this.gameObject);
    }

    public void UpdateScores()
    {    
        scores[roundWinner]++;
    }

    private void UpdateRankings()
    {
        
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
}
