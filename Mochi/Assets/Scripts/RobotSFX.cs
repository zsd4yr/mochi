using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotSFX : MonoBehaviour
{

    public string hoverEvent;

    private FMOD.Studio.EventInstance hoverSFX;

    public void HoverIdle()
    {
        Debug.Log("Is it working");
        

        hoverSFX = FMODUnity.RuntimeManager.CreateInstance(hoverEvent);
        hoverSFX.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject));
        FMODUnity.RuntimeManager.PlayOneShot(hoverEvent);
        //hoverSFX.start();
        //hoverSFX.release();
    }


    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Hello");
        if (other.CompareTag("Player"))
        {
            Debug.Log("Ya feel me?");
            //FMODUnity.RuntimeManager.PlayOneShot(hoverSFX);
        }
    }
}
