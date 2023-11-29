using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Tally : MonoBehaviour
{

    TextMeshProUGUI text;

    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        text.text = "Sheep Herded | " + ObjectiveCounter.Instance.sheepHerded + " x " + Score.Instance.sheepHerdedScore + " = " + (ObjectiveCounter.Instance.sheepHerded * Score.Instance.sheepHerdedScore) + " pts<br>" +
            "Player death | " + ObjectiveCounter.Instance.playerDeathTotal + " x " + Score.Instance.playerDeathSubtraction + " = " + (-1 * ObjectiveCounter.Instance.playerDeathTotal * Score.Instance.playerDeathSubtraction) + " pts";
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "Sheep Herded | " + ObjectiveCounter.Instance.sheepHerded + " x " + Score.Instance.sheepHerdedScore + " = " + (ObjectiveCounter.Instance.sheepHerded * Score.Instance.sheepHerdedScore) + " pts<br>" +
            "Player death | " + ObjectiveCounter.Instance.playerDeathTotal + " x " + Score.Instance.playerDeathSubtraction + " = " + (-1 * ObjectiveCounter.Instance.playerDeathTotal * Score.Instance.playerDeathSubtraction) + " pts";
    }
}
