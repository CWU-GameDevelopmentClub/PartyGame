using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidPlayer : MonoBehaviour {

    private Rigidbody2D rb;
    public KeyCode left, right, forward, back, shoot;
    public float speed;
    private Vector2 direction;
    public Transform booster;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKey(left))
        {
            rb.AddTorque(speed/10);
        }else if (Input.GetKey(right))
        {
            rb.AddTorque(-speed/10);
        }else
        {
          //  rb.freezeRotation = true;
        }

        direction = (this.transform.position - booster.transform.position).normalized;

        if (Input.GetKey(forward))
        {
            rb.AddForce(direction*speed*4);
        }
        if (Input.GetKey(back))
        {
            rb.AddForce(-direction * speed * 4);
        }
	}
}
