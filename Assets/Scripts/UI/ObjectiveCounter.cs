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
    [SerializeField] private int initialSheepHerded = 0;
    [SerializeField] private int initialSheepLeft;
    [SerializeField] private int initialPlayerDeathTotal = 0;

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
        sheepHerded = initialSheepHerded;
        sheepLeft = initialSheepLeft;
        playerDeathTotal = initialPlayerDeathTotal;
        text = GetComponent<TextMeshProUGUI>();
        //text.text = "" + sheepLeft + " left";
        text.text = "" + sheepLeft;
    }

    // Update is called once per frame
    void Update()
    {
        //text.text = "" + sheepLeft + " left";
        text.text = "" + sheepLeft;
    }

    public void RestartObjectiveCounter()
    {
        sheepHerded = initialSheepHerded;
        sheepLeft = initialSheepLeft;
        playerDeathTotal = initialPlayerDeathTotal;
    }

    public void AddSheepHerded()
    {
        sheepHerded += 1;
    }

    public void SubtractSheepHerded()
    {
        sheepHerded -= 1;
    }

    public void AddSheepLeft()
    {
        sheepLeft += 1;
    }

    public void SubtractSheepLeft()
    {
        sheepLeft -= 1;
    }

    public void AddPlayerDeathTotal()
    {
        playerDeathTotal += 1;
    }

    public void SubtractPlayerDeathTotal()
    {
        playerDeathTotal -= 1;
    }
}
