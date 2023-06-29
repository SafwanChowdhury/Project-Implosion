using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerScript : MonoBehaviour
{
    public MeterScript gauge;
    public Boolean exitZone = false;
    // Start is called before the first frame update
    void Start()
    {
        gauge = GameObject.FindGameObjectWithTag("Gauge").GetComponent<MeterScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (exitZone)
        {
            gauge.IncreasePressure();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        exitZone = false;
        gauge.DecreasePressure();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        exitZone = true;
    }
}
