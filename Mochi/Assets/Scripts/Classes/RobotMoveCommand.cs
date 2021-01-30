using UnityEngine;

public class RobotMoveCommand : IRobotCommand
{
    public Vector3 WorldPosition { get; private set; }

    public Vector3 WorldPositionWithinNavMesh { get; private set; }
    private static Vector3 SentinelUnsetVector = new Vector3(float.MaxValue, float.MaxValue, float.MaxValue);

    public RobotMoveCommand(Vector3 world)
    {
        var rectifiedWorldVector = new Vector3(world.x, 0, world.z);
        WorldPosition = rectifiedWorldVector;
        this.WorldPositionWithinNavMesh = SentinelUnsetVector;
    }

    public void SetWorldPositionWithinNavMesh(Vector3 worldPositionWithinNavMesh)
        => this.WorldPositionWithinNavMesh = worldPositionWithinNavMesh;

    public bool IsWorldPositionWithinNavMeshSet()
        => this.WorldPositionWithinNavMesh != SentinelUnsetVector;
}
