using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMOD.Studio;
using FMODUnity;

public class RobotAudioManager : MonoBehaviour
{
    public string sfxEvent;

    EventInstance SoundEvent;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        //RuntimeManager.PlayOneShot(sfxEvent);
        //Debug.Log("Hit switch");
        if (other.CompareTag("Robot"))
        {
            Debug.Log("Robot is on top of switch");
            RuntimeManager.PlayOneShot(sfxEvent);
        }
    }
}
