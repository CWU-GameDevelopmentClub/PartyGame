using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameWinner : MonoBehaviour
{
    private int health1;
    private int health2;
    public int winner;
    public GameObject p1;
    public GameObject p2;
    public TextMeshProUGUI winnerText;

    // Start is called before the first frame update
    void Start()
    {
        winner = 0;
        winnerText.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        health1 = p1.GetComponent<BalloonPlayer>().health;
        health2 = p2.GetComponent<BalloonPlayer>().health;

        if (health1 == 0 && !p1.GetComponent<BalloonPlayer>().ad.isPlaying)
        {
            winner = 2;
            winnerText.text = "Player 2 Wins";
        }
        else if (health2 == 0 && !p2.GetComponent<BalloonPlayer>().ad.isPlaying)
        {
            winner = 1;
            winnerText.text = "Player 1 Wins";
        }
    }
}
