using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerDeathsScore : MonoBehaviour
{
    TextMeshProUGUI text;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        text.text = "" + (-1 * ObjectiveCounter.Instance.playerDeathTotal * Score.Instance.playerDeathSubtraction).ToString("0000");
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "" + (-1 * ObjectiveCounter.Instance.playerDeathTotal * Score.Instance.playerDeathSubtraction).ToString("0000");
    }
}
