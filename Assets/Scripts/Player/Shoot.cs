using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject Bullet;
    public int munition;
    int max_munition;
    GameObject bullet;
    List<GameObject> bullets = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        max_munition = 20;
        munition = 10;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("return"))
        {
            bullet = Instantiate(Bullet, transform.position + new Vector3(0, 1, 0), Quaternion.identity);
            
            bullets.Add(bullet);
            Debug.Log(bullets);  
        }
    }
}
