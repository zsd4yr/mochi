using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static string PlayerTag = "Player";
    public GameObject visual;
    Rigidbody Rigidbody;
    GameControls controls;
    public float Accellaration = 100f;
    public Vector2 move;
    private Vector3 prevPos;

    private float turnSmoothVelocity;
    public float turnSmoothTime = 0.1f;

    [ShowOnly]
    public Animator PlayerAnimator;

    public float timeToRunFromWalkSeconds;

    private float timeSinceStartedWalking;
    public const string isWalking = nameof(isWalking);
    public const string isRunning = nameof(isRunning);

    private void Awake()
    {
        Rigidbody = GetComponent<Rigidbody>();
        controls = new GameControls();
    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }

    void Start()
    {
        this.PlayerAnimator = this.GetComponentInChildren<Animator>();
        this.timeSinceStartedWalking = 0.0f;
    }

    private void Update()
    {
        if (this.Rigidbody.velocity.magnitude >= 0.01)
        {
            this.timeSinceStartedWalking += Time.deltaTime;
            if (this.timeSinceStartedWalking >= this.timeToRunFromWalkSeconds)
            {
                this.PlayerAnimator.SetBool(isWalking, false);
                this.PlayerAnimator.SetBool(isRunning, true);
            }
            else
            {
                this.PlayerAnimator.SetBool(isWalking, true);
                this.PlayerAnimator.SetBool(isRunning, false);
            }
        }
        else
        {
            this.timeSinceStartedWalking = 0.0f;
            this.PlayerAnimator.SetBool(isWalking, false);
            this.PlayerAnimator.SetBool(isRunning, false);
        }

        this.prevPos = this.transform.position;
    }

    void FixedUpdate()
    {
        controls.GameController.Movement.performed += ctx => move = ctx.ReadValue<Vector2>();
        controls.GameController.Movement.canceled += ctx => move = Vector2.zero;

        Vector3 movement = new Vector3(move.x, 0, move.y);
        Vector3 movementNomral = new Vector3(move.x, 0, move.y).normalized;
        if (this.timeSinceStartedWalking >= this.timeToRunFromWalkSeconds)
        {
            Rigidbody.AddForce(movement * (Accellaration * 1.5f));
        }
        else
        {
            Rigidbody.AddForce(movement * Accellaration);
        }
    }

    private void LateUpdate()
    {
        if (Rigidbody.velocity.magnitude > 0.1f)
        {
            float targetAngle = Mathf.Atan2(Rigidbody.velocity.x, Rigidbody.velocity.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(visual.transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            visual.transform.rotation = Quaternion.Euler(0f, angle, 0f);
        }
    }
}
