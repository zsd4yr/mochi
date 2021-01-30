using UnityEngine;

public class RobotMoveAbsoluteCommand : IRobotCommand
{
    public Vector3 WorldPosition { get; private set; }
    public Vector3 ScreenPosition { get; private set; }

    public Vector3 WorldPositionWithinNavMesh { get; private set; }
    private static Vector3 SentinelUnsetVector = new Vector3(float.MaxValue, float.MaxValue, float.MaxValue);

    public RobotMoveAbsoluteCommand(Vector3 world, Vector3 screen)
    {
        var rectifiedWorldVector = new Vector3(world.x, 0, world.z);
        WorldPosition = rectifiedWorldVector;
        ScreenPosition = screen;

        this.WorldPositionWithinNavMesh = SentinelUnsetVector;
    }

    public void SetWorldPositionWithinNavMesh(Vector3 worldPositionWithinNavMesh)
        => this.WorldPositionWithinNavMesh = worldPositionWithinNavMesh;

    public bool IsWorldPositionWithinNavMeshSet()
        => this.WorldPositionWithinNavMesh != SentinelUnsetVector;
}
