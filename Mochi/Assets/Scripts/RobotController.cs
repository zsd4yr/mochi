using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class RobotController : MonoBehaviour
{
    public Camera cam;
    public NavMeshAgent agent;

    // Update is called once per frame
    void Update()
    {
        if(Mouse.current.leftButton.wasPressedThisFrame)
        {
            Vector3 mouseDown  = new Vector3();
            mouseDown.x = Mouse.current.position.x.ReadValue();
            mouseDown.y = Mouse.current.position.y.ReadValue();
            Ray ray = cam.ScreenPointToRay(mouseDown);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit))
            {
                agent.SetDestination(hit.point);
            }
        }
        
    }

    public void ExecuteQueue()
    {
        Queue<Vector3> positions = new Queue<Vector3>();
        positions.Enqueue(new Vector3(-0.1f, 0.0f, -1.0f));
        positions.Enqueue(new Vector3(0.9f, 0.0f, -0.5f));
        positions.Enqueue(new Vector3(-0.7f, 0.0f, -0.7f));
        int x = positions.Count;
        for (int i=0; i< x; i++)
        { 
            agent.SetDestination(positions.Peek());
            positions.Dequeue();
        }

    }
}
