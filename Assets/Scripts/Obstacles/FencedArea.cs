using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FencedArea : MonoBehaviour
{
    public Score score;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Sheep"))
        {
            score.AddScore(Score.sheepHerdedScore);
            other.gameObject.GetComponent<SheepBT>().isInsideFence = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Sheep"))
        {
            score.SubtractScore(Score.sheepLostSubtraction);
            other.gameObject.GetComponent<SheepBT>().isInsideFence = false;
        }
    }
}
