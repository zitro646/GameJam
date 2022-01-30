using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Killer : MonoBehaviour
{
    Transform transform;
    Vector3 orginalPos;
    Rigidbody2D rb;
    private Vector2 screenBounds;

    // Start is called before the first frame update
    void Start()
    {

        transform = GetComponent<Transform>();
        orginalPos = transform.position;
        rb = GetComponent<Rigidbody2D>();
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position[1] < -screenBounds.y)
        {
            transform.position = new Vector2(UnityEngine.Random.Range(-screenBounds.x + 1,  screenBounds.x - 1), UnityEngine.Random.Range(screenBounds.y + 2,  screenBounds.y + 20));
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
