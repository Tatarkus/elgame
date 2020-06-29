﻿using UnityEngine;

namespace RPGM.UI
{
    /// <summary>
    /// Sends user input to the correct control systems.
    /// </summary>


    public class PlayerControllerOffline : MonoBehaviour
    {
        public Controller2D controller;
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
            if (Input.GetKey(KeyCode.W))
            {
                movimiento += Vector3.up;
            }
            else if (Input.GetKey(KeyCode.S))
            {
                movimiento += Vector3.down;
            }

            if (Input.GetKey(KeyCode.A))
            {
                movimiento += Vector3.left;
            }
            else if (Input.GetKey(KeyCode.D))
            {
                movimiento += Vector3.right;
            }
            controller.nextMoveCommand = movimiento.normalized * stepSize;
            movimiento = Vector3.zero;

            if (Input.GetKey(KeyCode.LeftShift))
            {
                stepSize = 0.2f;
            }
            if (Input.GetKeyUp(KeyCode.LeftShift))
                stepSize = 0.1f;
        }
    }
}