using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Round_Manager : MonoBehaviour
{
    
    public float targetTime;
    private float time;
    public GameObject Portal;

    void Start()
    {
        time = targetTime;
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        if (time <= 0.0f)
        {
            Debug.Log("Se crea el portal");
            time = targetTime;
            Instantiate(Portal, transform.position + new Vector3(0, 1, 0), Quaternion.identity);
        }
    }
}
