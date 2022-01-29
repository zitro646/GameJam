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
    public int hp;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        objectwidth = transform.GetComponent<SpriteRenderer>().bounds.size.x / 4;
        objectheight = transform.GetComponent<SpriteRenderer>().bounds.size.y / 4;
        hp = 80;
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

    void OnTriggerEnter2D(Collider2D other)
    {
         if (other.gameObject.tag.Contains("Player_Bullet"))
        {
            hp -= 80;
            if (hp <= 0)
                Destroy(this.gameObject);
            Destroy(other.gameObject);
        }
        else if(other.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
        }
    }
}
