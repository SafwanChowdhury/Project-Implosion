using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MeterScript : MonoBehaviour
{
    private float startY = 0;
    private float endY = 0;
    private float tempY = 0;
    public SpriteRenderer mRenderer;
    public float initialPressure;
    public float pressure;
    public float slowDownRate;


    // Start is called before the first frame update
    void Start()
    {
        startY = mRenderer.bounds.min.y;
        pressure = initialPressure;
    }

    public void IncreasePressure()
    {
        if (transform.localScale.y < 4)
        {
            transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y + pressure * Time.deltaTime, transform.localScale.z);

            endY = mRenderer.bounds.min.y;
            transform.position = new Vector3(transform.position.x, transform.position.y + (startY - endY), transform.position.z);

            if (pressure > 0.01)
            {
                pressure -= slowDownRate * Time.deltaTime;
            }
        }
    }

    public void DecreasePressure()
    {
        if (transform.localScale.y > 0)
        {
            tempY = mRenderer.bounds.max.y;
            transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y - pressure * Time.deltaTime, transform.localScale.z);

            endY = mRenderer.bounds.max.y;
            transform.position = new Vector3(transform.position.x, transform.position.y - (tempY - endY), transform.position.z);
            pressure += slowDownRate * Time.deltaTime;
        }
        if (transform.localScale.y < 0)
        {
            transform.localScale = new Vector3(transform.localScale.x, 0, transform.localScale.z);
            pressure = initialPressure;
        }
    }   
}