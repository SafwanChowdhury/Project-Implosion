using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MarkerScript : MonoBehaviour
{
    public Rigidbody2D marker;
    public float moveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) == true)
        {
            marker.velocity = Vector2.up * moveSpeed;
        }

        if (transform.position.y < -2)
        {
            transform.position = new Vector3(transform.position.x, -2f, transform.position.z);
        }
        else if(transform.position.y > 2.55)
        {
            transform.position = new Vector3(transform.position.x, 2.54f, transform.position.z);
        }
    }
}
