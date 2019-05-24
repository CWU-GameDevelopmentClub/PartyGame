using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player3 : MonoBehaviour
{
    public float speed = 4.0f;

    public Sprite idleSprite;

    private Vector2 direction = Vector2.zero;
    private Vector2 nextDirection;

    private Vector3 startLocation;

    public Node player3CurrentNode, player3PreviousNode, player3TargetNode, player3StartNode;

    // Start is called before the first frame update
    void Start()
    {
        Node node = GetNodeAtPosition(transform.localPosition);

        startLocation = transform.localPosition;
        player3StartNode = node;

        if (node != null)
        {
            player3CurrentNode = node;
            Debug.Log(player3CurrentNode);
        }

        direction = Vector2.left;
        ChangePosition(direction);
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("SCORE: " + GameObject.Find("Game").GetComponent<GameBoard>().score);

        CheckInput();

        Move();

        UpdateOrientation();

        //UpdateAnimationState();
    }

    public void Reset()
    {
        transform.localPosition = startLocation;
        player3TargetNode = null;
        player3CurrentNode = player3StartNode;
        direction = Vector2.zero;
        ChangePosition(Vector2.zero);
    }

    void CheckInput()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            ChangePosition(Vector2.left);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            ChangePosition(Vector2.right);
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            ChangePosition(Vector2.up);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            ChangePosition(Vector2.down);
        }
    }

    public void ChangePosition(Vector2 d)
    {
        //if (CanMove(d) == null) return;

        if (d != direction)
            nextDirection = d;

        if (player3CurrentNode != null)
        {
            Node moveToNode = CanMove(d);

            if (moveToNode != null)
            {
                direction = d;
                player3TargetNode = moveToNode;
                player3PreviousNode = player3CurrentNode;
                player3CurrentNode = null;
            }
        }

        return;
    }

    public bool IsMoving()
    {
        return player3TargetNode != player3CurrentNode && player3TargetNode != null;
    }

    void Move()
    {
        if (player3TargetNode != player3CurrentNode && player3TargetNode != null)
        {
            if (nextDirection == direction * -1)
            {
                direction *= -1;

                Node tempNode = player3TargetNode;
                player3TargetNode = player3PreviousNode;
                player3PreviousNode = tempNode;
            }

            if (OverShotTarget())
            {
                player3CurrentNode = player3TargetNode;

                transform.localPosition = player3CurrentNode.transform.position;

                GameObject otherPortal = GetPortal(player3CurrentNode.transform.position);

                if (otherPortal != null)
                {
                    transform.localPosition = otherPortal.transform.position;

                    player3CurrentNode = otherPortal.GetComponent<Node>();
                }

                Node moveToNode = CanMove(nextDirection);

                if (moveToNode != null)
                    direction = nextDirection;

                if (moveToNode == null)
                    moveToNode = CanMove(direction);

                if (moveToNode != null)
                {
                    player3TargetNode = moveToNode;
                    player3PreviousNode = player3CurrentNode;
                    player3CurrentNode = null;
                }
                else
                {
                    direction = Vector2.zero;
                }

            }
            else
            {
                transform.localPosition += (Vector3)(direction * speed) * Time.deltaTime;
            }
        }

        transform.localPosition += (Vector3)(direction * speed) * Time.deltaTime;
    }

    public void MoveToNode(Vector2 d)
    {
        Node moveToNode = CanMove(d);

        if (moveToNode != null)
        {
            transform.localPosition = moveToNode.transform.position;
            player3CurrentNode = moveToNode;
        }
    }

    void UpdateOrientation()
    {
        if (direction == Vector2.left)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
        else if (direction == Vector2.right)
        {
            transform.localScale = new Vector3(1, 1, 1);
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
        else if (direction == Vector2.up)
        {
            transform.localScale = new Vector3(1, 1, 1);
            transform.localRotation = Quaternion.Euler(0, 0, 90);
        }
        else if (direction == Vector2.down)
        {
            transform.localScale = new Vector3(1, 1, 1);
            transform.localRotation = Quaternion.Euler(0, 0, 270);
        }
    }

    /*void UpdateAnimationState()
    {
        if (direction == Vector2.zero)
        {
            GetComponent<Animator>().enabled = false;
            GetComponent<SpriteRenderer>().sprite = idleSprite;
        }
        else
        {
            GetComponent<Animator>().enabled = true;
        }
    }*/

    Node CanMove(Vector2 d)
    {
        Node moveToNode = null;

        if (player3CurrentNode == null) return null;

        for (int i = 0; i < player3CurrentNode.neighbors.Length; i++)
        {
            if (player3CurrentNode.validDirections[i] == d)
            {
                moveToNode = player3CurrentNode.neighbors[i];
                break;
            }
        }

        return moveToNode;
    }


    Node GetNodeAtPosition(Vector2 pos)
    {
        GameObject tile = GameObject.Find("Game").GetComponent<GameBoard>().board[(int)pos.x, (int)pos.y];

        if (tile != null)
        {
            return tile.GetComponent<Node>();
        }

        return null;
    }

    public int GetBoardLocation()
    {
        Vector2 pos = transform.localPosition;
        int tileX = Mathf.RoundToInt(pos.x);
        int tileY = Mathf.RoundToInt(pos.y);

        return (tileY * 28) + tileX;
    }

    bool OverShotTarget()
    {
        float nodeToTarget = LengthFromNode(player3TargetNode.transform.position);
        float nodeToSelf = LengthFromNode(transform.localPosition);

        return nodeToSelf > nodeToTarget;
    }

    public float LengthFromNode(Vector2 targetPosition)
    {
        Vector2 vec = targetPosition - (Vector2)player3PreviousNode.transform.position;
        return vec.sqrMagnitude;
    }

    GameObject GetPortal(Vector2 pos)
    {
        GameObject tile = GameObject.Find("Game").GetComponent<GameBoard>().board[(int)pos.x, (int)pos.y];

        if (tile != null)
        {
            if (tile.GetComponent<Tile>() != null)
            {
                if (tile.GetComponent<Tile>().isPortal)
                {
                    GameObject otherPortal = tile.GetComponent<Tile>().portalReceiver;
                    return otherPortal;
                }
            }
        }

        return null;
    }
}
