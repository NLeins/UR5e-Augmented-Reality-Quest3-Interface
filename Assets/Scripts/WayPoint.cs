using UnityEngine;

public class WayPoint
{
    public Vector3 RobotPosition { get; set; }
    public Vector3 WorldPosition { get; set; }
    public Quaternion Rotation { get; set; }
    public int WaypoinIndex { get; set; }
    public int ProgramStepIndex { get; set; }

    public WayPoint(Vector3 robotPosition, Vector3 worldPosition, Quaternion rotation, int waypointIndex, int programStepIndex)
    {
        RobotPosition = robotPosition;
        WorldPosition = worldPosition;
        Rotation = rotation;
        WaypoinIndex = waypointIndex;
        ProgramStepIndex = programStepIndex;
    }
}
