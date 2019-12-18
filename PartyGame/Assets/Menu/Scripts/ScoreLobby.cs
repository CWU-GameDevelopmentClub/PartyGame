using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ScoreLobby : MonoBehaviour
{
    public TextMeshProUGUI winnerBoi;

    private RoundManager roundManager;
    private ScoreKeeper scoreKeeper;

    public TextMeshProUGUI[] scores;


    // Start is called before the first frame update
    void Start()
    {
        roundManager = GameObject.Find("RoundManager").GetComponent<RoundManager>();

        scoreKeeper = GameObject.Find("ScoreKeeper").GetComponent<ScoreKeeper>();
        scoreKeeper.UpdateScores();
    }

    // Update is called once per frame
    void Update()
    {

        for(int i = 0; i < scores.Length; i++)
        {
            scores[i].text = "Player " + (i + 1) + ": " + scoreKeeper.GetScores()[i];
        }

        // check if there is a winner, loop over scores, find score over majority rounds
        for(int i = 0; i < scoreKeeper.GetScores().Length; i++)
        {
            int currentScore = scoreKeeper.GetScores()[i];
            if (currentScore > roundManager.GetTotalRounds()/2)
            {
                // go to the win scene and display winner
                SceneManager.LoadScene("WinLobby");
            }
        }
    }

    public void NextRound()
    {
        roundManager.NextRound();
    }
}
