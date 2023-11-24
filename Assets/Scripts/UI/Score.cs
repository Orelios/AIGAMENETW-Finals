using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    TextMeshProUGUI text;

    public static int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        text = GetComponent<TextMeshProUGUI>();
        text.text = "Score: ";
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "Score: " + score;
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
