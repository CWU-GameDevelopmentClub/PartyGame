using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour {

    private Rigidbody2D rb;
    private float speed = 3;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        if (rb.velocity.x == 0)
        {
            Move();
        }
        
	}

    public void Move()
    {
        rb.velocity = new Vector2(1, 1) * Random.Range(-1,3) * speed;
    }
}
