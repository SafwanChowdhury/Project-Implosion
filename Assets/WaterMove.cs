using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterSpawner : MonoBehaviour
{
    public float moveSpeed = 0.1f;
    public float deadZone = 11;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + (Vector3.up * moveSpeed) * Time.deltaTime;

        if (transform.position.y > deadZone)
        {
            Destroy(gameObject);
        }
    }
}
