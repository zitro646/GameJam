using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lurker_AI : MonoBehaviour
{
  
    // Start is called before the first frame update
    public GameObject target;
    public GameObject target2;
    public GameObject target3;
    Rigidbody2D rb;
    private Vector2 screenBounds;
    private float   objectwidth;
    private float   objectheight;
    private int     fase;
    public int hp;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        objectwidth = transform.GetComponent<SpriteRenderer>().bounds.size.x / 4;
        objectheight = transform.GetComponent<SpriteRenderer>().bounds.size.y / 4;
        hp = 80;
        fase = 0;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (checkObjective() == -1)
        {
            gotoObjective();
        }
        else
        {
            Debug.Log("Esta en el objetivo");
            setObjective();
        }
            
    }

    void setObjective()
    {
        GameObject aux = target;
        if(fase == 0)
        {
            target = target2;
            target2 = aux;
        }
        if(fase == 1)
        {
            target = target3;
            target3 = aux;
        }
        if (fase == 2)
        {
            target = target2;
            target2 = aux;
            fase = -1;
        }
        fase++;
    }

    int checkObjective()
    {
        float x = 0;
        float y = 0;

        if (rb.transform.position.x - objectwidth > target.transform.position.x)
            x = 1;
        else if (rb.transform.position.x + objectwidth < target.transform.position.x)
            x = 1;

        if (rb.transform.position.y - objectheight > target.transform.position.y)
            y = 1;
        else if (rb.transform.position.y + objectheight < target.transform.position.y)
            y = 1; 
        if ( y == 0 && x == 0)
        {
            return (1);
        }
            
        return (-1);
    }

    void gotoObjective()
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
