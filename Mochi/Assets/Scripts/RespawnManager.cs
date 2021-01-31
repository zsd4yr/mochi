using System.Collections.Generic;
using System.Linq;
using Unity.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class RespawnManager : MonoBehaviour
{
    [ShowOnly]
    public List<GameObject> RespawnPlatforms;

    [ShowOnly]
    public GameObject CurrentRespawnPlatform;

    [ShowOnly]
    public GameObject Robot;

    void Start()
    {
        this.RespawnPlatforms = new List<GameObject>();

        var startingRespawnPlatform = GameObject.FindGameObjectWithTag(RespawnPlatform.StartingRespawnPlatformTag);

        var respawnPlatforms = GameObject.FindGameObjectsWithTag(RespawnPlatform.RespawnPlatformTag);

        this.RespawnPlatforms.Add(startingRespawnPlatform);

        this.RespawnPlatforms.AddRange(respawnPlatforms
            .Where(each => each.TryGetComponent<RespawnPlatform>(out _)));

        this.SwitchCurrentPlatformTo(startingRespawnPlatform);

        this.Robot = GameObject.FindGameObjectWithTag(RobotController.RobotTag);

        this.RespawnRobot();
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
        Robot.transform.position = CurrentRespawnPlatform.transform.position;
    }

    public void SwitchCurrentPlatformTo(GameObject newCurrentPlat)
    {
        this.CurrentRespawnPlatform = newCurrentPlat;
    }
}
