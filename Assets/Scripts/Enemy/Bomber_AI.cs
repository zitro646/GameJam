using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomber_AI : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject player;
    Rigidbody2D rb;
    private Vector2 screenBounds;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player_ship");
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    // Update is called once per frame
    void LateUpdate()
    {
       if (check_inside_boundaries() == -1)
       {
           Debug.Log("No esta dentro");
           move_to_boundaries();
       }
       
    }

    float check_inside_boundaries()
    {
        if (rb.transform.position.x - (this.transform.GetComponent<SpriteRenderer>().bounds.size.x / 4) > screenBounds.x)
            return (-1);
        else if (rb.transform.position.x + (this.transform.GetComponent<SpriteRenderer>().bounds.size.x / 4) < screenBounds.x)
            return (-1);
        else if ((rb.transform.position.y - (this.transform.GetComponent<SpriteRenderer>().bounds.size.x / 4) > screenBounds.y))
            return (-1);
        return (0);
    }

    void move_to_boundaries()
    {
        float inputY = 0;
        float inputX = 0;
        if (rb.transform.position.x - (this.transform.GetComponent<SpriteRenderer>().bounds.size.x / 4) > screenBounds.x)
            inputX = -1;
        else if (rb.transform.position.x + (this.transform.GetComponent<SpriteRenderer>().bounds.size.x / 4) < screenBounds.x)
            inputX = 1;
        if (rb.transform.position.y + (this.transform.GetComponent<SpriteRenderer>().bounds.size.y / 4) < screenBounds.y)
            inputX = -1;
        float velocityY = inputY * 250 * Time.fixedDeltaTime;
        float velocityX = inputX * 250 * Time.fixedDeltaTime;
        Debug.Log("x : "+velocityX+" y : "+velocityY);
        rb.velocity = new Vector2(velocityX, velocityY);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Here");
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag.Contains("Player_Bullet"))
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
            Debug.Log("Destroy");
        }
        else if(other.gameObject.tag == "Player")
        {
            Debug.Log("Boom (Se destruye)\n");
            
        }
        Debug.Log("Trigger\n");
    }
}
