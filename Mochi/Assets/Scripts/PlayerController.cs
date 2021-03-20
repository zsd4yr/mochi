using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    Transform playerInputSpace = default;


    public static string PlayerTag = "Player";
    public GameObject visual;
    Rigidbody Rigidbody;
    GameControls controls;
    public float Acceleration = 100f;
    public Vector2 move;
    public Vector3 ExternalForce = new Vector3(5f, 0, 5f);
    private Vector3 prevPos, newPos, ExternalInfluence, moveAngle;
    public bool crawler = false,
                canWalk = true,
                beingRepelled = false;   

    [Header("Alt Movement Controls w/ Camera")]
    [SerializeField] Camera myCamera;
    private float turnSmoothVelocity;
    public float turnSmoothTime = 0.1f;
    Vector3 direction;

    [Header("Animation")]
    [ShowOnly]
    public Animator PlayerAnimator;

    public float timeToRunFromWalkSeconds;

    private float timeSinceStartedWalking, visualTargetAngle, visualAngle;
    public const string isWalking = nameof(isWalking);
    public const string isRunning = nameof(isRunning);
    public const string isJumping = nameof(isJumping);
    public const string isCrawling = nameof(isCrawling);
    public const string Crawling = nameof(Crawling);
    

    private void Awake()
    {
        Rigidbody = GetComponent<Rigidbody>();
        controls = new GameControls();
        ExternalInfluence = Vector3.zero;
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
        if(playerInputSpace)
        {
            var move = controls.GameController.Movement.ReadValue<Vector2>();
            float horizontal = move.x/*Input.GetAxisRaw("Horizontal")*/;
            float vertical = move.y/*Input.GetAxisRaw("Vertical")*/;
            direction = new Vector3(horizontal, 0, vertical).normalized;
        }
        else
        {
            controls.GameController.Movement.performed += ctx => move = ctx.ReadValue<Vector2>();
            controls.GameController.Movement.canceled += ctx => move = Vector2.zero;
        }

        if (this.Rigidbody.velocity.magnitude >= 0.01)
        {
            this.timeSinceStartedWalking += Time.deltaTime;
            //if (this.PlayerAnimator.GetBool(Crawling) == false)
            //{
                    
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
            //}                
            //else 
            //{
                //this.PlayerAnimator.SetBool(Crawling, false);
                //this.PlayerAnimator.SetBool(isCrawling, true);
            //}
        }           
        else
        {
            this.timeSinceStartedWalking = 0.0f;
            this.PlayerAnimator.SetBool(isWalking, false);
            this.PlayerAnimator.SetBool(isRunning, false);
            this.PlayerAnimator.SetBool(isCrawling, false);
            /*if (crawler)
            {
                this.PlayerAnimator.SetBool(Crawling, true);
            }*/
        }
           
        this.prevPos = this.transform.position;
    }

    void FixedUpdate()
    {
        if (playerInputSpace)
        {
            if(direction.magnitude >= 0.1f)
            {
                float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + myCamera.transform.eulerAngles.y;
                float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);

                Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
                moveAngle = moveDir;
                if (this.timeSinceStartedWalking >= this.timeToRunFromWalkSeconds)
                {
                    Rigidbody.AddForce((moveDir.normalized * (Acceleration * 1.5f)) + ExternalInfluence);
                }
                else
                {
                    Rigidbody.AddForce((moveDir.normalized * Acceleration) + ExternalInfluence);
                }
                if (beingRepelled)
                    Rigidbody.AddForce(moveDir.normalized * (-Acceleration * 2f));

                visual.transform.rotation = Quaternion.Euler(0f, targetAngle, 0f);
            }
        }
        else if (/*canWalk &&*/ this.PlayerAnimator.GetBool(isJumping) == false)
        {
            //controls.GameController.Movement.performed += ctx => move = ctx.ReadValue<Vector2>();
            //controls.GameController.Movement.canceled += ctx => move = Vector2.zero;

            Vector3 movement = new Vector3(move.x, 0, move.y);
            Vector3 movementNormal = new Vector3(move.x, 0, move.y).normalized;
            if (this.timeSinceStartedWalking >= this.timeToRunFromWalkSeconds)
            {
                Rigidbody.AddForce((movement * (Acceleration * 1.5f)) + ExternalInfluence);
            }
            else
            {
                Rigidbody.AddForce((movement * Acceleration) + ExternalInfluence);
            }
            if (beingRepelled)
                Rigidbody.AddForce(movement * (-Acceleration * 2f));
        }
        //If not jumping, then move.
    }

    public void AddToExternalInfluenceForce(Vector3 _externalForce)
    {
        ExternalInfluence = _externalForce;
    }
    public void ApplyDrag(bool _applyDrag)
    {
        if (_applyDrag)
            Rigidbody.drag = 25;
        else
            Rigidbody.drag = 10;
    }
    Vector3 ProjectDirectionOnPlane(Vector3 direction, Vector3 normal)
    {
        return (direction - normal * Vector3.Dot(direction, normal)).normalized;
    }
    private void LateUpdate()
    {
        if (/*canWalk &&*/ Rigidbody.velocity.magnitude > 0.1f)
        {
            float targetAngle = Mathf.Atan2(Rigidbody.velocity.x, Rigidbody.velocity.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(visual.transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            visual.transform.rotation = Quaternion.Euler(0f, angle, 0f);
        }

        if (this.Rigidbody.velocity.magnitude >= 0.01)
        {
            this.timeSinceStartedWalking += Time.deltaTime;
            //if (this.PlayerAnimator.GetBool(Crawling) == false)
            //{

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
            //}                
            //else 
            //{
            //this.PlayerAnimator.SetBool(Crawling, false);
            //this.PlayerAnimator.SetBool(isCrawling, true);
            //}
        }
        else
        {
            this.timeSinceStartedWalking = 0.0f;
            this.PlayerAnimator.SetBool(isWalking, false);
            this.PlayerAnimator.SetBool(isRunning, false);
            this.PlayerAnimator.SetBool(isCrawling, false);
            /*if (crawler)
            {
                this.PlayerAnimator.SetBool(Crawling, true);
            }*/
        }
    }
}
