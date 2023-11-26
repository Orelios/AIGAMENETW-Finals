using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    TextMeshProUGUI text;

    public static int score = 0;
    public static int playerDeathSubtraction = 1;
    public static int sheepLostSubtraction = 1;
    public static int sheepHerdedScore = 1;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        text = GetComponent<TextMeshProUGUI>();
        text.text = "000000";
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "" + score.ToString("000000"); //always display 6 digits
    }

    public void AddScore(int x)
    {
        score += x;
    }

    public void SubtractScore(int x)
    {
        score -= x;
    }
}
