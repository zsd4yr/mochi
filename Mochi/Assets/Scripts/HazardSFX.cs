using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMOD.Studio;
using FMODUnity;

public class HazardSFX : MonoBehaviour
{
    Rigidbody rb;
    public string hazardEvent;
    //string parameterName = "Player_Distance";
    //private EventInstance instance;

    //[EventRef]
    //public string fmodEvent;

    //[SerializeField] [Range(0.00f, 1.00f)]
    //private float distance;

    EventInstance hazard;
    EventDescription hazardDistance;
    PARAMETER_DESCRIPTION triggerHazard;
    PARAMETER_ID hazardID;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //instance = RuntimeManager.CreateInstance(fmodEvent);
        //instance.start();

        hazard = RuntimeManager.CreateInstance(hazardEvent);
        hazardDistance = RuntimeManager.GetEventDescription(hazardEvent);

        hazard.start();
        //hazard.setParameterByName(parameterName, 1.00f);
    }

    // Update is called once per frame
    void Update()
    {
        //instance.setParameterByName("Player_Distance", distance);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Robot"))
        {

            Debug.Log("Inside Hazard");
            hazardDistance.getParameterDescriptionByName("Player_Distance", out triggerHazard);
            hazardID = triggerHazard.id;

            //hazard.setParameterByName(parameterName, 1.00f);
            hazard.setParameterByID(hazardID, 1.00f);

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Robot"))
        {
            Debug.Log("Outside Hazard");
            //hazard.setParameterByName(parameterName, 0.00f);
            hazard.setParameterByID(hazardID, 0.00f);
        }
    }

}
