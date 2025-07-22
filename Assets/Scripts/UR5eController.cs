using UnityEngine;
using Unity.Robotics.ROSTCPConnector;
using RosMessageTypes.Trajectory;
using RosMessageTypes.BuiltinInterfaces;
using RosMessageTypes.Std;
using RosMessageTypes.UrDashboard;
using Vector3 = UnityEngine.Vector3;
using UnityEngine.EventSystems;
using System.Collections;

public class UR5eController : MonoBehaviour
{
    public ROSConnection ros;
    public TCPPose tcpPose;
    private DHTransformation dHTransformation;
    private bool isMoving = false;
    private string trajectoryTopic = "/scaled_joint_trajectory_controller/joint_trajectory";
    private string urscriptTopic = "/urscript_interface/script_command";
    private string loadService = "/dashboard_client/load_program";
    private string triggerService = "/dashboard_client/play";
    private string[] jointNames;
    public static float velocity = 0.15f;
    public static float acceleration = 0.05f;
    private bool limitReached = false;

    void Start()
    {
        dHTransformation = this.GetComponent<DHTransformation>();

        // Register publisher
        ros.RegisterPublisher<JointTrajectoryMsg>(trajectoryTopic);
        ros.RegisterPublisher<StringMsg>(urscriptTopic);

        // Register services
        ros.RegisterRosService<LoadRequest, LoadResponse>(loadService);
        ros.RegisterRosService<TriggerRequest, TriggerResponse>(triggerService);

        GripperOpen();
    }
    public void SetVelocity(float v){
        velocity = v;
    }

    public void SetAcceleration(float a){
        acceleration = a;
    }

    public void LimitReached(bool limitReached){
        this.limitReached = limitReached;
    }

    private void PublishTrajectoryCommand(double[] targetPositions)
    {
        JointTrajectoryMsg jointTrajectory = new JointTrajectoryMsg
        {
            joint_names = jointNames
        };

        JointTrajectoryPointMsg point = new JointTrajectoryPointMsg
        {
            positions = targetPositions,
            time_from_start = new DurationMsg { sec =1, nanosec = 0 }
        };

        jointTrajectory.points = new JointTrajectoryPointMsg[] { point };

        // Publish the message
        ros.Publish(trajectoryTopic, jointTrajectory);
    }

    public void Stop()
    {
        var message = new StringMsg { data = "stopl(0.4)" };
        ros.Publish(urscriptTopic, message);
        isMoving = false;
    }
    public void LimitStop()
    {
        limitReached = true;
        var message = new StringMsg { data = "stopl(0.6)" };
        ros.Publish(urscriptTopic, message);
        isMoving = false;
    }
    public void HomePosition(){
        var message = new StringMsg { data = "movej([-1.57, -2.1, 1.7, -1.15, -1.57, 0], a=0.2, v=0.6)" };
        ros.Publish(urscriptTopic, message);

        Debug.Log("Move to Home");
    }
    public void GripperClose(){
        var loadRequest = new LoadRequest {filename = "GripperClose.urp"};
        ros.SendServiceMessage<LoadResponse>(loadService, loadRequest);
        var playRequest = new StringMsg();
        ros.SendServiceMessage<TriggerResponse>(triggerService, playRequest);
    }
    public void GripperOpen(){
        var loadRequest = new LoadRequest {filename = "GripperOpen.urp"};
        ros.SendServiceMessage<LoadResponse>(loadService, loadRequest);
        var playRequest = new StringMsg();
        ros.SendServiceMessage<TriggerResponse>(triggerService, playRequest);
    }
    public void RotateTCP(Vector3 targetRotationEuler, float velocity = 0.15f, float acceleration = 0.1f)
    {
        var position = dHTransformation.GetTCPPosition();

        var targetRotationRad = targetRotationEuler * Mathf.Deg2Rad;

        // convert to URScript-format (p[X, Y, Z, RX, RY, RZ])
        string pose = $"p[{position.x}, {position.y}, {position.z}, {targetRotationRad.x}, {targetRotationRad.z}, {targetRotationRad.y}]";

        // create URScript-command
        string command = $"movel({pose}, a={acceleration}, v={velocity})";

        // publish
         var message = new StringMsg { data = command };
         ros.Publish(urscriptTopic, message);

        Debug.Log($"Sent linear rotation command: {command}");
    }

    public void MoveL(Vector3 targetPosition, float velocity = 0.05f, float acceleration = 0.05f)
    {
        var tcpRotation = tcpPose.GetTCPRotationRad();
        // covert to URScript-format (p[X, Y, Z, RX, RY, RZ])
        string pose = $"p[{targetPosition.x}, {targetPosition.y}, {targetPosition.z}, {tcpRotation.x}, {tcpRotation.y}, {tcpRotation.z}]";

        // create URScript-command
        string command = $"movel({pose}, a={acceleration}, v={velocity})";

        var message = new StringMsg { data = command };
        ros.Publish(urscriptTopic, message);

        Debug.Log($"Sent linear move command: {command}");
    }
    public void MoveJ(Vector3 targetPosition, float acceleration = 0.1f, float velocity = 0.1f, int time = 0, int radius = 0)
    {
        var tcpRotation = tcpPose.GetTCPRotationRad();
        // Convert to URScript-format (p[X, Y, Z, RX, RY, RZ])
        string pose = $"p[{targetPosition.x}, {targetPosition.y}, {targetPosition.z}, {tcpRotation.x}, {tcpRotation.y}, {tcpRotation.z}]";

        // Create URScript-command
        string command = $"movej({pose}, a={acceleration}, v={velocity})";

        var message = new StringMsg { data = command };
        ros.Publish(urscriptTopic, message);

        Debug.Log($"Sent linear move command: {command}");
    }
    public void MoveJ(JointRotations jointRotations, float acceleration = 0.05f, float velocity = 0.1f, int time = 0, int radius = 0)
    {
        var message = new StringMsg { data = $"movej({jointRotations.ToURScript()}, a={acceleration}, v={velocity})" };
        ros.Publish(urscriptTopic, message);
    }
    public IEnumerator PositionReachedCoroutine(Vector3 targetPosition){
        isMoving = true;
        while(!PositionsEqual(targetPosition, dHTransformation.GetTCPPosition(), 0.01f)){
            yield return null;
        }
        Debug.Log("Target reached");
        isMoving = false;
    }
    public bool IsMoving(){
        return isMoving;
    }
    private bool PositionsEqual(Vector3 a, Vector3 b, float tolerance = 0.01f)
    {
        return Vector3.Distance(a, b) < tolerance;
    }
    public Vector3 GetTCPPosition(){
        return dHTransformation.GetTCPPosition();
    }
    public Quaternion GetTCPRotation(){
        return dHTransformation.GetTCPRotation();
    }
}
