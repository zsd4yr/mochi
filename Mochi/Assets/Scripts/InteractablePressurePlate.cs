using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class InteractablePressurePlate : MonoBehaviour
{
    [ShowOnly]
    public Collider collider;
    public Animator animator;

    public bool openTrigger = false;
    public bool closeTrigger = false;

    public bool isSingleUse;
    public string EnteredName = "Robot";

    public Enumerators.SwitchType m_SwitchType = 
            Enumerators.SwitchType.OpenDoor;

    [Header ("Shrinking Properties")]
        public GameObject m_ShrinkObject;
        public float m_ShrinkSpeed = 10f,
                     m_Scale = 0.1f,
                     m_ShrinkRate = 0.1f;
        float m_MinSize = 0.1f;

        [Header("Open Door Properties")]
        public Collider m_DoorCollider;
        public Animator m_DoorAnimator;
        public bool m_DoorOpenTrigger = true, 
                    m_DoorCloseTrigger = false;

        public bool m_CanFlip = true,
                    m_IsShrinking = false;

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
                this.transform.parent.gameObject.GetComponent<Collider>().enabled = false;
            }
            else if (closeTrigger)
            {
                animator.SetBool("isOpening", false);
                this.transform.parent.gameObject.GetComponent<Collider>().enabled = true;
            }
            if(m_SwitchType == Enumerators.SwitchType.ShrinkObject && !m_IsShrinking)
            {
                m_IsShrinking = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (isSingleUse && (other.CompareTag(EnteredName) || other.CompareTag(EnteredName)) )
        {
            animator.SetBool("isOpening", false);
            this.transform.parent.gameObject.GetComponent<BoxCollider>().enabled = true;
        }
    }

    void Update()
    {
        //if (Keyboard.current.tKey.wasPressedThisFrame)
        //{
        //    if (EnteredName == "Robot")
        //    {
        //        EnteredName = "Player";
        //        print("now player opens");
        //    }
        //    else
        //    {
        //        EnteredName = "Robot";
        //        print("now robot opens");
        //    }
        //}
        if (m_IsShrinking && m_ShrinkObject != null)
        {
            ShrinkObject();
        }//toggles with "t"
    }

    void ShrinkObject()
    {
        m_ShrinkObject.transform.localScale = Vector3.Lerp(m_ShrinkObject.transform.localScale, Vector3.zero, m_ShrinkRate);

        if (m_ShrinkObject.transform.localScale == Vector3.zero)
        {
            Destroy(m_ShrinkObject);
            m_ShrinkObject = null;
        }
    }
}
