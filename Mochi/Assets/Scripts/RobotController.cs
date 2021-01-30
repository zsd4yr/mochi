using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class RobotController : MonoBehaviour
{
    public static string RobotTag => "Robot";

    public Camera cam;
    public NavMeshAgent agent;

    [ReadOnly]
    [SerializeField]
    private Queue<IRobotCommand> Commands;

    void Start()
    {
        this.Commands = new Queue<IRobotCommand>();
    }

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
                var moveCommand = new RobotMoveCommand(hit.point, mouseDown);
                this.EnqueueCommand(moveCommand);
            }
        }        
    }

    public void EnqueueCommand(IRobotCommand command)
        => this.Commands.Enqueue(command);

    public void OnExecuteQueue()
        => StartCoroutine(this.ExecuteQueue());

    IEnumerator ExecuteQueue()
    {
        while(this.Commands.Any())
        {
            var command = this.Commands.Peek();
            switch (command)
            {
                case RobotActionCommand robotActionCommand:
                    yield return null;
                    break;
                case RobotMoveCommand robotMoveCommand:
                    if (IsAtDestination(agent.transform.position, robotMoveCommand.WorldPosition))
                    {
                        this.Commands.Dequeue();
                    }
                    else
                    {
                        if (agent.destination != robotMoveCommand.WorldPosition)
                        {
                            agent.SetDestination(robotMoveCommand.WorldPosition);
                            Debug.Log($"Setting new Robot destination to {robotMoveCommand.WorldPosition}");
                        }
                        yield return null;
                    }
                    break;
            }
        }
        Debug.Log($"Robot's Command Queue is now empty.");

        yield return null;
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
}
