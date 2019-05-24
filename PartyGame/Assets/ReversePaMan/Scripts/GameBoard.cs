using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBoard : MonoBehaviour
{
    public static int boardWidth = 28;
    public static int boardHeight = 36;

    public int totalPellets = 0;
    public int score = 0;

    public GameObject[,] board = new GameObject[boardWidth, boardHeight];

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        totalPellets = 0;

        Object[] objects = GameObject.FindObjectsOfType(typeof(GameObject));

        foreach (GameObject o in objects)
        {
            Vector2 pos = o.transform.position;

            if (o.name != "Player1" && o.name != "PacMan" && o.name != "Nodes" && o.name != "nonNodes" && o.name != "Maze" && o.name != "Pellets" && o.tag != "Maze")
            {
                if (o.GetComponent<Tile>() != null)
                {
                    if (o.GetComponent<Tile>().isPellet || o.GetComponent<Tile>().isSuperPellet)
                    {
                        o.GetComponent<SpriteRenderer>().enabled = true;
                        o.GetComponent<Tile>().didConsume = false;
                        totalPellets++;
                    }
                }

                board [(int)Mathf.Round(pos.x), (int)Mathf.Round(pos.y)] = o;

                //if (o.name.Contains("132"))
                //Debug.Log(o.name + ": " + pos.x + "," + pos.y);
            }
            else
            {
                //Debug.Log("Found PacMan at: " + pos);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Reset()
    {
        Start();
    }
}
