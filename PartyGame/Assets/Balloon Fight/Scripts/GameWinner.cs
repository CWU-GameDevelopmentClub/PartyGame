using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameWinner : MonoBehaviour
{
    private int health1;
    private int health2;
    public int winner;
    public GameObject p1;
    public GameObject p2;
    public TextMeshProUGUI winnerText;

    private ScoreKeeper scoreKeeper;

    // Start is called before the first frame update
    void Start()
    {
        winner = 0;
        winnerText.text = "";
        scoreKeeper = GameObject.Find("ScoreKeeper").GetComponent<ScoreKeeper>();
    }

    // Update is called once per frame
    void Update()
    {
        health1 = p1.GetComponent<BalloonPlayer>().health;
        health2 = p2.GetComponent<BalloonPlayer>().health;

        if (health1 == 0)
        {
            winner = 1;
            winnerText.text = "Player 2 Wins";
            scoreKeeper.SetRoundWinner(winner);
        }
        else if (health2 == 0)
        {
            winner = 0;
            winnerText.text = "Player 1 Wins";
            scoreKeeper.SetRoundWinner(winner);
            
        }

        if(health1 <= 0 || health2 <= 0)
        {
            SceneManager.LoadScene("ScoreLobby");
        }
        

    }
}
