using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static string PlayerTag = "Player";
    public GameObject visual;
    Rigidbody rb;
    GameControls controls;
    public float Accellaration = 100f;
    public Vector2 move;
    private Vector3 prevPos;

    private float turnSmoothVelocity;
    public float turnSmoothTime = 0.1f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
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

    private void Update()
    {
  
    }

    void FixedUpdate()
    {
        controls.GameController.Movement.performed += ctx => move = ctx.ReadValue<Vector2>();
        controls.GameController.Movement.canceled += ctx => move = Vector2.zero;

        Vector3 movement = new Vector3(move.x, 0, move.y);
        Vector3 movementNomral = new Vector3(move.x, 0, move.y).normalized;
        rb.AddForce(movement * Accellaration);
    }

    private void LateUpdate()
    {
        if (rb.velocity.magnitude > 0.1f)
        {

            float targetAngle = Mathf.Atan2(rb.velocity.x, rb.velocity.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(visual.transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            visual.transform.rotation = Quaternion.Euler(0f, angle, 0f);
        }
    }
}
