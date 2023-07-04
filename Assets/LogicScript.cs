using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class LogicScript : MonoBehaviour
{
    public GreenZoneScript greenZone;
    public Text scoreText;
    public float depth;
    private bool units = true;
    private float interval = 0;
    float roundInterval = Random.Range(50, 101);
    float timePassed = 0f;
    bool settingsChanged = false;

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
        levelSelector();

    }

    void depthCalculator()
    {
        depth += 33 * Time.deltaTime;
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
        }
        else if (depth > 4000 && depth < 9999)
        {
            greenZone.scaleSize = 0.7f;
            greenZone.speed = 2;
        }
        else if(depth > 10000)
        {
            endlessMode();
        }
    }

    
    void endlessMode()
    {
        timePassed += Time.deltaTime;

        if (!settingsChanged && timePassed >= roundInterval)
        {
            ChangeGameSettings();
            settingsChanged = true;
        }

        if (settingsChanged && timePassed >= roundInterval + 5f) // 5 seconds delay before changing settings again
        {
            ResetGameSettings();
            roundInterval = Random.Range(50, 101);
            timePassed = 0f;
            settingsChanged = false;
        }
    }

    void ChangeGameSettings()
    {
        greenZone.speed = Random.Range(0, 5);
        int val = Random.Range(1, 30);
        greenZone.scaleSize = val / 10;
        // Modify other game settings as needed
    }

    void ResetGameSettings()
    {
        // Reset game settings to default values
        greenZone.speed = 0;
        greenZone.scaleSize = 0;
        // Reset other game settings as needed
    }
}
