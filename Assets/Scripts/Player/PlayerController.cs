using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    float inputH = 0;
    float inputY = 0;
    public float speed;
    public int HP;
    public int MAX_HP = 400;
    public int munition;
    public Slider life;
    GameObject munitionSlider;

    void Start()
    {
        HP = DataGame.HP;
        MAX_HP = DataGame.MAX_HP;
        munition = DataGame.munition;
        rb = GetComponent<Rigidbody2D>();
        life = GameObject.FindGameObjectsWithTag("LifeSlider")[0].GetComponent<Slider>();
        munitionSlider = GameObject.FindGameObjectsWithTag("MunitionSlider")[0]; //;
        life.value =  HP; 
        Debug.Log("I am alive");
        Debug.Log(HP);
        Debug.Log(munition);
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
        DataGame.HP = HP;
        DataGame.munition = munition;
        life.value = HP;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Valor : "+other.gameObject.tag);
        if(other.gameObject.tag == "Enemy_Kamikaze")
        {
           Debug.Log("Entra en contacto con el kamikaze");
           Destroy(other.gameObject);
           HP -= 40;
        }
        else if(other.gameObject.tag == "Enemy_Bomber")
        {
           Destroy(other.gameObject);
           HP -= 20;
        }
        else if(other.gameObject.tag == "Enemy_Bomber")
        {
           Destroy(other.gameObject);
           HP -= 20;
        }
        else if(other.gameObject.tag == "Enemy_Bullet")
        {
           Destroy(other.gameObject);
           HP -= 10;
        }
        if (other.gameObject.tag == "Steal")
        {
            HP += 20;
            if (HP > MAX_HP)
                HP = MAX_HP;
            Debug.Log("SADFASDFD");
            Debug.Log(HP);
        }
    }

}
