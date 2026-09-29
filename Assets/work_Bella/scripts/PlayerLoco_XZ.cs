using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace PlayerLocomotion
{

    public class XZ_Movement : MonoBehaviour
    {
        [SerializeField] InputManager inputManager;

        //public variables
        [SerializeField] float movementSpeed;
        [SerializeField] Transform cameraObject;
        [SerializeField] Rigidbody player;

        //global variables
        Vector3 moveDirection;
        

        Vector2 movementInput;
        float verticalMovement;
        float horizontalMovement;

        private void Awake()
        {
           // inputManager = GetComponent<InputManager>();
        }
        public void OnMove()
        {
            movementInput = inputManager.ReadMovement();
            verticalMovement = movementInput.y;
            horizontalMovement = movementInput.x;

            HandleMovement();
        }


        private void HandleMovement()
        {

            //forward value
            moveDirection = cameraObject.forward * verticalMovement;
            moveDirection += cameraObject.right * horizontalMovement;
            moveDirection.Normalize();

            moveDirection.y = 0; // this is subject to change when introducing flying

            //adjusting speed based on float
            moveDirection *= movementSpeed;

            Vector3 movementVelocity = moveDirection;
            player.linearVelocity = moveDirection;
        }

        


    }

}