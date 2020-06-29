using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
    
public class PlayerManager : MonoBehaviour
{
    public int id;
    public string username;
    public Controller2D controller;

    private void Start()
    {
        Canvas c = GetComponentInChildren(typeof(Canvas)) as Canvas;
        Text t = c.GetComponentInChildren(typeof(Text)) as Text;
        t.text = username;

    }

    public void Move(Vector3 _position)
    {
        Vector3 _nextMove = _position - this.transform.position;
        controller.nextMoveCommand = _nextMove.normalized;
        this.transform.position = _position;
        

    }
}

