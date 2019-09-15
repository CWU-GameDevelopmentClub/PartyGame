using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreLobby : MonoBehaviour
{
    public TextMeshProUGUI winnerBoi;

    private RoundManager roundManager;

    // Start is called before the first frame update
    void Start()
    {
        roundManager = GameObject.Find("RoundManager").GetComponent<RoundManager>();
    }

    // Update is called once per frame
    void Update()
    {
        winnerBoi.text = " WinnerBoi: " + roundManager.GetWinner();
    }
}
