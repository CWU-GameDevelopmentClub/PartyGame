using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WinLobby : MonoBehaviour
{
    public TextMeshProUGUI winner;
    private ScoreKeeper scoreKeeper;

    // Start is called before the first frame update
    void Start()
    {
        scoreKeeper = GameObject.Find("ScoreKeeper").GetComponent<ScoreKeeper>();
    }

    // Update is called once per frame
    void Update()
    {
        winner.text = "WINNER: " + scoreKeeper.GetFinalWinner();
    }
}
