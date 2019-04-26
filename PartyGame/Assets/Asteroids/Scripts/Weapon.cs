using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

    [Range(0f,10f)]
    public float fireRate = 5;

    public float damage = 10;
    public LayerMask whatToHit;
    public KeyCode fire;


    public Transform bulletTrailPrefab;

    private float timeToFire = 0;
    private Transform firePoint;

	// Use this for initialization (use awake if not working)
	void Start () {
        firePoint = this.transform.Find("FirePoint");
        if(firePoint == null)
        {
            Debug.LogError("No FirePoint! Check yo self!");
        }
	}

    // Update is called once per frame
    void Update() {
        if (fireRate == 0)
        {
            if (Input.GetKeyDown(fire))
            {
                Shoot();
            }
        }
        else
        {
            if (Input.GetKey(fire) && Time.time > timeToFire)
            {
                timeToFire = Time.time + 1 / fireRate;
                Shoot();
            }
        }
	}

    public void Shoot()
    {
        Vector2 myPostition = new Vector2(this.transform.position.x, this.transform.position.y);
        Vector2 firePointPosition = new Vector2(firePoint.position.x, firePoint.position.y);
        RaycastHit2D hit = Physics2D.Raycast(firePointPosition, firePointPosition - myPostition, 100, whatToHit);
        
        //Debug.DrawLine(firePointPosition, (firePointPosition - myPostition) * 100, Color.cyan);
        Effect();

        if(hit.collider != null)
        {
            Debug.Log("HITTT!!");
            Debug.DrawLine(myPostition, hit.point, Color.red);
            
        }
    }

    public void Effect()
    {
        Instantiate(bulletTrailPrefab, firePoint.position, firePoint.rotation);
    }
}
