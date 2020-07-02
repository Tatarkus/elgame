using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
    
public class PlayerManager : MonoBehaviour
{
    public int id;
    public string username;
    //TODO: set stepSize from server
    public Controller2D controller;
    public Vector3[] prevStates;
    public int lastPacketId = 0;
    public Vector3 movimiento;
    public int lastAck = 0;
    public float stepSpeed;
    private void Start()
    {
        Canvas c = GetComponentInChildren(typeof(Canvas)) as Canvas;
        Text t = c.GetComponentInChildren(typeof(Text)) as Text;
        prevStates = new Vector3[100];
        prevStates[0] = this.transform.position;
        t.text = username;
      
    }

    public void ClientPrediction(bool[] _inputs)
    {

        stepSpeed = Time.smoothDeltaTime * 2;

         movimiento = new Vector3((_inputs[2] ? 1 : _inputs[3] ? -1 : 0),
                (_inputs[0] ? 1 : _inputs[1] ? -1 : 0));

        if(lastPacketId >= 99)
        {
            lastPacketId = 0;
        }
        prevStates[lastPacketId] = this.transform.position+ (movimiento  * stepSpeed);
        ClientSend.PlayerMovement(lastPacketId, _inputs);
        lastPacketId++;
        //this.transform.position += movimiento * 2 * Time.smoothDeltaTime;
        //controller.nextMoveCommand = movimiento;
        Debug.Log($"last ack: {lastAck} and the last packet: {lastPacketId}");
        for (int i = lastAck; i < lastPacketId; i++)
        {
            Debug.Log($"Prev States: {prevStates[i]}");
            controller.nextMoveCommand = prevStates[i] - this.transform.position;
            this.transform.position = prevStates[i];
            
        }
    }

    public void LocalMove(int _lastAck,Vector3 _position)
    {

    }

    public void Move(Vector3 _position)
    {   
        //do some player interpolation here
        Vector3 _nextMove = _position - this.transform.position;
        //controller.nextMoveCommand = _nextMove.normalized;
        this.transform.position = _position;

        
    }

    //This one is only for Debug purposes
    public void OfflineMove(Vector3 _position)
    {
        this.transform.position += _position * 2*Time.deltaTime;
        controller.nextMoveCommand = _position;
        //this.transform.position = _position; 
    }
}

