﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using FMOD.Studio;

public class MusicManager : MonoBehaviour
{
    public bool[] levelCompleted = new bool[5] { false, false, false, false, false}; 

    public string musicEvent;

    EventInstance music;

    // Start is called before the first frame update
    void Start()
    {
        music = RuntimeManager.CreateInstance(musicEvent);
        music.start();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
