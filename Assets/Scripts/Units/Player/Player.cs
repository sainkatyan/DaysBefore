using Assets.Scripts.Input;
using UnityEngine;

namespace Assets.Scripts.Units.Player
{
    public class Player : MonoBehaviour
    {
        internal InputController inputController;
        public PlayerMovement playerMovement;
        public CameraMovement cameraMovement;

        private void Awake()
        {
            inputController = GetComponent<InputController>();
            inputController.InitializeController(this);

            playerMovement.Init(inputController, cameraMovement);
            cameraMovement.Init(inputController, playerMovement);
        }
    }
}
