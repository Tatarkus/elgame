using RPGM.Core;
using RPGM.Gameplay;
using UnityEngine;

namespace RPGM.UI
{
    /// <summary>
    /// Sends user input to the correct control systems.
    /// </summary>


    public class InputController : MonoBehaviour
    {
        public CharacterController2D controller;
        public float stepSize = 0.1f;
        Vector3 movimiento = new Vector3(0, 0, 0);
        //GameModel model = Schedule.GetModel<GameModel>();

        public enum State
        {
            CharacterControl,
            DialogControl,
            Pause
        }

        State state;

        public void ChangeState(State state) => this.state = state;

        private void Start()
        {

        }
        void Update()
        {
            switch (state)
            {
                case State.CharacterControl:
                    CharacterControl();
                    break;
                case State.DialogControl:
                    //DialogControl();
                    break;
            }
        }

        void CharacterControl()
        {
            /*
            if (Input.GetKey(KeyCode.UpArrow))
            {
	            if ((Input.GetKey(KeyCode.UpArrow)) && (Input.GetKey(KeyCode.RightArrow)))
		            controller.nextMoveCommand = (Vector3.up * stepSize) + (Vector3.right * stepSize);
	            else if ((Input.GetKey(KeyCode.UpArrow)) && (Input.GetKey(KeyCode.LeftArrow)))
		            controller.nextMoveCommand = (Vector3.up * stepSize) + (Vector3.left * stepSize);
	            else
		            controller.nextMoveCommand = Vector3.up * stepSize;
            }
            else if (Input.GetKey(KeyCode.DownArrow))
            {
                if ((Input.GetKey(KeyCode.DownArrow)) && (Input.GetKey(KeyCode.RightArrow)))
                    controller.nextMoveCommand = (Vector3.down * stepSize) + (Vector3.right * stepSize);
                else if ((Input.GetKey(KeyCode.DownArrow)) && (Input.GetKey(KeyCode.LeftArrow)))
                    controller.nextMoveCommand = (Vector3.down * stepSize) + (Vector3.left * stepSize);
                else
                    controller.nextMoveCommand = Vector3.down * stepSize;
			}
            else if (Input.GetKey(KeyCode.RightArrow))
                controller.nextMoveCommand = Vector3.right* stepSize;
            else if (Input.GetKey(KeyCode.LeftArrow))
                controller.nextMoveCommand = Vector3.left * stepSize;
            else
                controller.nextMoveCommand = Vector3.zero;
            */

            if (Input.GetKey(KeyCode.UpArrow))
            {
                movimiento += Vector3.up;
            }
            else if (Input.GetKey(KeyCode.DownArrow))
            {
                movimiento += Vector3.down;
            }

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                movimiento += Vector3.left;
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                movimiento += Vector3.right;
            }
            controller.nextMoveCommand = movimiento.normalized*stepSize;
            movimiento = Vector3.zero;

            if (Input.GetKey(KeyCode.Space))
            {
                stepSize = 0.2f;
            } 
            if(Input.GetKeyUp(KeyCode.Space))
                stepSize = 0.1f;
        }
    }
}