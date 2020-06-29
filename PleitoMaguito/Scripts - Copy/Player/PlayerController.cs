using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private void FixedUpdate()
    {
        SendInputToServer();
        
    }

    private void SendInputToServer()
    {
        
        bool[] _inputs = new bool[]
        {
            Input.GetKey(KeyCode.D),
            Input.GetKey(KeyCode.A),
            Input.GetKey(KeyCode.W),
            Input.GetKey(KeyCode.S),
        };
        ClientSend.PlayerMovement(_inputs);
    }
}
