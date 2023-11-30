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
            ObjectiveCounter.Instance.sheepHerded += 1;
            ObjectiveCounter.Instance.sheepLeft -= 1;
            other.gameObject.GetComponent<SheepBT>().isInsideFence = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Sheep"))
        {
            Score.Instance.SubtractScore(Score.Instance.sheepLostSubtraction);
            ObjectiveCounter.Instance.sheepHerded -= 1;
            ObjectiveCounter.Instance.sheepLeft += 1;
            other.gameObject.GetComponent<SheepBT>().isInsideFence = false;
        }
    }
}
