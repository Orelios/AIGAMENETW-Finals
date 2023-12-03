using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultScreenManager : MonoBehaviour
{
    public static ResultScreenManager Instance { get; private set; }

    public GameObject resultScreen;
    public List<GameObject> players;
    public int oneStarMinScore = 10;
    public int twoStarMinScore = 20;
    public int threeStarMinScore = 30;
    public int resultSheepHerded;
    public int resultPlayerDeaths;
    public int resultFinalScore;
    private bool isGameRunning = true;
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
        isGameRunning = true;
    }

    private void OnEnable()
    {
        isGameRunning = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameRunning == true)
        {
            if ((GameTimer.Instance.minutes <= 0 && GameTimer.Instance.seconds <= 0) || ObjectiveCounter.Instance.sheepLeft == 0)
            {
                StopGame();
                isGameRunning = false;
            }
        }
    }

    public void StopAllPlayerMovement()
    {
        foreach (GameObject player in players)
        {
            player.GetComponent<CharacterController>().enabled = false;
            player.GetComponentInChildren<CharacterShooting>().enabled = false;
        }
    }

    public void StopGame()
    {
        GameTimer.Instance.StopGameTimer();
        StopAllPlayerMovement();
        resultScreen.SetActive(true);
        DetermineStamp();
        SaveFinalCounts();
    }

    public void SaveFinalCounts()
    {
        resultFinalScore = Score.Instance.score;
        resultSheepHerded = ObjectiveCounter.Instance.sheepHerded;
        resultPlayerDeaths = ObjectiveCounter.Instance.playerDeathTotal;

    }

    public void DetermineStamp()
    {
        if (Score.Instance.score < oneStarMinScore)
        {
            resultScreen.transform.GetChild(3).gameObject.SetActive(true);
            resultScreen.transform.GetChild(4).gameObject.SetActive(false);
            resultScreen.transform.GetChild(5).gameObject.SetActive(false);
            resultScreen.transform.GetChild(6).gameObject.SetActive(false);
        }
        else if (Score.Instance.score >= oneStarMinScore && Score.Instance.score < twoStarMinScore)
        {
            resultScreen.transform.GetChild(3).gameObject.SetActive(false);
            resultScreen.transform.GetChild(4).gameObject.SetActive(true);
            resultScreen.transform.GetChild(5).gameObject.SetActive(false);
            resultScreen.transform.GetChild(6).gameObject.SetActive(false);
        }
        else if (Score.Instance.score >= twoStarMinScore && Score.Instance.score < threeStarMinScore)
        {
            resultScreen.transform.GetChild(3).gameObject.SetActive(false);
            resultScreen.transform.GetChild(4).gameObject.SetActive(false);
            resultScreen.transform.GetChild(5).gameObject.SetActive(true);
            resultScreen.transform.GetChild(6).gameObject.SetActive(false);
        }
        else if (Score.Instance.score >= threeStarMinScore)
        {
            resultScreen.transform.GetChild(3).gameObject.SetActive(false);
            resultScreen.transform.GetChild(4).gameObject.SetActive(false);
            resultScreen.transform.GetChild(5).gameObject.SetActive(false);
            resultScreen.transform.GetChild(6).gameObject.SetActive(true);
        }
    }
}
