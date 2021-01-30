using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class RobotController : MonoBehaviour
{
    public static string RobotTag => "Robot";

    public Camera cam;
    public NavMeshAgent agent;
    public bool hasRobocommand = false;
    Vector3 commandDestination; 
    public Queue<Vector3> positions;

    // Update is called once per frame
    void Update()
    {
        if(Mouse.current.leftButton.wasPressedThisFrame)
        {
            Vector3 mouseDown  = new Vector3();
            mouseDown.x = Mouse.current.position.x.ReadValue();
            mouseDown.y = Mouse.current.position.y.ReadValue();
            Ray ray = CameraController.Instance().GetCurrentCamera().ScreenPointToRay(mouseDown);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit))
            {
                agent.SetDestination(hit.point);
            }
        }

        if (hasRobocommand)
        {
            if (commandDestination != null)
            {
                agent.SetDestination(commandDestination);
            }


            //TODO If the agent cannot get to the destination then the list of robocommand won't be cycled through
            if(IsAtDestination(agent.transform.position, commandDestination))
            {
                hasRobocommand = ExecuteQueue();
            }
        }
        
    }

    static bool IsAtDestination(Vector3 myPosition, Vector3 destination)
    {
        if (Mathf.Approximately(myPosition.x, destination.x) && Mathf.Approximately(myPosition.z, destination.z))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool ExecuteQueue()
    {
        bool returnResult = false;
        int x = positions.Count;
        if (positions.Count > 0)
        {
            commandDestination = positions.Dequeue();
            returnResult = true;
        }

        return returnResult;
    }
}
