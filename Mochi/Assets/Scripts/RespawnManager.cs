using System.Collections.Generic;
using System.Linq;
using Unity.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class RespawnManager : MonoBehaviour
{
    [ReadOnly]
    public List<RespawnPlatform> RespawnPlatforms;

    [ReadOnly]
    public RespawnPlatform CurrentRespawnPlatform;

    void Start()
    {
        this.RespawnPlatforms = new List<RespawnPlatform>();
        this.RespawnPlatforms.AddRange(GameObject.FindGameObjectsWithTag(RespawnPlatform.RespawnPlatformTag)
            .ToList()
            .Select(each => each.GetComponent<RespawnPlatform>()));
    }

    void Update()
    {
        if (Keyboard.current.rKey.wasReleasedThisFrame)
        {
            this.RespawnRobot();
        }
    }

    private void RespawnRobot()
    {

    }
}
