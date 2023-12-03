using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public float currHealth;
    [SerializeField]
    public float maxHealth = 3.0f;
    public int playerListIndex;

    // Start is called before the first frame update
    void Start()
    {
        currHealth = maxHealth;
        if (this.CompareTag("Player"))
        {
            PlayerManager.Instance.playerList.Add(this);
            playerListIndex = PlayerManager.Instance.playerList.Count - 1;
            PlayerManager.Instance.playerHealthBar[playerListIndex].GetComponent<PlayerHealthIcons>().player = this;
        }
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
            Debug.Log("Health is below 0!");
            //Score.Instance.SubtractScore(Score.Instance.playerDeathSubtraction);
            Score.Instance.score -= Score.Instance.playerDeathSubtraction;
            //ObjectiveCounter.Instance.AddPlayerDeathTotal();
            ObjectiveCounter.Instance.playerDeathTotal += 1;
            GetComponent<Respawn>().StartRespawn();
            Deactivate();
        }
    }

    public void TakeDamageEnemy(float damage)
    {
        currHealth -= damage;
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
        Debug.Log("Deactivate!");
        //this.gameObject.SetActive(false);
        //transform.GetChild(0).GetComponent<MeshRenderer>().enabled = false;
        //transform.GetChild(0).GetComponent<CharacterShooting>().enabled = false;
        transform.GetChild(0).gameObject.SetActive(false);
        GetComponent<CharacterControllerMovement>().enabled = false;
    }
}
