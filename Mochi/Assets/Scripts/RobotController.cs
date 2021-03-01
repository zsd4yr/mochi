using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class RobotController : MonoBehaviour
{
    public static string RobotTag => "Robot";

    public float DirectionMagnitude;
    public GameObject DestinationMarkerPrefab;
    
    [ShowOnly]
    public NavMeshAgent Agent;

    //[ShowOnly]
    public Queue<IRobotCommand> Commands;
    //[SerializeField]

    void Start()
    {
        this.Commands = new Queue<IRobotCommand>();
        this.Agent = this.gameObject.GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        //if(Mouse.current.leftButton.wasPressedThisFrame)
        //{
        //    if (!EventSystem.current.IsPointerOverGameObject())
        //    {
        //        Vector3 mouseDown = new Vector3
        //        {
        //            x = Mouse.current.position.x.ReadValue(),
        //            y = Mouse.current.position.y.ReadValue()
        //        };
        //        Ray ray = CameraController.Instance().GetCurrentCamera().ScreenPointToRay(mouseDown);

        //        if (Physics.Raycast(ray, out RaycastHit hit))
        //        {
        //            var moveCommand = new RobotMoveAbsoluteCommand(hit.point, mouseDown);
        //            this.EnqueueCommand(moveCommand);
        //        }
        //    }
        //}        
    }

    public IRobotCommand PeekLastCommand()
        => this.Commands.Last();

    public void EnqueueCommand(IRobotCommand command)
        => this.Commands.Enqueue(command);

    public void OnExecuteQueue()
        => StartCoroutine(this.ExecuteQueue());

    public void OnDestroyQueue()
        => this.Commands.Clear();

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
                case RobotMoveAbsoluteCommand robotMoveAbsoluteCommand:
                    if (IsAtDestination(Agent.transform.position, robotMoveAbsoluteCommand.WorldPositionWithinNavMesh))
                    {
                        this.Commands.Dequeue();
                    }
                    else
                    {
                        var previousDestination = this.Agent.destination;

                        if (robotMoveAbsoluteCommand.IsWorldPositionWithinNavMeshSet())
                        {
                            this.Agent.SetDestination(robotMoveAbsoluteCommand.WorldPositionWithinNavMesh);
                            //PlaceMarkerAtSpot(this.Agent.destination);

                        }
                        else
                        {
                            this.Agent.SetDestination(robotMoveAbsoluteCommand.WorldPosition);
                            robotMoveAbsoluteCommand.SetWorldPositionWithinNavMesh(this.Agent.destination);
                            //PlaceMarkerAtSpot(this.Agent.destination);

                        }

                        if (this.Agent.destination != previousDestination)
                        {
                            Debug.Log($"Setting new Robot destination to {robotMoveAbsoluteCommand.WorldPositionWithinNavMesh}");
                            //PlaceMarkerAtSpot(this.Agent.destination);
                        }
                        if (this.Agent.destination != previousDestination)
                            PlaceMarkerAtSpot(this.Agent.destination);
                        yield return null;
                    }
                    break;
                case RobotMoveCommand robotMoveCommand:
                    if (IsAtDestination(Agent.transform.position, robotMoveCommand.WorldPositionWithinNavMesh))
                    {
                        this.Commands.Dequeue();
                    }
                    else
                    {
                        var previousDestination = this.Agent.destination;

                        if (robotMoveCommand.IsWorldPositionWithinNavMeshSet())
                        {
                            this.Agent.SetDestination(robotMoveCommand.WorldPositionWithinNavMesh);
                            //PlaceMarkerAtSpot(this.Agent.destination);

                        }
                        else
                        {
                            // modify the desired movement vector by the current position
                            var robotMoveTarget = robotMoveCommand.WorldPosition + this.gameObject.transform.position;
                            this.Agent.SetDestination(robotMoveTarget);
                            robotMoveCommand.SetWorldPositionWithinNavMesh(this.Agent.destination);
                            //PlaceMarkerAtSpot(this.Agent.destination);
                        }

                        if (this.Agent.destination != previousDestination)
                        {
                            Debug.Log($"Setting new Robot destination to {robotMoveCommand.WorldPositionWithinNavMesh}");
                            PlaceMarkerAtSpot(this.Agent.destination);
                        }
                        
                        yield return null;
                    }
                    break;
                    //Figure out way to move character to exact middle of square on floor
            }
        }
        Debug.Log($"Robot's Command Queue is now empty.");
        /*Snap robot to middle of last square ended up*/
        yield return null;
    }

    public void PlaceMarkerAtSpot(Vector3 loc)
    {
        if (DestinationMarkerPrefab == null)
            return;
        GameObject marker = GameObject.Instantiate(DestinationMarkerPrefab, loc, transform.rotation);
    }

    static bool IsAtDestination(Vector3 myPosition, Vector3 destination)
    {
        if (Mathf.Approximately(myPosition.x, destination.x) && 
            Mathf.Approximately(myPosition.z, destination.z))
        {
            return true;
        }

        return false;
    }
}
