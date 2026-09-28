using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class InputManager: MonoBehaviour
{
    PlayerControls playerControls;

    //Movement Action
    [SerializeField] Vector2 movementInput;

    //Camera Action
    [SerializeField] Vector2 cameraInput;

    //Interaction Action

    private void OnEnable()
    {
        if(playerControls == null)
        {
            playerControls = new PlayerControls();


            //This is the section that controls what happens when each button is pressed----------------------------------

            //Flying Action
            playerControls.Movement.Move.performed += i => movementInput = i.ReadValue<Vector2>();
            
            //Camera Action
            playerControls.Camera.CameraMove.performed += i => cameraInput = i.ReadValue<Vector2>();

            //Interactions

            playerControls.Interactions.Flap.performed += i => Debug.Log("Flap performed");
            playerControls.Interactions.Poop.performed += i => Debug.Log("Poop performed");
            playerControls.Interactions.Boost.performed += i =>Debug.Log("Boost performed");
            playerControls.Interactions.NoseDive.performed += i => Debug.Log("Nose Dive performed");
        }

        playerControls.Enable();
    }


    private void OnDisable()
    {
        playerControls.Disable();
    }
}
