using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LogicScript : MonoBehaviour
{
    public GreenZoneScript greenZone;
    public Text scoreText;
    public float depth;
    public float lvlChange = 0;
    public int increment = 33;

    // Start is called before the first frame update
    void Start()
    {
        greenZone = GameObject.FindGameObjectWithTag("GreenZone").GetComponent<GreenZoneScript>();
        greenZone.speed = 0;
        greenZone.scaleSize = 0.7f;
    }

    // Update is called once per frame
    void Update()
    {
        depthCalculator();
        if (depth < 10000)
        {
            levelSelector();
        }
        else
        {
            lvlChange += increment * Time.deltaTime;
            endlessMode();
        }
    }

    void depthCalculator()
    {
        depth += increment * Time.deltaTime;
        scoreText.text = ((int)depth).ToString();
    }

    void levelSelector()
    {
        if (depth > 500 && depth < 999)
        {
            greenZone.speed = 0.5f;
        }
        else if (depth > 1000 && depth < 1999)
        {
            greenZone.speed = 1;
        }
        else if (depth > 2000 && depth < 3999)
        {
            greenZone.speed = 0;
            greenZone.scaleSize = 0.4f;
            greenZone.scaleZone();
        }
        else if (depth > 4000 && depth < 9999)
        {
            greenZone.scaleSize = 0.7f;
            greenZone.speed = 2;
            greenZone.scaleZone();
        }
    }

    void endlessMode()
    {
        if (lvlChange > 1000)
        {
            lvlChange = 0;
            greenZone.speed = Random.Range(0, 3); // Moved Random.Range here
            float size = Random.Range(3, 10) / 10f; // Use float division for more precise results
            greenZone.scaleSize = size;
            greenZone.scaleZone();
        }
    }
}
