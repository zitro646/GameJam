using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomber_AI : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject target;
    Rigidbody2D rb;
    private Vector2 screenBounds;
    private float   objectwidth;
    private float   objectheight;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        objectwidth = transform.GetComponent<SpriteRenderer>().bounds.size.x / 4;
        objectheight = transform.GetComponent<SpriteRenderer>().bounds.size.y / 4;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        setObjective();
    }

    void setObjective()
    {
        float inputX = 0;
        float inputY = 0;

        if (rb.transform.position.x - objectwidth > target.transform.position.x)
            inputX = -1;
        else if (rb.transform.position.x + objectwidth < target.transform.position.x)
            inputX = 1;

        if (rb.transform.position.y - objectheight > target.transform.position.y)
            inputY = -1;
        else if (rb.transform.position.y + objectheight < target.transform.position.y)
            inputY = 1;    
        float velocityY = inputY * 250 * Time.fixedDeltaTime;
        float velocityX = inputX * 250 * Time.fixedDeltaTime;
        rb.velocity = new Vector2(velocityX, velocityY);
    }

/*
    float check_inside_boundaries()
    {
        if (rb.transform.position.x + (this.transform.GetComponent<SpriteRenderer>().bounds.size.x / 4) > screenBounds.x)
            return (-1);  
        else if (rb.transform.position.x - (this.transform.GetComponent<SpriteRenderer>().bounds.size.x / 4) < (screenBounds.x * -1))
            return (-1);   
        else if ((rb.transform.position.y - (this.transform.GetComponent<SpriteRenderer>().bounds.size.x / 4) > screenBounds.y))
            return (-1);   
        return (0);
    }

    void move_to_boundaries()
    {
        float inputY = 0;
        float inputX = 0;
        Vector3 enemyPos = transform.position;
        if((enemyPos.x + objectwidth) > screenBounds.x)
        {
            inputX = -1;
        }
        if(((enemyPos.x + objectwidth) < (screenBounds.x * -1)))
        {
            inputX = 1;
        }
        if((enemyPos.y + objectheight) > screenBounds.y)
        {
            inputY = -1;
        }
        float velocityY = inputY * 250 * Time.fixedDeltaTime;
        float velocityX = inputX * 250 * Time.fixedDeltaTime;
        Debug.Log("x : "+velocityX+" y : "+velocityY);
        rb.velocity = new Vector2(velocityX, velocityY);
    }
*/

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
