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
        player = GameObject.Find("Player_ship");
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
        if(other.gameObject.tag == "Player")
        {
            Debug.Log("Boom (Se destruye)\n");
            
        }
    }
}
