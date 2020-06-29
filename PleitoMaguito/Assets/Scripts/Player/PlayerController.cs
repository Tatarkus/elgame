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
            Input.GetKey(KeyCode.W),
            Input.GetKey(KeyCode.S),
            Input.GetKey(KeyCode.D),
            Input.GetKey(KeyCode.A),
        };

        ClientSend.PlayerMovement(_inputs);
        /*Vector3 nextmove = new Vector3((_inputs[2] ? 1 : 0)-(_inputs[3] ? 1 : 0),
            (_inputs[0] ? 1 : 0) - (_inputs[1] ? 1 : 0),0);

        controller.nextMoveCommand = nextmove;*/
    }
}
