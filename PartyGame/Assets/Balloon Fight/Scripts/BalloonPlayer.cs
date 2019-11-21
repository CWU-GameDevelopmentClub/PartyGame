using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonPlayer : MonoBehaviour
{
    private Rigidbody2D rb;
    private ParticleSystem pr;
    private AudioSource ad;
    public float speed, jumpForce;
    public KeyCode left, right, down, jump;
    [Range(0f,1f)]
    public float rate;
    public float iRate;
    private float iTimer = 5f;
    private float timer;
    public int health = 3;
    public Sprite[] sprites;
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        pr = GetComponent<ParticleSystem>();
        ad = GetComponent<AudioSource>();
    }

    private void FixedUpdate()
    {
        BalloonWrapper.Wrap(this.transform);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        iTimer += Time.deltaTime;

        if (Input.GetKey(left))
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);
        }
        else if (Input.GetKey(right))
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
        }
        else if (Input.GetKey(down) && (timer > rate))
        {
            rb.velocity = new Vector2(rb.velocity.x, -jumpForce);
            timer = 0;
        }
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }

        if (Input.GetKey(jump) && (timer > rate))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            timer = 0;
        }

        if (!ad.isPlaying && health == 0)
        {
            this.gameObject.active = false;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameObject otherPlayer = collision.gameObject;
            otherPlayer.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            otherPlayer.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce * 75));

            if (iTimer > iRate)
            {
                health--;
                rb.velocity = Vector2.zero;
                rb.AddForce(new Vector2(0, jumpForce * -75));
                ad.Play();
                pr.Play();
                iTimer = 0;
            }

            if (health == 2)
            {
                GetComponentInChildren<SpriteRenderer>().sprite = sprites[1];
            }
            else
            {
                GetComponentInChildren<SpriteRenderer>().sprite = sprites[2];
            }
        }
    }
}
