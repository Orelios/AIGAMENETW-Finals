using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SheepHerdedVar2 : MonoBehaviour
{
    TextMeshProUGUI text;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        text.text = "" + Score.Instance.sheepHerdedScore.ToString("00");
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "" + Score.Instance.sheepHerdedScore.ToString("00");
    }
}
