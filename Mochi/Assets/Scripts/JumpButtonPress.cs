using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class JumpButtonPress : MonoBehaviour
{
    private float jumpSpeed = 2f;
    public float jumpHeight = 1f;
    public bool isGrounded;
    public float NumberJumps = 0f;
    public float MaxJumps = 2;
    private Rigidbody rb;
    public GameObject ExampleObject;
    GameControls controls;
    public Animator PlayerAnimator;
    public const string isJumping = nameof(isJumping);
    public const string isCrawling = nameof(isCrawling);
    public const string Crawling = nameof(Crawling);
    

    public RigidbodyConstraints originalConstraints;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        originalConstraints = rb.constraints;
        controls = new GameControls();
    }

    private void OnEnable()
    {
        controls.Enable();
    }

    void Start()
    {
        this.PlayerAnimator = this.GetComponentInChildren<Animator>();
        ExampleObject = GameObject.Find("CameraController");
    }

    void Update()
    {
        if (NumberJumps > MaxJumps - 1)
        {
            isGrounded = false;
        }

        if (isGrounded)
        {
            if (Keyboard.current.spaceKey.wasPressedThisFrame)
            {
                this.PlayerAnimator.SetBool(isJumping, true);
                ExampleObject.transform.parent = null;
                GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezePositionZ;

                rb.AddForce(0, 0, jumpHeight, ForceMode.Impulse);                
                
                //currJump += temp;
                //controller.Move(Vector3.up * temp * Time.deltaTime * jumpSpeed);

                Vector3 pos = transform.position;
                pos.y += jumpHeight * 2;
                transform.position = pos;
                NumberJumps += 1;
                print("Hey!");
            }

            else if (Keyboard.current.cKey.wasPressedThisFrame)
            {
                if (this.PlayerAnimator.GetBool(Crawling) == false)
                {
                    GetComponent<CapsuleCollider>().enabled = false;
                    GetComponent<SphereCollider>().enabled = true;
                    //swap colliders.
                    this.PlayerAnimator.SetBool(Crawling, true);
                    //this.PlayerAnimator.SetBool(isCrawling, false);
                }
                else
                {
                    GetComponent<CapsuleCollider>().enabled = true;
                    GetComponent<SphereCollider>().enabled = false;
                    //swap colliders.
                    this.PlayerAnimator.SetBool(isCrawling, false);
                    this.PlayerAnimator.SetBool(Crawling, false);
                }
                print("HII");
            }
        }
    }

    void OnCollisionEnter(Collision other)
    {
        ExampleObject.transform.parent = this.transform;
        GetComponent<Rigidbody>().constraints = originalConstraints;
        isGrounded = true;
        NumberJumps = 0;
        this.PlayerAnimator.SetBool(isJumping, false);
        
    }

    void OnCollisionExit(Collision other)
    {

    }
}
