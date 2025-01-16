using Assets.Scripts.Units.Player;
using UnityEngine;

namespace Assets.Scripts.Input
{
    public class InputController : MonoBehaviour
    {
        [HideInInspector] public Player player;

        public void InitializeController(Player baseController)
        {
            player = baseController;
        }

        public Vector2 MoveInput()
        {
            return InputEvents.GetMoveInput();
        }

        public Vector2 RotateInput()
        {
            return InputEvents.GetRotateInput();
        }
    }
}
