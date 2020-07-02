using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //public Transform camTransform;
    Vector3 mousePos;

    private void Start()
    {
        //Camera should "get" the player prefab, not the other way around
        //Camera cam1 = GameObject.Find("Main Camera").GetComponent<Camera>();


    }
    private void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(new Vector3 (Input.mousePosition.x,Input.mousePosition.y,10));
 
        if (Input.GetKeyDown(KeyCode.Mouse0))
        { 
            ClientSend.PlayerFireball(mousePos);
        }
        
    }
    private void FixedUpdate()
    {
        SendInputToServer();
    }

    private void SendInputToServer()
    {
        bool[] _inputs = new bool[]
        {
            Input.GetKey(KeyCode.W),
            Input.GetKey(KeyCode.S),
            Input.GetKey(KeyCode.D),
            Input.GetKey(KeyCode.A),
        };
        Vector3 movimiento = new Vector3((_inputs[2] ? 1 : _inputs[3] ? -1 : 0),
                (_inputs[0] ? 1 : _inputs[1] ? -1 : 0));
        GameManager.players[Client.instance.myId].LocalMove(movimiento);
        
        ClientSend.PlayerMovement(_inputs);

    }
}
