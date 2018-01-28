using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] go;
    // Use this for initialization
    void Start()
    {
        //    spawnObj = new GameObject();
    }

    int counter;
    public int range;
    public int asteroidTimeer;
    void Update()
    {

       
        if (counter++ > Random.Range(10, asteroidTimeer))
        {
            counter = 0;
           // int rand;
            // for (int a = 0; a < rand; a++)
            Destroy(Instantiate(go[Random.Range(0, go.Length - 1)], new Vector3(transform.position.x + Random.Range(-range, range), transform.position.y ), Quaternion.identity),8);
        }


    }
}
