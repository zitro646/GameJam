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
        rb = GetComponent<Rigidbody2D>();
        life = GameObject.FindGameObjectsWithTag("LifeSlider")[0].GetComponent<Slider>();
        munitionSlider = GameObject.FindGameObjectsWithTag("MunitionSlider")[0]; //GameObject.FindGameObjectsWithTag("LifeSlider")[0].GetComponent<Image>();
        life.value =  HP; 
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

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Valor : "+other.gameObject.tag);
        if(other.gameObject.tag == "Enemy_Kamikaze")
        {
           Debug.Log("Entra en contacto con el kamikaze");
           Destroy(other.gameObject);
           HP -= 80;
           life.value =  HP; 
           Debug.Log(HP);
        }
        else if(other.gameObject.tag == "Enemy_Bomber")
        {
           Destroy(other.gameObject);
           HP -= 40;
           life.value =  HP; 
           Debug.Log(HP);
        }
        if (other.gameObject.tag == "Steal")
        {
            HP += 40;
            life.value =  HP;
            Debug.Log("SADFASDFD");
            Debug.Log(HP);
        }
    }

}
