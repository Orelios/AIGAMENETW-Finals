using ExitGames.Client.Photon;
using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviourPun
{
    public static Score Instance { get; private set; }

    TextMeshProUGUI text;

    public int score = 0;
    public int playerDeathSubtraction = 1;
    public int sheepLostSubtraction = 1;
    public int sheepHerdedScore = 1;

    private const byte ADD_SCORE_EVENT = 0;
    private const byte SUBTRACT_SCORE_EVENT = 1;

    // Start is called before the first frame update
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
        score = 0;
        text = GetComponent<TextMeshProUGUI>();
        text.text = "00000";
    }

    // Update is called once per frame
    void Update()
    {
        if (score <= -9999)
        {
            score = -9999;
        }
        text.text = "" + score.ToString("00000"); //always display 6 digits
    }

    private void OnEnable() //listen to when an event is dispatched by Photon
    {
        PhotonNetwork.NetworkingClient.EventReceived += NetworkingClient_EventReceived; //if you want events to always fire on the object whether it's enabled or not, move this code to on Awake() then remove upon destroyed
    }

    private void OnDisable() //events won't fire on this object while it's disabled
    {
        PhotonNetwork.NetworkingClient.EventReceived -= NetworkingClient_EventReceived; //remove listener
    }

    private void NetworkingClient_EventReceived(EventData obj)
    {
        if (obj.Code == ADD_SCORE_EVENT)
        {
            object[] datas = (object[])obj.CustomData;
            int score = (int)datas[0];
        }
        if (obj.Code == SUBTRACT_SCORE_EVENT)
        {
            object[] datas = (object[])obj.CustomData;
            int score = (int)datas[1];
        }
    }

    public void AddScore(int x)
    {
        score += x;
        object[] datas = new object[] { score };
        PhotonNetwork.RaiseEvent(ADD_SCORE_EVENT, datas, RaiseEventOptions.Default, SendOptions.SendReliable);
    }

    public void SubtractScore(int x)
    {
        score -= x;
        object[] datas = new object[] { score };
        PhotonNetwork.RaiseEvent(SUBTRACT_SCORE_EVENT, datas, RaiseEventOptions.Default, SendOptions.SendReliable);
    }
}
