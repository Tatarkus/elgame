using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
    
public class PlayerManager : MonoBehaviour
{
    public int id;
    public string username;
    float stepSize = 0.1333f;
    public Controller2D controller;
    Vector2 previousState;

    private void Start()
    {
        Canvas c = GetComponentInChildren(typeof(Canvas)) as Canvas;
        Text t = c.GetComponentInChildren(typeof(Text)) as Text;
        previousState = this.transform.position;
        t.text = username;
        
    }

    public void MoveCheck(Vector3 _position)
    {
        Vector3 _nextMove = _position - this.transform.position;
        controller.nextMoveCommand = _nextMove.normalized;
        this.transform.position = _position;
     
    }

    public void LocalMove(Vector3 _position)
    {
        //client prediction goes here previousState
        stepSize = 2 *Time.deltaTime;
        //Debug.LogError($"Smooth {Time.smoothDeltaTime}");
        //Debug.LogError($"1 over{1f/Time.smoothDeltaTime}");
        this.transform.position += _position * stepSize;
        controller.nextMoveCommand = _position;
    }

    public void Move(int _id,Vector3 _position)
    {   
        if(id == _id)
        {
            this.transform.position = _position;
        }
        else
        {
             //do some player interpolation here
        Vector3 _nextMove = _position - this.transform.position;
        controller.nextMoveCommand = _nextMove.normalized;
        this.transform.position = _position;
        }
        
    }

    //This one is only for Debug purposes
    public void OfflineMove(Vector3 _position)
    {
        Debug.Log($"direction {_position}");
        this.transform.position += _position * stepSize;
        controller.nextMoveCommand = _position;
        //this.transform.position = _position; 
    }
}

