using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class DoorOpener : MonoBehaviour
{
    [ShowOnly]
    public Collider collider;
    public Animator animator;

    public bool openTrigger = false;
    public bool closeTrigger = false;

    public bool isSingleUse;
    public string EnteredName = "Robot";

    // Start is called before the first frame update
    void Start()
    {
        collider = gameObject.GetComponent<Collider>();
        //animator = gameObject.GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(EnteredName) || other.CompareTag(EnteredName))
        {
            if (openTrigger)
            {
                animator.SetBool("isOpening", true);
                //this.transform.parent.gameObject.GetComponent<Collider>().enabled = false;
                GetComponent<Collider>().enabled = false;
            }
            else if (closeTrigger)
            {
                animator.SetBool("isOpening", false);
                //this.transform.parent.gameObject.GetComponent<Collider>().enabled = true;
                GetComponent<Collider>().enabled = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (!isSingleUse && (other.CompareTag(EnteredName) || other.CompareTag(EnteredName)))
        {
            animator.SetBool("isOpening", false);
            this.transform.parent.gameObject.GetComponent<BoxCollider>().enabled = true;
        }
    }

    void Update()
    {
        if (Keyboard.current.tKey.wasPressedThisFrame)
        {
            if (EnteredName == "Robot")
            {
                EnteredName = "Player";
                print("now player opens");
            }
            else
            {
                EnteredName = "Robot";
                print("now robot opens");
            }
        }
        //toggles with "t"
    }
}
