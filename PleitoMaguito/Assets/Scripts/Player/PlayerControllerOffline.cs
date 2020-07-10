using Unity.Mathematics;
using UnityEngine;


    /// <summary>
    /// Sends user input to the correct control systems.
    /// </summary>


    public class PlayerControllerOffline : MonoBehaviour
    {
        public PlayerManager playerManager;
        public float stepSize = 0.001f;
        public float baseStepSize = 0.001f;
    Vector3 direccion = new Vector3(0, 0, 0);
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
           
        }

    private void FixedUpdate()
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
            bool[] _inputs = new bool[]
         {
                Input.GetKey(KeyCode.W),
                Input.GetKey(KeyCode.S),
                Input.GetKey(KeyCode.D),
                Input.GetKey(KeyCode.A),
         };

            direccion= new Vector2((_inputs[2] ? 1 : _inputs[3] ? -1:0),
                (_inputs[0] ? 1 : _inputs[1] ? -1 : 0));

            playerManager.OfflineMove(direccion);
            //controller.nextMoveCommand = movimiento.normalized * stepSize;
            //movimiento = Vector3.zero;

            if (Input.GetKey(KeyCode.LeftShift))
            {
                stepSize =  baseStepSize*2;
            }
            if (Input.GetKeyUp(KeyCode.LeftShift))
                stepSize = baseStepSize;
        }
    }