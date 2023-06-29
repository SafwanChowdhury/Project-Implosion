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
    public float slowDownRate;
    public float pressureIncrease;
    public float fillDuration = 5;

    // Start is called before the first frame update
    void Start()
    {
        startY = mRenderer.bounds.min.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D) == true)
        {
            Debug.Log("key down");
            if (transform.localScale.y < 4)
            {
                float exponentialIncrease = pressureIncrease * Mathf.Exp(-slowDownRate * Time.time);

                transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y + exponentialIncrease * Time.deltaTime, transform.localScale.z);

                endY = mRenderer.bounds.min.y;
                transform.position = new Vector3(transform.position.x, transform.position.y + (startY - endY), transform.position.z);

                if (pressureIncrease > 0.01)
                {
                    pressureIncrease -= slowDownRate * Time.deltaTime;
                }
            }
        }
        else
        {
            if (transform.localScale.y > 0)
            {
                tempY = mRenderer.bounds.max.y;
                transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y - 0.3f * Time.deltaTime, transform.localScale.z);

                endY = mRenderer.bounds.max.y;
                transform.position = new Vector3(transform.position.x, transform.position.y - (tempY - endY), transform.position.z);
            }
            if (transform.localScale.y < 0)
            {
                transform.localScale = new Vector3(transform.localScale.x, 0, transform.localScale.z);
                pressureIncrease = 0.5f;
            }
        }
    }
}