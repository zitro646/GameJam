using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aaa : MonoBehaviour
{
    // Start is called before the first frame update
    public  int number_to_spam;
    public  List<GameObject> spawner_pool;
    public  GameObject stars;

    void Start()
    {
            int i;

        i = 0;
        while (i < 10)
        {
             spawnObjects();
             i++;
             new WaitForSeconds(3);
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

            screenX = Random.Range((float)-4.5, (float)4.5);
            screenY = Random.Range((float)5.0, (float)10.0);
            pos = new Vector2(screenX, screenY);

            Instantiate(to_spawn, pos, to_spawn.transform.rotation);
        }
    }

    private void    destroy_objects()
    {
        foreach (GameObject o in GameObject.FindGameObjectsWithTag("Spawnable"))
        {
            Destroy(o);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
