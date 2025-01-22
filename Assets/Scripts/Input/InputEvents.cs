using UnityEngine;

namespace Input
{
    public class InputEvents : MonoBehaviour
    {
        private static PlayerContol inputActions;

        private void Awake()
        {
            InitializeControl();
        }

        private void InitializeControl()
        {
            inputActions = new PlayerContol();
            EnablePlayerInput();
        }

        private static void EnablePlayerInput()
        {
            inputActions.Player.Enable();
        }

        public static void DisablePlayerInput()
        {
            inputActions.Player.Disable();
        }

        public static Vector2 GetMoveInput()
        {
            return inputActions.Player.Move.ReadValue<Vector2>();
        }

        public static Vector2 GetRotateInput()
        {
            return inputActions.Player.Rotate.ReadValue<Vector2>();
        }
    }
}
