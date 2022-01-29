using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    float inputH = 0;
    float inputY = 0;
    public float speed;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        inputH = Input.GetAxis("Horizontal");
        inputY = Input.GetAxis("Vertical");  
    }

    void FixedUpdate()
    {
        float velocityX = inputH * speed * Time.fixedDeltaTime;
        float velocityY = inputY * speed * Time.fixedDeltaTime;
        rb.velocity = new Vector2(velocityX, velocityY);
    }
}
