using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace PlayerLocomotion
{

    public class XZ_Movement : MonoBehaviour
    {
        [SerializeField] InputManager inputManager;

        //public variables
        [SerializeField] float movementSpeed = 7;
        [SerializeField] float rotationSpeed = 5;
        [SerializeField] Transform cameraObject;
        [SerializeField] Rigidbody player;

        // movement variables
        Vector3 moveDirection;
     
        Vector2 movementInput;
        float verticalInput;
        float horizontalInput;

        // direction variables

        private void Awake()
        {
           // inputManager = GetComponent<InputManager>();
        }
        public void OnMove()
        {
            movementInput = inputManager.ReadMovement();
            verticalInput = movementInput.y;
            horizontalInput = movementInput.x;
        }


        private void HandleMovement()
        {

            //forward value
            moveDirection = cameraObject.forward * verticalInput;
            moveDirection += cameraObject.right * horizontalInput;
            moveDirection.Normalize();

            moveDirection.y = 0; // this is subject to change when introducing flying

            //adjusting speed based on float
            moveDirection *= movementSpeed;

            Vector3 movementVelocity = moveDirection;
            player.linearVelocity = moveDirection;
        }

        private void HandleRotation()
        {
            Vector3 targetDirection = Vector3.zero;

            targetDirection = cameraObject.forward * verticalInput;
            targetDirection += cameraObject.right * horizontalInput;

            targetDirection.y = 0;
            targetDirection.Normalize();

            Quaternion targetRotation = Quaternion.LookRotation(targetDirection, Vector3.up);
            Quaternion playerRotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

            player.transform.rotation = playerRotation;
        }

        private void FixedUpdate()
        {
            HandleMovement();
            HandleRotation();
        }


    }

}