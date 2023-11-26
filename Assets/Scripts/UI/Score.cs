using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public static Score Instance { get; private set; }

    TextMeshProUGUI text;

    public int score = 0;
    public int playerDeathSubtraction = 1;
    public int sheepLostSubtraction = 1;
    public int sheepHerdedScore = 1;

    // Start is called before the first frame update
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
