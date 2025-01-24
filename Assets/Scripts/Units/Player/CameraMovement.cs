using Input;
using UnityEngine;

namespace Units.Player
{
    public class CameraMovement : MonoBehaviour
    {
        [SerializeField] private float lookSpeed = 1000f;

        private InputController inputController;
        private PlayerMovement playerMovement;
        private Camera playerCamera;
        private readonly Vector3 playerCameraPosition = new Vector3(1, 0, -5);
        private Player player;
        public void Init(Player player, InputController inputController, PlayerMovement playerMovement)
        {
            this.inputController = inputController;
            this.playerMovement = playerMovement;
            this.player = player;
            PlayerCameraMode();
            Subscribe();
        }

        private void Subscribe()
        {
            player.health.OnDeath += WorldCameraMode;
        }
        
        private void UnSubscribe()
        {
            player.health.OnDeath -= WorldCameraMode;
        }

        private void WorldCameraMode()
        {
            if (playerCamera == null) return;
            playerCamera.transform.SetParent(null);
        }

        private void PlayerCameraMode()
        {
            playerCamera = Camera.main;
            if (playerCamera == null) return;
            playerCamera.transform.SetParent(this.transform);
            playerCamera.transform.localPosition = playerCameraPosition;
        }

        private void Update()
        {
            var rotation = inputController.RotateInput() * (lookSpeed * Time.deltaTime);
            transform.localRotation *= Quaternion.Euler(rotation.y, 0f, 0f);
            transform.rotation *= Quaternion.Euler(0f, rotation.x, 0f);

            float xAngel = transform.localRotation.eulerAngles.x;
            AngelCorrection(xAngel);
            transform.localRotation = Quaternion.Euler(xAngel, transform.localRotation.eulerAngles.y, 0f);

            playerMovement.RotateMesh();
        }

        private static float AngelCorrection(float angle)
        {
            if (angle > 180f)
            {
                if (angle < 280f)
                {
                    angle = 280f;
                }
            }
            else
            {
                if (angle > 80f)
                {
                    angle = 80f;
                }
            }
            return angle;
        }

        private void OnDestroy()
        {
            UnSubscribe();
        }
    }
}