using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    float inputH = 0;
    float inputY = 0;
    public float speed;
    public int HP;
    public int munition;
    public int nivel;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        inputH = Input.GetAxis("Horizontal");
        inputY = Input.GetAxis("Vertical");
        if (HP <= 0)
            SceneManager.LoadScene("You Lose");
    }

    void FixedUpdate()
    {
        float velocityX = inputH * speed * Time.fixedDeltaTime;
        float velocityY = inputY * speed * Time.fixedDeltaTime;
        rb.velocity = new Vector2(velocityX, velocityY);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Enemy_Kamikaze")
        {
           Destroy(other.gameObject);
           HP -= 80;
        }
        else if(other.gameObject.tag == "Enemy_Bomber")
        {
           Destroy(other.gameObject);
           HP -= 40;
        }
        else if(other.gameObject.tag == "Enemy_Lurker")
        {
           Destroy(other.gameObject);
           HP -= 40;
        }
        else if(other.gameObject.tag == "Enemy_Bullet")
        {
            Debug.Log("Absorbe bala");
           Destroy(other.gameObject);
           HP -= 20;
        }
        else if (other.gameObject.tag == "Portal")
        {
            switch (nivel)
            {
                case 1:
                    SceneManager.LoadScene("Nivel_2");
                break;
                default:
                break;
            }
        }
    }

}
