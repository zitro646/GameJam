using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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

        if (DataGame.HP <= 0)
        {
            SceneManager.LoadScene("You Lose");
        }
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
           DataGame.HP -= 40;
        }
        else if(other.gameObject.tag == "Enemy_Bomber")
        {
           Destroy(other.gameObject);
           DataGame.HP -= 20;
        }
        else if(other.gameObject.tag == "Enemy_Bomber")
        {
           Destroy(other.gameObject);
           DataGame.HP -= 20;
        }
        else if(other.gameObject.tag == "Enemy_Bullet")
        {
           Destroy(other.gameObject);
           DataGame.HP -= 10;
        }
        else if (other.gameObject.tag == "Steal")
        {
            DataGame.HP += 20;
            if (DataGame.HP > DataGame.MAX_HP)
                DataGame.HP = DataGame.MAX_HP;
        }
        else if (other.gameObject.tag == "Munition")
        {
            DataGame.munition += 8;
            if (DataGame.munition > DataGame.MAX_MUNITION)
                DataGame.munition = DataGame.MAX_MUNITION;
        }
    }

}
