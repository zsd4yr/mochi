using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpener : MonoBehaviour
{
    [ShowOnly]
    public Collider collider;
    public Animator animator;

    public bool openTrigger = false;

    public bool closeTrigger = false;
    public bool isPressurePlate;

    // Start is called before the first frame update
    void Start()
    {
        collider = gameObject.GetComponent<Collider>();
        //animator = gameObject.GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Robot"))
        {
            if(openTrigger)
            {
                animator.SetBool("isOpening", true);
            }
            else if (closeTrigger)
            {
                animator.SetBool("isOpening", false);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(isPressurePlate)
        {
            animator.SetBool("isOpening", false);
        }
    }


}
