using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBoundaries : MonoBehaviour
{
    private Vector2 screenBounds;
    private float   objectwidth;
    private float   objectheight;
    // Start is called before the first frame update
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        objectwidth = transform.GetComponent<SpriteRenderer>().bounds.size.x / 4;
        objectheight = transform.GetComponent<SpriteRenderer>().bounds.size.y / 4;
        //Debug.Log(" x : "+objectwidth+ " y : "+objectheight+ "\n");
    }

    // Update is called once per frame
    void LateUpdate()
    {
        
        Vector3 viewPos = transform.position;

        if((viewPos.x + objectwidth) > screenBounds.x)
        {
            viewPos.x = screenBounds.x - objectwidth;
        }
        if(((viewPos.x + objectwidth) < (screenBounds.x * -1)))
        {
            viewPos.x = (screenBounds.x * -1) - (objectwidth);
        }
        if((viewPos.y + objectheight) > screenBounds.y)
        {
            viewPos.y = screenBounds.y - objectheight;
        }   
        if((viewPos.y - objectheight) < (screenBounds.y * -1))
        {
            viewPos.y = (screenBounds.y * -1) + objectheight;
        }
        //Debug.Log("x = "+viewPos.x+" y = "+viewPos.y+ "\n");
        transform.position = viewPos;
    }
}
