using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kamikaze_AI : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject player;
    Rigidbody2D rb;
    private float   objectwidth;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Ship");
    }

    // Update is called once per frame
    void LateUpdate()
    {
        setObjective();
    }

    void setObjective()
    {
        float velocityY = -1 * 250 * Time.fixedDeltaTime;
        float inputX;
        if (rb.transform.position.x - (player.transform.GetComponent<SpriteRenderer>().bounds.size.x / 4) > player.transform.position.x)
            inputX = -1;
        else if (rb.transform.position.x + (player.transform.GetComponent<SpriteRenderer>().bounds.size.x / 4) < player.transform.position.x)
            inputX = 1;
        else
            inputX = 0;

        float velocityX = inputX * 250 * Time.fixedDeltaTime;
        rb.velocity = new Vector2(velocityX, velocityY);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Triggered  -> " + other.tag);
        if (other.gameObject.tag == "Player_Bullet")
        {
            Debug.Log("Es golpeado por una bala");
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
        else if(other.gameObject.tag == "Player")
        {
            Debug.Log("Toca al jugador");
            Destroy(this.gameObject);
        }
    }
}
