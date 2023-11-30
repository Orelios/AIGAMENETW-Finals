using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultScreenManager : MonoBehaviour
{
    public GameObject resultScreen;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ((GameTimer.Instance.minutes == 0 && GameTimer.Instance.seconds == 0) || ObjectiveCounter.Instance.sheepLeft == 0)
        {
            resultScreen.SetActive(true);
        }
    }
}
