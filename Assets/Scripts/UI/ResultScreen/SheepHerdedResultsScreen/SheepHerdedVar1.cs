using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SheepHerdedVar1 : MonoBehaviour
{
    TextMeshProUGUI text;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        text.text = "" + ResultScreenManager.Instance.resultSheepHerded.ToString("00");
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "" + ResultScreenManager.Instance.resultSheepHerded.ToString("00");
    }
}
