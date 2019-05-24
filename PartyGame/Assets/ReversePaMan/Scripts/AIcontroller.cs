using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIcontroller : MonoBehaviour
{

    private GameBoard board;
    private PacMan pacman;


    private int steps = 0;
    private int pacCount = 0;
    private int genCount = 0;

    private Brain brain;
    private Brain bestBrain;
    private Brain[] jarOfBrains;

    private static Vector2[] MOVES = {Vector2.left, Vector2.right, Vector2.up, Vector2.down};

    private int wait = 0;

    private int currentLocation;


    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("AIcontroller Started Up");

        this.pacman = GameObject.Find("PacMan").GetComponent<PacMan>();
        this.board = GameObject.Find("Game").GetComponent<GameBoard>();

        this.bestBrain = new Brain(100);
        this.jarOfBrains = new Brain[10];

        for ( int i=0; i<jarOfBrains.Length; i++)
        {
            this.jarOfBrains[i] = new Brain(100);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (pacCount == jarOfBrains.Length)
        {
            int max = 0;
            int braindex = 0;
            for (int j=0; j<jarOfBrains.Length; j++)
            {
                if (jarOfBrains[j].score > max)
                {
                    max = jarOfBrains[j].score;
                    braindex = j;
                }
            }

            Debug.Log("Brain " + (braindex+1) + " was the best brain of generation" + (genCount+1) + ", with a score of " + max);
            Debug.Log("I'VE GOT A JAR OF DIRT! ------------------------------------------------------ I'VE GOT A JAR OF DIRT!");
            Debug.Log("I'VE GOT A JAR OF DIRT! ------------------------------------------------------ I'VE GOT A JAR OF DIRT!");
            Debug.Log("I'M SHAKIN THE JAR!!");
            bestBrain.CopyBrain(jarOfBrains[braindex]);
            ShakeTheJar();
            pacCount = 0;
        }

        if (wait < 20)
        {
            wait++;
            return;
        }
        else wait = 0;

        if (steps == 0)
        {
            this.brain = jarOfBrains[pacCount];
        }

        //Debug.Log("location: " + currentLocation + ", " + this.pacman.GetBoardLocation());
        //if (this.pacman.GetBoardLocation() == currentLocation) return;

        //Debug.Log("step: " + steps);
        if (steps < 100)
        {
            this.pacman.ChangePosition(AIcontroller.MOVES[this.brain.moves[steps]]);
            //if (this.pacman.IsMoving()/*!this.pacman.ChangePosition(MOVES[this.brain.moves[steps]])*/) currentLocation = -1;
            //else currentLocation = this.pacman.GetBoardLocation();

            //Debug.Log(this.brain.moves[steps] + ", " + currentLocation);
        }
        else
        {
            this.brain.score = this.board.score;
            jarOfBrains[pacCount].score = this.board.score;
            //Debug.Log("brain score: " + this.brain.score);

            Debug.Log("Brain " + (pacCount+1) + " had a score of " + this.brain.score);

            this.board.Reset(); 
            this.pacman.Reset();

            pacCount++;
            steps = 0;
            return;
        }

        steps++;
    }

    void ShakeTheJar()
    {
        for (int j = 0; j < jarOfBrains.Length; j++)
        {
            jarOfBrains[j].CopyBrain(bestBrain);
            jarOfBrains[j].score = 0;

            if (j == 0) continue;

            for (int i = 0; i < jarOfBrains[j].moves.Length; i++)
            {
                if (UnityEngine.Random.Range(0, 10) > 2) continue;
                jarOfBrains[j].moves[i] = UnityEngine.Random.Range(0, 4);
            }
        }

        jarOfBrains[0].CopyBrain(bestBrain);

        genCount++;
    }


    private class Brain
    {
        public int score;
        public int[] moves;

        public Brain(int count)
        {
            this.score = 0;
            this.moves = new int[count];

            for (int x = 0; x < count; x++) this.moves[x] = UnityEngine.Random.Range(0, 4);
        }

        public void CopyBrain(Brain from)
        {
            for (int i = 0; i < this.moves.Length; i ++)
            {
                this.moves[i] = from.moves[i];
            }
        }
    }
}
