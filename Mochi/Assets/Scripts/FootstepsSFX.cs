using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMOD.Studio;
using FMODUnity;

public class FootstepsSFX : MonoBehaviour
{
    private EventInstance footsteps;

    Animator anim;

    void AddEvent(int Clip, float time, string functionName, float floatParameter)
    {

    }


    void PlayFootsteps()
    {
        footsteps = RuntimeManager.CreateInstance("event:/SFX/Human/Human_walk2");
        footsteps.set3DAttributes(RuntimeUtils.To3DAttributes(gameObject));
        footsteps.start();
        footsteps.release();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
