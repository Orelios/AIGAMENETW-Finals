using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FencedArea : MonoBehaviour
{
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
            Score.Instance.AddScore(Score.Instance.sheepHerdedScore);
            ObjectiveCounter.Instance.AddSheepHerded();
            ObjectiveCounter.Instance.SubtractSheepLeft();
            other.gameObject.GetComponent<SheepBT>().isInsideFence = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Sheep"))
        {
            Score.Instance.SubtractScore(Score.Instance.sheepLostSubtraction);
            ObjectiveCounter.Instance.SubtractSheepHerded();
            ObjectiveCounter.Instance.AddSheepLeft();
            other.gameObject.GetComponent<SheepBT>().isInsideFence = false;
        }
    }
}
