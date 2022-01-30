using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ObstacleBehavior : MonoBehaviour
{
    private float aceleration = -0.1f;
    Vector3 original_pos;
    Rigidbody2D rb;
    private Vector2 screenBounds;
    Transform tranform;
    private int delay = 20;
    Vector2 yBounds;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        tranform = GetComponent<Transform>();
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        original_pos = tranform.position;
        yBounds = new Vector2(GameObject.Find("WallBot").GetComponent<Transform>().position[1], GameObject.Find("WallTop").GetComponent<Transform>().position[1]);
        Debug.Log(yBounds[0]);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (delay <= 0)
        {
            if (Math.Abs(rb.velocity[0]) < 10)
                rb.velocity += new Vector2(aceleration, 0);
            delay = 20;
        }
        if(tranform.position[0] < -screenBounds.x)
        {
            tranform.position = new Vector2(screenBounds.x + 2, UnityEngine.Random.Range(yBounds[0]+3,  yBounds[1]-4));
        }
        delay--;
    }
}
