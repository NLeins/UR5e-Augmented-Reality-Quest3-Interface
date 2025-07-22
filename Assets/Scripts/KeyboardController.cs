using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;

public class KeyboardController : MonoBehaviour
{
    public GameObject RobotController;
    public TCPPose tcpPose;
    private Vector3 moveTcpTo;
    private Vector3 rotateTcpTo;
    public JointStatesSubscriber jointStatesSubscriber;
    private JointRotations jointRotations;
    private bool gripperClosed = false;

    void Update()
    {
        // Postition
        // X-
        if(Input.GetKeyDown(KeyCode.UpArrow)){
            moveTcpTo = RobotController.GetComponent<DHTransformation>().GetTCPPosition();
            moveTcpTo.x -= 1f;
            RobotController.GetComponent<UR5eController>().MoveL(moveTcpTo);
        }
        // Y-
        if(Input.GetKeyDown(KeyCode.LeftArrow)){
            moveTcpTo = RobotController.GetComponent<DHTransformation>().GetTCPPosition();
            moveTcpTo.y -= 1f;
            RobotController.GetComponent<UR5eController>().MoveL(moveTcpTo);
        }
        // Y+
        if(Input.GetKeyDown(KeyCode.RightArrow)){
            moveTcpTo = RobotController.GetComponent<DHTransformation>().GetTCPPosition();            
            moveTcpTo.y += 1f;
            RobotController.GetComponent<UR5eController>().MoveL(moveTcpTo);
        }
        // X+
        if(Input.GetKeyDown(KeyCode.DownArrow)){
            // moveTcpTo = tcpPose.GetTCPPosition();
            moveTcpTo = RobotController.GetComponent<DHTransformation>().GetTCPPosition();            
            moveTcpTo.x += 1f;
            RobotController.GetComponent<UR5eController>().MoveL(moveTcpTo);
        }
        // Z+
        if(Input.GetKeyDown(KeyCode.Delete)){
            moveTcpTo = RobotController.GetComponent<DHTransformation>().GetTCPPosition();            
            moveTcpTo.z += 1f;
            RobotController.GetComponent<UR5eController>().MoveL(moveTcpTo);
        }
        // Z-
        if(Input.GetKeyDown(KeyCode.PageDown)){
            moveTcpTo = RobotController.GetComponent<DHTransformation>().GetTCPPosition();            
            moveTcpTo.z -= 1f;
            RobotController.GetComponent<UR5eController>().MoveL(moveTcpTo);
        }

        if(Input.GetKeyUp(KeyCode.UpArrow)){
            RobotController.GetComponent<UR5eController>().Stop();
        }if(Input.GetKeyUp(KeyCode.DownArrow)){
            RobotController.GetComponent<UR5eController>().Stop();
        }if(Input.GetKeyUp(KeyCode.LeftArrow)){
            RobotController.GetComponent<UR5eController>().Stop();
        }if(Input.GetKeyUp(KeyCode.RightArrow)){
            RobotController.GetComponent<UR5eController>().Stop();
        }if(Input.GetKeyUp(KeyCode.PageDown)){
            RobotController.GetComponent<UR5eController>().Stop();
        }if(Input.GetKeyUp(KeyCode.Delete)){
            RobotController.GetComponent<UR5eController>().Stop();
        }

        // Rotation
        // RY-
        if(Input.GetKeyDown(KeyCode.A)){
            rotateTcpTo = tcpPose.GetTCPRotationEuler();
            rotateTcpTo.y -= 10f;
            RobotController.GetComponent<UR5eController>().RotateTCP(rotateTcpTo);
        }
        // RY+
        if(Input.GetKeyDown(KeyCode.D)){
            rotateTcpTo = tcpPose.GetTCPRotationEuler();
            rotateTcpTo.y += 10f;
            RobotController.GetComponent<UR5eController>().RotateTCP(rotateTcpTo);
        }
        // RX+
        if(Input.GetKeyDown(KeyCode.S)){
            rotateTcpTo = tcpPose.GetTCPRotationEuler();
            rotateTcpTo.x += 10f;
            RobotController.GetComponent<UR5eController>().RotateTCP(rotateTcpTo);
        }
        // RX-
        if(Input.GetKeyDown(KeyCode.W)){
            rotateTcpTo = tcpPose.GetTCPRotationEuler();
            rotateTcpTo.x -= 10f;
            RobotController.GetComponent<UR5eController>().RotateTCP(rotateTcpTo);
        }
        // RZ+
        if(Input.GetKeyDown(KeyCode.E)){
            rotateTcpTo = tcpPose.GetTCPRotationEuler();
            rotateTcpTo.z += 10f;
            RobotController.GetComponent<UR5eController>().RotateTCP(rotateTcpTo);
        }
        // RZ-
        if(Input.GetKeyDown(KeyCode.Q)){
            rotateTcpTo = tcpPose.GetTCPRotationEuler();
            rotateTcpTo.z -= 10f;
            RobotController.GetComponent<UR5eController>().RotateTCP(rotateTcpTo);
        }

        if(Input.GetKeyUp(KeyCode.W)){
            RobotController.GetComponent<UR5eController>().Stop();
        }if(Input.GetKeyUp(KeyCode.A)){
            RobotController.GetComponent<UR5eController>().Stop();
        }if(Input.GetKeyUp(KeyCode.S)){
            RobotController.GetComponent<UR5eController>().Stop();
        }if(Input.GetKeyUp(KeyCode.D)){
            RobotController.GetComponent<UR5eController>().Stop();
        }if(Input.GetKeyUp(KeyCode.Q)){
            RobotController.GetComponent<UR5eController>().Stop();
        }if(Input.GetKeyUp(KeyCode.E)){
            RobotController.GetComponent<UR5eController>().Stop();
        }

        // Joint Control
        // Base+
        if(Input.GetKeyDown(KeyCode.Alpha1)){
            var currentJointRotation = jointStatesSubscriber.GetJointStates();
            currentJointRotation.baseJoint += 3;
            RobotController.GetComponent<UR5eController>().MoveJ(currentJointRotation);
        }
        // Base-
        if(Input.GetKeyDown(KeyCode.Alpha2)){
            var currentJointRotation = jointStatesSubscriber.GetJointStates();
            currentJointRotation.baseJoint -= 3;
            RobotController.GetComponent<UR5eController>().MoveJ(currentJointRotation);
        }// Shoulder+
        if(Input.GetKeyDown(KeyCode.Alpha3)){
            var currentJointRotation = jointStatesSubscriber.GetJointStates();
            currentJointRotation.shoulderJoint += 3;
            RobotController.GetComponent<UR5eController>().MoveJ(currentJointRotation);
        }
        // Shoulder-
        if(Input.GetKeyDown(KeyCode.Alpha4)){
            var currentJointRotation = jointStatesSubscriber.GetJointStates();
            currentJointRotation.shoulderJoint -= 3;
            RobotController.GetComponent<UR5eController>().MoveJ(currentJointRotation);
        }// Elbow+
        if(Input.GetKeyDown(KeyCode.Alpha5)){
            var currentJointRotation = jointStatesSubscriber.GetJointStates();
            currentJointRotation.elbowJoint += 3;
            RobotController.GetComponent<UR5eController>().MoveJ(currentJointRotation);
        }
        // Elbow-
        if(Input.GetKeyDown(KeyCode.Alpha6)){
            var currentJointRotation = jointStatesSubscriber.GetJointStates();
            currentJointRotation.elbowJoint -= 3;
            RobotController.GetComponent<UR5eController>().MoveJ(currentJointRotation);
        }// Wrist1 +
        if(Input.GetKeyDown(KeyCode.Alpha7)){
            var currentJointRotation = jointStatesSubscriber.GetJointStates();
            currentJointRotation.wrist1Joint += 3;
            RobotController.GetComponent<UR5eController>().MoveJ(currentJointRotation);
        }
        // Wrist1-
        if(Input.GetKeyDown(KeyCode.Alpha8)){
            var currentJointRotation = jointStatesSubscriber.GetJointStates();
            currentJointRotation.wrist1Joint -= 3;
            RobotController.GetComponent<UR5eController>().MoveJ(currentJointRotation);
        }// Wrist2+
        if(Input.GetKeyDown(KeyCode.Alpha9)){
            var currentJointRotation = jointStatesSubscriber.GetJointStates();
            currentJointRotation.wrist2Joint += 3;
            RobotController.GetComponent<UR5eController>().MoveJ(currentJointRotation);
        }
        // Wrist2-
        if(Input.GetKeyDown(KeyCode.Alpha0)){
            var currentJointRotation = jointStatesSubscriber.GetJointStates();
            currentJointRotation.wrist2Joint -= 3;
            RobotController.GetComponent<UR5eController>().MoveJ(currentJointRotation);
        }// Wrist3+
        if(Input.GetKeyDown(KeyCode.N)){
            var currentJointRotation = jointStatesSubscriber.GetJointStates();
            currentJointRotation.wrist3Joint += 3;
            RobotController.GetComponent<UR5eController>().MoveJ(currentJointRotation);
        }
        // Wrist3-
        if(Input.GetKeyDown(KeyCode.M)){
            var currentJointRotation = jointStatesSubscriber.GetJointStates();
            currentJointRotation.wrist3Joint -= 3;
            RobotController.GetComponent<UR5eController>().MoveJ(currentJointRotation);
        }
        
        if(Input.GetKeyUp(KeyCode.Alpha1)){
            RobotController.GetComponent<UR5eController>().Stop();
        }if(Input.GetKeyUp(KeyCode.Alpha2)){
            RobotController.GetComponent<UR5eController>().Stop();
        }if(Input.GetKeyUp(KeyCode.Alpha3)){
            RobotController.GetComponent<UR5eController>().Stop();
        }if(Input.GetKeyUp(KeyCode.Alpha4)){
            RobotController.GetComponent<UR5eController>().Stop();
        }if(Input.GetKeyUp(KeyCode.Alpha5)){
            RobotController.GetComponent<UR5eController>().Stop();
        }if(Input.GetKeyUp(KeyCode.Alpha6)){
            RobotController.GetComponent<UR5eController>().Stop();
        }if(Input.GetKeyUp(KeyCode.Alpha7)){
            RobotController.GetComponent<UR5eController>().Stop();
        }if(Input.GetKeyUp(KeyCode.Alpha8)){
            RobotController.GetComponent<UR5eController>().Stop();
        }if(Input.GetKeyUp(KeyCode.Alpha9)){
            RobotController.GetComponent<UR5eController>().Stop();
        }if(Input.GetKeyUp(KeyCode.Alpha0)){
            RobotController.GetComponent<UR5eController>().Stop();
        }if(Input.GetKeyUp(KeyCode.N)){
            RobotController.GetComponent<UR5eController>().Stop();
        }if(Input.GetKeyUp(KeyCode.M)){
            RobotController.GetComponent<UR5eController>().Stop();
        }

        //Home Position
        if(Input.GetKeyDown(KeyCode.Space)){
            RobotController.GetComponent<UR5eController>().HomePosition();
        }

        //Gripper
        if(Input.GetKeyDown(KeyCode.G)){
            if(gripperClosed){
                RobotController.GetComponent<UR5eController>().GripperOpen();
                gripperClosed = false;
            } else {
                RobotController.GetComponent<UR5eController>().GripperClose();
                gripperClosed = true;
            }
        }

        //Program
        if(Input.GetKeyDown(KeyCode.O)){
            Vector3 waypointPosition = RobotController.GetComponent<DHTransformation>().GetTCPPosition();
            Vector3 worldPosition = tcpPose.GetTCPPositionWorld();
            RobotController.GetComponent<ProgramController>().AddWayPoint(waypointPosition, worldPosition, Quaternion.Euler(3.14f,0,0));
        }
        if(Input.GetKeyDown(KeyCode.L)){
            //Open Gripper
            RobotController.GetComponent<ProgramController>().AddGripperAction(true);
        }
        if(Input.GetKeyDown(KeyCode.K)){
            //Close Gripper
            RobotController.GetComponent<ProgramController>().AddGripperAction(false);
        }
        if(Input.GetKeyDown(KeyCode.P)){
            RobotController.GetComponent<ProgramController>().PlayProgram();
        }
        if(Input.GetKeyDown(KeyCode.I)){
            RobotController.GetComponent<ProgramController>().DeleteProgramStep(3);
        }
        if(Input.GetKeyDown(KeyCode.N)){
            RobotController.GetComponent<ProgramController>().DeleteProgramStep(4);
        }
        if(Input.GetKeyDown(KeyCode.M)){
            RobotController.GetComponent<ProgramController>().DeleteProgramStep(2);
        }
    }
}
