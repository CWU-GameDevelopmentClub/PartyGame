using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoundManager : MonoBehaviour
{
    private Winner winner;
    private Lobby lobby;
    private int rounds;

    // Start is called before the first frame update
    void Start()
    {
        rounds = 0;
    }

    // Update is called once per frame
    void Update()
    {


        if (!SceneManager.GetActiveScene().name.Contains("Lobby"))
        {
            if(winner == null)
            {
                winner = GameObject.Find("Winner").GetComponent<Winner>();
                Debug.Log("winner has been activated my dude");
            }

            Debug.Log("WINNER!! " + winner.GetWinner());
        }

        Debug.Log("ROUNDS: " + rounds);

        DontDestroyOnLoad(this.gameObject);
        
    }

    public void DecrementRounds()
    {
        rounds--;
    }

    public void SetRounds(float rounds)
    {
        this.rounds = (int) rounds;
    }

    public int GetRounds()
    {
        return rounds;
    }

    public string GetWinner()
    {
        return winner.GetWinner();
    }
}
