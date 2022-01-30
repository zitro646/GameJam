using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aaa : MonoBehaviour
{
    // Start is called before the first frame update
    public  int number_to_spam;
    public  List<GameObject> spawner_pool;
    public  GameObject stars;
    private Vector2 screenBounds;
    int counter;

    void Start()
    {
        int i;
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        counter = 25;
        i = 0;
        while (i < 10)
        {
             spawnObjects();
             i++;
        }
    }

    public  void    spawnObjects()
    {

        int random_item = 0;
        GameObject  to_spawn;
        MeshCollider    c = stars.GetComponent<MeshCollider>();
        float       screenX, screenY;
        Vector2 pos;
        for(int i = 0; i < number_to_spam; i++)
        {
            random_item = Random.Range(0, spawner_pool.Count);
            to_spawn = spawner_pool[random_item];

            screenX = Random.Range(-screenBounds[0]+1, screenBounds[0]-1);
            screenY = Random.Range(screenBounds[1] + 2, screenBounds[1] + 10);
            pos = new Vector2(screenX, screenY);

            Instantiate(to_spawn, pos, to_spawn.transform.rotation);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (counter == 0)
        {
            counter = 80;
            int i = 0;
            while (i < 10)
            {
                spawnObjects();
                i++;
            }
        }
        counter -= 1;
    }
}
