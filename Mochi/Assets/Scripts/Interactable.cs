using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Interactable : MonoBehaviour
{
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
            var t = 0;
        }
    }
}
