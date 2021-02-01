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
        //anim = GetComponent<Animator>();
        //AnimationEvent animationEvent = new AnimationEvent {
        //    functionName = functionName,
        //    floatParameter = floatParameter,
        //    time = time
        //};
        //animationEvent.functionName = functionName;
        //animationEvent.floatParameter = floatParameter;
        //animationEvent.time = time;
        //AnimationClip clip = anim.runtimeAnimatorController.animationClips[Clip];
    }


    void PlayFootsteps()
    {
        footsteps = RuntimeManager.CreateInstance("event:/SFX/Human/Human_walk");
        footsteps.set3DAttributes(RuntimeUtils.To3DAttributes(gameObject));
        footsteps.start();
        footsteps.release();
    }

    // Start is called before the first frame update
    void Start()
    {
        //anim = GetComponent<Animator>();
        //AddEvent(1, 0.00f, "PlayFootsteps", 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
