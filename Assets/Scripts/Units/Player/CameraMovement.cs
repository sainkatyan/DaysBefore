using Input;
using Unity.Collections.LowLevel.Unsafe;
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
        public void Init(InputController inputController, PlayerMovement playerMovement)
        {
            this.inputController = inputController;
            this.playerMovement = playerMovement;

            ChangeCameraMode();
        }

        private void ChangeCameraMode(bool isPlayerDead = false)
        {
            Camera mainCamera = Camera.main;
            if (mainCamera == null) return;
            mainCamera.transform.SetParent(this.transform);
            mainCamera.transform.localPosition = playerCameraPosition;
            Debug.Log("Main Camera successfully attached to Camera Pivot.");
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
    }
}