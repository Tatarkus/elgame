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
        
        GameManager.players[Client.instance.myId].ClientPrediction(_inputs);

        
    }


}
