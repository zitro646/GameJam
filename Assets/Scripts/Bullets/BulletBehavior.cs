using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    Rigidbody2D rb;
    private Vector2 screenBounds;
    private float   objectwidth;
    private float   objectheight;
    // Start is called before the first frame update
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        objectwidth = transform.GetComponent<SpriteRenderer>().bounds.size.x;
        objectheight = transform.GetComponent<SpriteRenderer>().bounds.size.y;
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, 8);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        
        Vector3 viewPos = transform.position;

        if((viewPos.y) > screenBounds.y)
        {
            Destroy(gameObject);
        }
    }
}
