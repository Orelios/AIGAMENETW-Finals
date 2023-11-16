using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public float currHealth;
    [SerializeField]
    public float maxHealth = 3.0f;

    // Start is called before the first frame update
    void Start()
    {
        currHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TakeDamage(float damage)
    {
        currHealth -= damage;
        if (currHealth <= 0)
        {
            GetComponent<Respawn>().StartRespawn();
            Deactivate();
        }
    }

    public void ResetHealth()
    {
        currHealth = maxHealth;
    }

    public void Activate()
    {
        //this.gameObject.SetActive(true);
        //GetComponent<MeshRenderer>().enabled = true;
        //transform.GetChild(0).GetComponent<MeshRenderer>().enabled = true;
        //transform.GetChild(0).GetComponent<CharacterShooting>().enabled = true;
        transform.GetChild(0).gameObject.SetActive(true);
        GetComponent<CharacterControllerMovement>().enabled = true;
    }

    public void Deactivate()
    {
        //this.gameObject.SetActive(false);
        //transform.GetChild(0).GetComponent<MeshRenderer>().enabled = false;
        //transform.GetChild(0).GetComponent<CharacterShooting>().enabled = false;
        transform.GetChild(0).gameObject.SetActive(false);
        GetComponent<CharacterControllerMovement>().enabled = false;
    }
}
