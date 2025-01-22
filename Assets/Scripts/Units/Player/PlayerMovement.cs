using Core;
using Input;
using UnityEngine;

namespace Units.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        public GameObject playeMesh;

        private Rigidbody rigidbody;
        private InputController inputController;
        private CameraMovement cameraMovement;

        private float movementSpeed;

        public void Init(InputController inputController, CameraMovement cameraMovement)
        {
            rigidbody = GetComponent<Rigidbody>();
            this.inputController = inputController;
            this.cameraMovement = cameraMovement;
            movementSpeed = GameManager.Instance.playerData.movementSpeed;
        }

        private void FixedUpdate()
        {
            var moveInput = inputController.MoveInput();

            Vector3 dir = new Vector3(Mathf.Sin(cameraMovement.transform.eulerAngles.y * Mathf.Deg2Rad), 0f, Mathf.Cos(cameraMovement.transform.eulerAngles.y * Mathf.Deg2Rad));
            var targetPosition = dir * moveInput.y + cameraMovement.transform.right * moveInput.x;

            targetPosition *= Time.fixedDeltaTime * movementSpeed;
            rigidbody.MovePosition(transform.position + targetPosition);

            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }

        public void RotateMesh()
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            playeMesh.transform.localRotation = Quaternion.Euler(0f, cameraMovement.transform.localRotation.eulerAngles.y, 0f);
        }
    }
}