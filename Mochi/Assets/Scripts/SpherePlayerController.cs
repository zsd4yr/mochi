using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpherePlayerController : MonoBehaviour
{
    public float Accellaration = 100;
    public float moveVert = 0;
    public float moveHor = 0;

    private Rigidbody rb;
    private Vector3 movement;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
        void Update()
    {

    }

    void FixedUpdate()
    {
        moveVert = Input.GetAxis("Vertical");
        moveHor = Input.GetAxis("Horizontal");

        movement = new Vector3(moveHor, 0, moveVert);
        rb.AddForce(movement * Accellaration);
        
    }
}
