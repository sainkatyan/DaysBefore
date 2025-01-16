using UnityEngine;

namespace Assets.Scripts.Input
{
    public class InputEvents : MonoBehaviour
    {
        public static PlayerContol InputActions;

        private void Awake()
        {
            InitializeControl();
        }

        private void InitializeControl()
        {
            InputActions = new PlayerContol();
            EnablePlayerInput();
        }
        public static void EnablePlayerInput()
        {
            InputActions.Player.Enable();
        }

        public static void DisablePlayerInput()
        {
            InputActions.Player.Disable();
        }

        public static Vector2 GetMoveInput()
        {
            return InputActions.Player.Move.ReadValue<Vector2>();
        }

        public static Vector2 GetRotateInput()
        {
            return InputActions.Player.Rotate.ReadValue<Vector2>();
        }
    }
}
