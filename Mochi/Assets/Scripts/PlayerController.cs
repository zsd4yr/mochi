using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static string PlayerTag = "Player";

    Rigidbody rb;
    GameControls controls;
    public float Accellaration = 100f;
    public Vector2 move;

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
        rb.AddForce(movement * Accellaration);

    }

}
