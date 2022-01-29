using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Round_Manager : MonoBehaviour
{
    
    public float targetTime;
    public int nivel;
    private float time;

    void Start()
    {
        time = targetTime;
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        if (time <= 0.0f)
        {   
            switch (nivel)
            {
                case 1:

                break;
                case 2:

                break;
                case 3:

                break;
                default:
            }
        }
    }
}
