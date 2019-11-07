using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundRandomizer : MonoBehaviour
{
    public Sprite[] sprites;

    // Start is called before the first frame update
    void Start()
    {
        var rand = Random.Range(0, 6);

        GetComponent<SpriteRenderer>().sprite = sprites[rand];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
