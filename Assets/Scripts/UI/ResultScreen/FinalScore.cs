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
        text.text = "" + ResultScreenManager.Instance.resultFinalScore.ToString("0000");
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "" + ResultScreenManager.Instance.resultFinalScore.ToString("0000");
    }
}
