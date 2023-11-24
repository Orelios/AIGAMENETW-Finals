using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameTimer : MonoBehaviour
{
    public float seconds = 0.0f;
    public int minutes = 0;
    public int hours = 0;

    TextMeshProUGUI text;

    // Start is called before the first frame update
    void Start()
    {
        seconds = 0.0f;
        minutes = 0;
        hours = 0;
        text = GetComponent<TextMeshProUGUI>();
        text.text = "Time " + hours + " : " + minutes + " : " + seconds;
    }

    // Update is called once per frame
    void Update()
    {
        seconds += Time.deltaTime;
        if (seconds >= 60.0f)
        {
            seconds -= 60.0f;
            minutes += 1;
        }
        if (minutes >= 60)
        {
            minutes -= 60;
            hours += 1;
        }
        text.text = "Time " + hours + " : " + minutes + " : " + seconds;
    }
}
