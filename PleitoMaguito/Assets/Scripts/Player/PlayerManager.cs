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
    public Vector3 serverState;
    public int lastPacketId = 0;
    public Vector3 movimiento;
    public int lastAck = 0;
    public float stepSpeed;
    private void Start()
    {
        Canvas c = GetComponentInChildren(typeof(Canvas)) as Canvas;
        Text t = c.GetComponentInChildren(typeof(Text)) as Text;
        prevStates = new Vector3[1000];
        prevStates[0] = this.transform.position;
        serverState = this.transform.position;
        t.text = username;
        

    }

    public void ClientPrediction(bool[] _inputs)
    {


        stepSpeed = 0.01666666f;

        movimiento = new Vector3((_inputs[2] ? 1 : _inputs[3] ? -1 : 0),
                (_inputs[0] ? 1 : _inputs[1] ? -1 : 0));

        //Move(this.transform.position + movimiento * stepSpeed);
        
            
        if (lastPacketId >= 1000)
        {
            lastPacketId = 0;
        }
        
        ClientSend.PlayerMovement(lastPacketId, _inputs);
        prevStates[lastPacketId] = movimiento;
        //Debug.Log($"XXXXXXXX lastPacketID {lastPacketId} moviemiento: {movimiento} XXXXXXXXX");
       // Debug.Log($"******** prevStates[lastPacketId] = {prevStates[lastPacketId]}*********");

        



        Vector3 posicion = serverState;
        
        //Debug.Log($"DEBUG DE POSICION DEL CLIENTE: {this.transform.position}");
        //Debug.Log($"Paquete: {lastAck}");
        //Debug.Log($"Ultimo paquete enviado: {lastPacketId}");
        //Debug.Log($"Posicion retornada por el servidor: {serverState}");

        for (int i = lastAck; i <= lastPacketId; i++)
        {
            //Debug.Log($" revisando paquete.... {i}");
            //Debug.Log($"aplicando inputs {prevStates[i]} con velocidad {stepSpeed} a la posicion: {serverState}");
            posicion = posicion + prevStates[i] * stepSpeed;
            
            //Debug.Log($"resultó la posicion {posicion}");
        }
        Debug.Log($"UR HERE {posicion}");
        this.transform.position = posicion;
        controller.nextMoveCommand = movimiento;
        //this.transform.position = posicion;
        lastAck += 1;
        lastPacketId++;
    }

    public void PlayerReconciliation(int _lastAck,Vector3 _position)
    {
        serverState = _position;
        lastAck = _lastAck;
        /*Debug.Log($"DEBUG DE POSICION DEL CLIENTE: {this.transform.position}");
        Debug.Log($"Paquete: {_lastAck}");
        Debug.Log($"Ultimo paquete enviado: {lastPacketId}");
        Debug.Log($"Posicion retornada por el servidor: {_position}");
        for (int i = _lastAck; i <= lastPacketId; i++)
        {
            Debug.Log($" pasos restantes {lastPacketId - i}");
            Debug.Log($"aplicando inputs {prevStates[_lastAck]} con velocidad {stepSpeed} a la posicion: {_position}");
            _position += prevStates[_lastAck] *stepSpeed;
            Debug.Log($"resultó la posicion {_position}");



        }
        if (_position == this.transform.position)
        {

            Debug.Log($"CORRECT PREDICT");
        }
        else
        {
            Debug.Log($"INCORRECT client: {this.transform.position} server: {_position}");
        }*/
    }

    public void Move(Vector3 _position)
    {
        //do some player interpolation here
        Vector3 _nextMove = _position - this.transform.position;
        controller.nextMoveCommand = _nextMove.normalized;
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

