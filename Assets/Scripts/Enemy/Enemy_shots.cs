using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_shots : MonoBehaviour
{   
    public float targetTime;
    private float time;
    public GameObject Bullet;

    void Start()
    {
        time = targetTime;
    }

    void Update()
    {
        time -= Time.deltaTime;
        if (time <= 0.0f)
        {
            Debug.Log("Pium  Pium!!");
            timerEnded();
            time = targetTime;
        }
    }

    void timerEnded()
    {
        Instantiate(Bullet, transform.position + new Vector3(0, -1, 0), Quaternion.identity);
        //do your stuff here.
    }
}
