using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultScreenManager : MonoBehaviour
{
    public GameObject resultScreen;
    public List<GameObject> players;
    public int oneStarMinScore;
    public int twoStarMinScore;
    public int threeStarMinScore;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ((GameTimer.Instance.minutes <= 0 && GameTimer.Instance.seconds <= 0) || ObjectiveCounter.Instance.sheepLeft == 0)
        {
            StopGame();
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
