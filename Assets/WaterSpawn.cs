using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterSpawn : MonoBehaviour
{
    public GameObject water;
    public float spawnRate = 22.26f;
    public float timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        spawnWater();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < spawnRate)
        {
            timer += Time.deltaTime;
        }
        else
        {
            spawnWater();
            timer = 0;
        }
    }

    void spawnWater()
    {
        Instantiate(water, transform.position, transform.rotation);
    }
}
