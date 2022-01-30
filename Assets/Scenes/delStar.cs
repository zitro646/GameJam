using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class delStar : MonoBehaviour
{
    private Vector2 screenBounds;
    private float   objectheight;
    public GameObject encodePanel;
    // Start is called before the first frame update
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        objectheight = transform.GetComponent<SpriteRenderer>().bounds.size.y / 4;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3     viewPos = transform.position;
        //transform   nameObjects = transform.getchil
        if((viewPos.y - objectheight) < (screenBounds.y * -1))
        {  
            //fail destroid
            //Destroy(gameObject);
        }
    }
}
