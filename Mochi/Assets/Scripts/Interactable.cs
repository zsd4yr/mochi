using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Interactable : MonoBehaviour
{
    //public Camera cam;
    public GameObject robot;
    bool isWithinBounds = false;
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
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.eKey.wasPressedThisFrame && isWithinBounds == true)
        {

            //Vector3 screenPoint = cam.WorldToScreenPoint(transform.position);
            //Vector3 worldPoint = cam.ScreenToWorldPoint(new Vector3(0.9f, 0.0f, -0.5f));


            //robot.GetComponent<RobotController>().positions = new Queue<RoboCommandMovement>(); 
            //robot.GetComponent<RobotController>().positions.Enqueue(new RoboCommandMovement(cam.ScreenToWorldPoint(new Vector3(0.9f, 0.0f, -0.5f)), new Vector3(0.9f, 0.0f, -0.5f)));
            //robot.GetComponent<RobotController>().positions.Enqueue(new RoboCommandMovement(cam.ScreenToWorldPoint(new Vector3(-0.1f, 0.0f, -1.0f)), new Vector3(-0.1f, 0.0f, -1.0f)));
            //robot.GetComponent<RobotController>().positions.Enqueue(new RoboCommandMovement(cam.ScreenToWorldPoint(new Vector3(-0.7f, 0.0f, -0.7f)), new Vector3(-0.7f, 0.0f, -0.7f)));
            robot.GetComponent<RobotController>().positions = new Queue<Vector3>();
            robot.GetComponent<RobotController>().positions.Enqueue(new Vector3(0.5f, -0.1f, -6.1f));
            robot.GetComponent<RobotController>().positions.Enqueue(new Vector3(-3.4f, -0.1f, -6.5f));
            robot.GetComponent<RobotController>().positions.Enqueue(new Vector3(0.5f, -0.1f, -6.1f));
            robot.GetComponent<RobotController>().hasRobocommand = robot.GetComponent<RobotController>().ExecuteQueue();
            
        }
    }
}
