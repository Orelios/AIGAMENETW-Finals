using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameTimer : MonoBehaviour
{
    public float seconds = 0.0f;
    public int minutes = 2;
    //public int hours = 0;

    TextMeshProUGUI text;

    // Start is called before the first frame update
    void Start()
    {
        //seconds = 0.0f;
        //minutes = 0;
        //hours = 0;
        text = GetComponent<TextMeshProUGUI>();
        text.text = ""+minutes + ":" + seconds.ToString("00"); //seconds.ToString("F1") for 1 decimal
    }

    // Update is called once per frame
    void Update()
    {
        seconds -= Time.deltaTime;
        if (seconds <= 0.0f)
        {
            seconds += 60.0f;
            minutes -= 1;
        }
        /*
        if (minutes >= 60)
        {
            minutes -= 60;
            hours += 1;
        }
        */
        text.text = ""+minutes + ":" + seconds.ToString("00");
    }
}
