using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance { get; private set; }

    public List<Character> playerList = new List<Character>();
    public List<GameObject> playerHealthBar = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
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
        //not sure if needed but may need a code to empty playerList when restarting level
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
