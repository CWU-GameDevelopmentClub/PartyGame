using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private bool InRing;
    private int PosOffset;
    private bool DisableControl;

    public int Score;

    private const int EndTiming = 18;
    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis() == new Vector2(1.0, 0.0) && PosOffset >= 0)
        {
            PosOffset++;
            if (PosOffset >= EndTiming && !InRing)
                InRing = true;
        }
        if (Input.GetAxis() == new Vector2(-1.0, 0.0) && PosOffset <= EndTiming)
        {
            PosOffset--;
            if (PosOffset <= 0 && InRing)
            {
                InRing = false;

                //DisableControl = true;
            }
        }
    }

    public void AllowControl()
    {
        DisableControl = false;
    }
}
