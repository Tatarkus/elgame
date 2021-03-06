﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public static Dictionary<int, PlayerManager> players = new Dictionary<int, PlayerManager>();

    public GameObject localPlayerPrefab;
    public GameObject playerPrefab;
    public GameObject fire;

    private void Start()
    {
        Client.instance.ConnectToServer();


    }
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Debug.Log("Instance already exists, destroying object!");
            Destroy(this);
        }
    }

    public void SpawnPlayer(int _id, string _username, Vector3 _position, Quaternion _rotation)
    {
        GameObject _player;
        if (_id == Client.instance.myId)
        {
            _player = Instantiate(localPlayerPrefab, _position, _rotation);

        }
        else
        {
            _player = Instantiate(playerPrefab, _position, _rotation);
        }

        _player.GetComponent<PlayerManager>().id = _id;
        _player.GetComponent<PlayerManager>().username = _username;
        players.Add(_id, _player.GetComponent<PlayerManager>());
    }

    public void RemovePlayer(int _id)
    {
        Debug.Log($"Removing player {_id}");
        Destroy(players[_id].gameObject);
        Destroy(players[_id].GetComponent<PlayerManager>());
        GameManager.players.Remove(_id);
    }

    public void FireballImpact(int _id, Vector3 _impactLocation)
    {
        if (fire == null) { 
            Instantiate(fire, _impactLocation,Quaternion.identity);
        }
        else
        {
            //Destroy(fire);
            Instantiate(fire, _impactLocation, Quaternion.identity);
        }
        
    }
}
