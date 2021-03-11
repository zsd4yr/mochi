using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMOD.Studio;
using FMODUnity;

public class AudioManager : MonoBehaviour
{
    public string sfxEvent;
    string UI_Key_Input = "event:/SFX/UI/Terminal_Key_Input";
    string UI_Execute = "event:/SFX/UI/Terminal_Execute";

    EventInstance SoundEvent;

    // Start is called before the first frame update
    void Awake()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlaySFX_UIInput()
    {
        RuntimeManager.PlayOneShot(UI_Key_Input);
    }

    public void PlaySFX_UIExecute()
    {
        RuntimeManager.PlayOneShot(UI_Execute);
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Player"))
        {
            Debug.Log("Hit me SFX");
            RuntimeManager.PlayOneShot(sfxEvent);
        }
    }
}
