using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ObjectiveCounter : MonoBehaviour
{
    public static ObjectiveCounter Instance { get; private set; }

    TextMeshProUGUI text;

    public int sheepHerded = 0;
    public int sheepLeft;
    public int playerDeathTotal = 0;

    void Awake()
    {
        // If there is an instance, and it's not me, delete myself.

        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
        text = GetComponent<TextMeshProUGUI>();
        text.text = "" + sheepLeft + " left";
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "" + sheepLeft + " left";
    }
}
