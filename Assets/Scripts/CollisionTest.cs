using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Acabo de empezar a existir, hola!");
    }

    // Update is called once per frame
    void Update()
    {
        //no vamos a usar Update en este script, la puedes borrar si quieres
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Me he chocado con el suelo (ay!)");
    }
}
