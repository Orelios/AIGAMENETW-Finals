using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pitfall : MonoBehaviour
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
        float killDamage = other.GetComponent<Character>().currHealth;
        other.GetComponent<Character>().TakeDamage(killDamage);
    }

}
