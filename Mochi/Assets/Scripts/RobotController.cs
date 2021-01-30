using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class RobotController : MonoBehaviour
{
    public Camera cam;
    public NavMeshAgent agent;
    bool isMousePressed = false;

    // Update is called once per frame
    void Update()
    {
        if(Mouse.current.leftButton.wasPressedThisFrame)
        {
            Ray ray = cam.ScreenPointToRay(Mouse.current.position.ReadDefaultValue());
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit))
            {
                agent.SetDestination(hit.point);
            }
        }
        
    }
}
