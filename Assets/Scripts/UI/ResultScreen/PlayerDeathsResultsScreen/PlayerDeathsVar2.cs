using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerDeathsVar2 : MonoBehaviour
{
    TextMeshProUGUI text;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        text.text = "" + (-1 * Score.Instance.playerDeathSubtraction).ToString("00");
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "" + (-1 * Score.Instance.playerDeathSubtraction).ToString("00");
    }
}
