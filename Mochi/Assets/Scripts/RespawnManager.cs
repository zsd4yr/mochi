using System.Collections.Generic;
using System.Linq;
using Unity.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class RespawnManager : MonoBehaviour
{
    [ReadOnly]
    public List<GameObject> RespawnPlatforms;

    [ReadOnly]
    public GameObject CurrentRespawnPlatform;

    void Start()
    {
        this.RespawnPlatforms = new List<GameObject>();

        var startingRespawnPlatform = GameObject.FindGameObjectWithTag(RespawnPlatform.StartingRespawnPlatformTag);

        var respawnPlatforms = GameObject.FindGameObjectsWithTag(RespawnPlatform.RespawnPlatformTag);

        this.RespawnPlatforms.Add(startingRespawnPlatform);

        this.RespawnPlatforms.AddRange(respawnPlatforms
            .Where(each => each.TryGetComponent<RespawnPlatform>(out _)));

        this.SwitchCurrentPlatformTo(startingRespawnPlatform);
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

    public void SwitchCurrentPlatformTo(GameObject newCurrentPlat)
    {
        this.CurrentRespawnPlatform = newCurrentPlat;
    }
}
