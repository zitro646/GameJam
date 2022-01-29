using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject enemy;
    public float    rotation;
    float    currentTime = 0f;
    public float    startingtime;
    public float    amount; 
    // Start is called before the first frame update
    void Start()
    {
        currentTime = startingtime;
        Instantiate (enemy, transform.position , transform.rotation);
        Debug.Log("works");
    }
 
    // Update is called once per frame
    void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        if(currentTime <= 0 && amount >= 1)
        {
            Instantiate (enemy, transform.position , transform.rotation);
            currentTime = startingtime;
            amount--;
        }
    }
}
