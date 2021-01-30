using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class Interactable : MonoBehaviour
{
    //public Camera cam;
    [ReadOnly]
    public GameObject robot;

    [ReadOnly]
    public bool isWithinBounds = false;

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, GetComponent<CapsuleCollider>().radius);
    }

    private void OnTriggerEnter(Collider other)
    {
        isWithinBounds = true;
    }

    private void OnTriggerExit(Collider other)
    {
        isWithinBounds = false;
    }


    // Start is called before the first frame update
    void Start()
    {
        this.robot = GameObject.FindGameObjectWithTag(RobotController.RobotTag);
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.eKey.wasPressedThisFrame && isWithinBounds == true)
        {
            robot.GetComponent<RobotController>().positions = new Queue<Vector3>();
            robot.GetComponent<RobotController>().positions.Enqueue(new Vector3(-4.5f, -13.4f, 5.9f));
            robot.GetComponent<RobotController>().positions.Enqueue(new Vector3(3.5f, -13.4f, -0.2f));
            robot.GetComponent<RobotController>().positions.Enqueue(new Vector3(-8.0f, -13.4f, -7.7f));
            robot.GetComponent<RobotController>().hasRobocommand = robot.GetComponent<RobotController>().ExecuteQueue();
            
        }
    }
}
