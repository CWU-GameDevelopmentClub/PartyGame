using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoundManager : MonoBehaviour
{
    private int rounds;
    public string[] scenes;

    // Start is called before the first frame update
    void Start()
    {
        rounds = 0;
    }

    // Update is called once per frame
    void Update()
    {


        Debug.Log("ROUNDS: " + rounds);

        DontDestroyOnLoad(this.gameObject);
        
    }

    public void NextRound()
    {
       
        if (rounds > 0)
        {
            DecrementRounds();
            int randNum = Random.Range(0, scenes.Length);
            SceneManager.LoadScene(scenes[randNum]);
        }
        else
        {
            SceneManager.LoadScene("WinLobby");
        }
      
    }

    private void DecrementRounds()
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

}
