using UnityEngine;

public class RobotMoveCommand : IRobotCommand
{
    public Vector3 WorldPosition { get; private set; }
    public Vector3 ScreenPosition { get; private set; }

    public RobotMoveCommand(Vector3 world, Vector3 screen)
    {
        WorldPosition = world;
        ScreenPosition = screen;
    }
}
