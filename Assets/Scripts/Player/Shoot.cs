using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject Bullet;
    GameObject bullet;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("return"))
        {
            if (DataGame.munition > 0)
            {
               Instantiate(Bullet, transform.position + new Vector3(0, 1, 0), Quaternion.identity);
               DataGame.munition -= 1;
            }
        }
    }
}
