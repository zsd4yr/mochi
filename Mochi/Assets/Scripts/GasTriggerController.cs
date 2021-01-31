using UnityEngine;

public class GasTriggerController : MonoBehaviour
{
    [ShowOnly]
    public bool isWithinBounds = false;

    Collider collider;

    public Vector3 opposite;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(PlayerController.PlayerTag))
        {
            isWithinBounds = true;
            collider = other;
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(PlayerController.PlayerTag))
        {
            isWithinBounds = false;
            collider = null;
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (collider != null && isWithinBounds == true)
        {
            var rigidbody = collider.GetComponent<Rigidbody>();
            opposite = -rigidbody.velocity;
            rigidbody.AddForce(opposite * 10);
            if (rigidbody.velocity.z < Vector3.zero.z && rigidbody.velocity.x < Vector3.zero.x)
                rigidbody.velocity = Vector3.zero;
            //rigidbody.drag = 100;
        }
    }
}
