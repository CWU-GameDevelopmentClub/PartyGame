using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoundManager : MonoBehaviour
{
    private Winner winner;

    // Start is called before the first frame update
    void Start()
    {
     
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

        DontDestroyOnLoad(this.gameObject);
        
    }

    public string GetWinner()
    {
        return winner.GetWinner();
    }
}
