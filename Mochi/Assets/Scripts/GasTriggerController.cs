using UnityEngine;

public class GasTriggerController : MonoBehaviour
{
    [ShowOnly]
    public bool isWithinBounds = false;

    PlayerController player;
    Collider collider;

    public Vector3 opposite, translateOffset;
    Vector3 lastEntryPosition;
    public float oppositeMultiplier;
    InteractableSwitch interactableSwitch;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(PlayerController.PlayerTag))
        {
            isWithinBounds = true;
            collider = other;
            player = other.gameObject.GetComponent<PlayerController>();
            //player.beingRepelled = true;
            player.AddToExternalInfluenceForce(player.ExternalForce);
            player.ApplyDrag(true);
            //player.canWalk = false;
            lastEntryPosition = collider.gameObject.transform.position;
            //if (player.Accellaration > 0)
            //    player.Accellaration *= -1;
        }
        else if(other.gameObject.GetComponent<InteractableSwitch>() != null)
        {
            interactableSwitch = other.gameObject.GetComponent<InteractableSwitch>();
            if (interactableSwitch.m_CanActivate)
                interactableSwitch.m_CanActivate = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(PlayerController.PlayerTag))
        {
            isWithinBounds = false;
            //player.beingRepelled = false;
            player.AddToExternalInfluenceForce(Vector3.zero);
            player.ApplyDrag(false);

            collider = null;
            //player.Accellaration *= -1;
            //player.canWalk = true;
            player = null;
        }
        else if (other.gameObject.GetComponent<InteractableSwitch>() != null)
        {
            interactableSwitch = other.gameObject.GetComponent<InteractableSwitch>();
            if (!interactableSwitch.m_CanActivate)
                interactableSwitch.m_CanActivate = true;
        }
    }

    // Update is called once per frame  
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (collider != null && isWithinBounds == true)
        {
            //player.transform.position = Vector3.LerpUnclamped(player.transform.position, lastEntryPosition + translateOffset, 1f);


        //    var rigidbody = collider.GetComponent<Rigidbody>();
        //    opposite = -rigidbody.velocity;
        //    rigidbody.AddForce(opposite * oppositeMultiplier);
        //    //if (rigidbody.velocity.z < Vector3.zero.z && rigidbody.velocity.x < Vector3.zero.x)
        //    //    rigidbody.velocity = Vector3.zero;
        //    rigidbody.drag = 10f;
        }
    }
}
