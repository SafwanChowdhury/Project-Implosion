using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenZoneScript : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 2f;
    public float maxHeight;
    public float minHeight;

    private bool movingUp = true;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveSquare();
    }

    private void MoveSquare()
    {
        float newYPosition = transform.position.y + (movingUp ? speed : -speed) * Time.deltaTime;
        newYPosition = Mathf.Clamp(newYPosition, minHeight, maxHeight);
        transform.position = new Vector3(transform.position.x, newYPosition, transform.position.z);

        if (newYPosition >= maxHeight)
        {
            movingUp = false;
        }
        else if (newYPosition <= minHeight)
        {
            movingUp = true;
        }
    }
}
