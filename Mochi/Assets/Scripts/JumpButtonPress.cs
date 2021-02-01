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
    GameControls controls;
    public Animator PlayerAnimator;
    public const string isJumping = nameof(isJumping);

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        controls = new GameControls();
    }

    private void OnEnable()
    {
        controls.Enable();
    }

    void Start()
    {
        this.PlayerAnimator = this.GetComponentInChildren<Animator>();
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

                //rb.AddForce(0, 0, jumpHeight, ForceMode.Impulse);


                
                //currJump += temp;
                //controller.Move(Vector3.up * temp * Time.deltaTime * jumpSpeed);

                Vector3 pos = transform.position;
                pos.y += jumpHeight * 2;
                transform.position = pos;
                NumberJumps += 1;
                print("Hey!");
            }
        }
    }

    void OnCollisionEnter(Collision other)
    {
        isGrounded = true;
        NumberJumps = 0;
        this.PlayerAnimator.SetBool(isJumping, false);
    }

    void OnCollisionExit(Collision other)
    {

    }
}
