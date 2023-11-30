using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;

public class FinalScore : MonoBehaviour
{
    TextMeshProUGUI text;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        text.text = "Final Score<br>" +
            Score.Instance.score.ToString("000000");
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "Final Score<br>" +
            Score.Instance.score.ToString("000000") + " pts";
    }
}
