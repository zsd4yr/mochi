using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class GasTriggerController : MonoBehaviour
{
    [ReadOnly]
    public bool isWithinBounds = false;

    Collider collider;

    public Vector3 opposite;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isWithinBounds = true;
            collider = other;
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isWithinBounds = false;
            collider = null;
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (collider != null && isWithinBounds == true)
        {
            var rigidbody = collider.GetComponent<Rigidbody>();
            opposite = -rigidbody.velocity;
            rigidbody.AddForce(opposite * 10);
            if (rigidbody.velocity.z < Vector3.zero.z && rigidbody.velocity.x < Vector3.zero.x)
                rigidbody.velocity = Vector3.zero;
            //rigidbody.drag = 100;
        }
    }
}
