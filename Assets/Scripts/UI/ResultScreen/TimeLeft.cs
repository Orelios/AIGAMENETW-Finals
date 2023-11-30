using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeLeft : MonoBehaviour
{
    TextMeshProUGUI text;

    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        text.text = "Time Left<br>" +
            GameTimer.Instance.minutes.ToString("00") + ":" + GameTimer.Instance.seconds.ToString("00");
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "Time Left<br>" +
            GameTimer.Instance.minutes.ToString("00") + ":" + GameTimer.Instance.seconds.ToString("00");
    }
}
