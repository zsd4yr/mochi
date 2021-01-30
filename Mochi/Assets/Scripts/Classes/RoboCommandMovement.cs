using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoboCommandMovement {

    Vector3 worldposition;
    Vector3 screenposition;

    public RoboCommandMovement(Vector3 world, Vector3 screen)
    {
        worldposition = world;
        screenposition = screen;
    }

}
