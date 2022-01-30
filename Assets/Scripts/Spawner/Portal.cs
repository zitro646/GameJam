using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    Rigidbody2D rb;
    public int nivel;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    void FixedUpdate()
    {
        float velocityX = 0 * 0 * Time.fixedDeltaTime;
        float velocityY = -1 * 250 * Time.fixedDeltaTime;
        rb.velocity = new Vector2(velocityX, velocityY);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("EL trigger del portal se activa : "+other.gameObject.tag);
        if(other.gameObject.tag == "Player")
        {
            if (nivel == 1)
                SceneManager.LoadScene("Nivel_2");
        }
    }
}