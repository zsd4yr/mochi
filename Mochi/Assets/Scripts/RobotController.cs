using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class RobotController : MonoBehaviour, GameControls.IGameControllerActions
{
    public Camera cam;
    public NavMeshAgent agent;
    bool isMousePressed = false;
    Vector3 mouseDown;
    GameControls controls;

    public void OnMovement(InputAction.CallbackContext context)
    {

    }

    public void OnInteract(InputAction.CallbackContext context)
    {
        //Vector2 input = context.ReadValue<Vector2>();
        mouseDown.x = Mouse.current.position.x.ReadValue();
        mouseDown.y = Mouse.current.position.y.ReadValue();
        //mouseDown.x = input.x;
        //mouseDown.z = input.y;

        isMousePressed = true;
    }

    void OnEnable()
    {
        controls = new GameControls();
        controls.GameController.SetCallbacks(this);
        controls.Enable();
    }

    void OnDisable()
    {
        controls.Disable();

    }

    // Update is called once per frame
    void Update()
    {
        if(isMousePressed)
        {
            Ray ray = cam.ScreenPointToRay(mouseDown);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit))
            {
                agent.SetDestination(hit.point);
            }
        }
        
    }
}
