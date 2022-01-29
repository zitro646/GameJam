using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kamikaze_AI : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject player;
    Rigidbody2D rb;
    SpriteRenderer render;
    private float   objectwidth;
    public int HP;
    int duration_damage;

    void Start()
    {
        HP = 200;
        duration_damage = 0;
        rb = GetComponent<Rigidbody2D>();
        render = GetComponent<SpriteRenderer>();
        player = GameObject.Find("Player_ship");
    }

    void FixedUpdate()
    {
        if (HP <= 0)
        {
            Destroy(gameObject);
        }
        if (duration_damage <= 0)
        {
            render.color = new Color (1, 1, 1, 1);
        }
        duration_damage -= 1;
    }


    // Update is called once per frame
    void LateUpdate()
    {
        float velocityY = -1 * 250 * Time.fixedDeltaTime;
        float inputX;
        if (rb.transform.position.x - (player.transform.GetComponent<SpriteRenderer>().bounds.size.x / 4) > player.transform.position.x)
        {
            inputX = -1;
        }
        else if (rb.transform.position.x + (player.transform.GetComponent<SpriteRenderer>().bounds.size.x / 4) < player.transform.position.x)
        {
            inputX = 1;
        }
        else
        {
            inputX = 0;
        }
        float velocityX = inputX * 250 * Time.fixedDeltaTime;
        rb.velocity = new Vector2(velocityX, velocityY);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
    
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Bullet")
        {
            HP -= 80;
            render.color = new Color (1, 0, 0, 1);
            duration_damage = 10;
            Debug.Log(HP);
        }

    }
}
