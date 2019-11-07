﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wrapper : MonoBehaviour
{
    private Camera cam;
    private static float screenWidth, screenHeight;
    private static float offset = 0.90f;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        screenHeight = cam.orthographicSize * 2f;
        screenWidth = screenHeight * cam.aspect;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void Wrap(Transform t)
    {
        if (t.position.x * offset < -screenWidth / 2)
        {
            t.position = new Vector2(Mathf.Abs(t.position.x), t.position.y);
        }
        else if (t.position.x * offset > screenWidth / 2)
        {
            t.position = new Vector2(-Mathf.Abs(t.position.x), t.position.y);
        }

        if (t.position.y * offset < -screenHeight / 2)
        {
            t.position = new Vector2(t.position.x, Mathf.Abs(t.position.y));
        }
        else if (t.position.y * offset > screenHeight / 2)
        {
            t.position = new Vector2(t.position.x, -Mathf.Abs(t.position.y));
        }
    }
}
