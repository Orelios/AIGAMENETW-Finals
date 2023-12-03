using ExitGames.Client.Photon;
using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class ObjectiveCounter : MonoBehaviourPun
{
    public static ObjectiveCounter Instance { get; private set; }

    TextMeshProUGUI text;

    public int sheepHerded = 0;
    public int sheepLeft;
    public int playerDeathTotal = 0;
    [SerializeField] private int initialSheepHerded = 0;
    [SerializeField] private int initialSheepLeft;
    [SerializeField] private int initialPlayerDeathTotal = 0;

    private const byte ADD_SHEEP_HERDED_EVENT = 0;
    private const byte SUBTRACT_SHEEP_HERDED_EVENT = 1;
    private const byte ADD_SHEEP_LEFT_EVENT = 2;
    private const byte SUBTRACT_SHEEP_LEFT_EVENT = 3;
    private const byte ADD_PLAYER_DEATH_TOTAL_EVENT = 4;
    private const byte SUBTRACT_PLAYER_DEATH_TOTAL_EVENT = 5;

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
        sheepHerded = initialSheepHerded;
        sheepLeft = initialSheepLeft;
        playerDeathTotal = initialPlayerDeathTotal;
        text = GetComponent<TextMeshProUGUI>();
        //text.text = "" + sheepLeft + " left";
        text.text = "" + sheepLeft;
    }

    // Update is called once per frame
    void Update()
    {
        //text.text = "" + sheepLeft + " left";
        text.text = "" + sheepLeft;
    }

    public void RestartObjectiveCounter()
    {
        sheepHerded = initialSheepHerded;
        sheepLeft = initialSheepLeft;
        playerDeathTotal = initialPlayerDeathTotal;
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
        if (obj.Code == ADD_SHEEP_HERDED_EVENT)
        {
            object[] datas = (object[])obj.CustomData;
            int sheepHerded = (int)datas[0];
        }
        if (obj.Code == SUBTRACT_SHEEP_HERDED_EVENT)
        {
            object[] datas = (object[])obj.CustomData;
            int sheepHerded = (int)datas[0];
        }
        if (obj.Code == ADD_SHEEP_LEFT_EVENT)
        {
            object[] datas = (object[])obj.CustomData;
            int sheepLeft = (int)datas[0];
        }
        if (obj.Code == SUBTRACT_SHEEP_LEFT_EVENT)
        {
            object[] datas = (object[])obj.CustomData;
            int sheepLeft = (int)datas[0];
        }
        if (obj.Code == ADD_PLAYER_DEATH_TOTAL_EVENT)
        {
            object[] datas = (object[])obj.CustomData;
            int playerDeathTotal = (int)datas[0];
        }
        if (obj.Code == SUBTRACT_PLAYER_DEATH_TOTAL_EVENT)
        {
            object[] datas = (object[])obj.CustomData;
            int playerDeathTotal = (int)datas[0];
        }
    }

    public void AddSheepHerded()
    {
        sheepHerded += 1;
        object[] datas = new object[] { sheepHerded };
        PhotonNetwork.RaiseEvent(ADD_SHEEP_HERDED_EVENT, datas, RaiseEventOptions.Default, SendOptions.SendReliable);
    }

    public void SubtractSheepHerded()
    {
        sheepHerded -= 1;
        object[] datas = new object[] { sheepHerded };
        PhotonNetwork.RaiseEvent(SUBTRACT_SHEEP_HERDED_EVENT, datas, RaiseEventOptions.Default, SendOptions.SendReliable);
    }

    public void AddSheepLeft()
    {
        sheepLeft += 1;
        object[] datas = new object[] { sheepLeft };
        PhotonNetwork.RaiseEvent(ADD_SHEEP_LEFT_EVENT, datas, RaiseEventOptions.Default, SendOptions.SendReliable);
    }

    public void SubtractSheepLeft()
    {
        sheepLeft -= 1;
        object[] datas = new object[] { sheepLeft };
        PhotonNetwork.RaiseEvent(SUBTRACT_SHEEP_LEFT_EVENT, datas, RaiseEventOptions.Default, SendOptions.SendReliable);
    }

    public void AddPlayerDeathTotal()
    {
        playerDeathTotal += 1;
        object[] datas = new object[] { playerDeathTotal };
        PhotonNetwork.RaiseEvent(ADD_PLAYER_DEATH_TOTAL_EVENT, datas, RaiseEventOptions.Default, SendOptions.SendReliable);
    }

    public void SubtractPlayerDeathTotal()
    {
        playerDeathTotal -= 1;
        object[] datas = new object[] { playerDeathTotal };
        PhotonNetwork.RaiseEvent(SUBTRACT_PLAYER_DEATH_TOTAL_EVENT, datas, RaiseEventOptions.Default, SendOptions.SendReliable);
    }
}
