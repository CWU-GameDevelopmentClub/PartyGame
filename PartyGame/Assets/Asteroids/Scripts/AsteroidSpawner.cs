using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour {

    private int asteroidCount = 0;
    public float spawnRate = 1;

    public GameObject asteroidPrefab;

	// Use this for initialization
	void Start () {
		
	}

    float spawnTimer = 0;
	// Update is called once per frame
	void Update () {
        spawnTimer += Time.deltaTime;

        if (spawnTimer > (1.0/spawnRate))
        {
            SpawnAsteroid();
            spawnTimer = 0;
        }

	}

    private void SpawnAsteroid()
    {
        int spawnX = Random.Range(-10, 10);
        int spawnY = Random.Range(-10, 10);
        Instantiate(asteroidPrefab, new Vector2(spawnX, spawnY), Quaternion.identity,this.transform);
        asteroidCount++;
    }
}
