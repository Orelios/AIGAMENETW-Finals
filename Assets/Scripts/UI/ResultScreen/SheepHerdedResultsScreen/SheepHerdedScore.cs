using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SheepHerdedScore : MonoBehaviour
{
    TextMeshProUGUI text;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        text.text = "" + (ObjectiveCounter.Instance.sheepHerded * Score.Instance.sheepHerdedScore).ToString("0000");
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "" + (ObjectiveCounter.Instance.sheepHerded * Score.Instance.sheepHerdedScore).ToString("0000");
    }
}
