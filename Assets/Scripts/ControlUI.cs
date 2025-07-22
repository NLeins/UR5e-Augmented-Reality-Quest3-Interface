using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ControlUI : MonoBehaviour
{
    public UR5eController ur5eController;
    public JointStatesSubscriber jointStatesSubscriber;
    public DHTransformation dHTransformation;
    [SerializeField]
    private TextMeshProUGUI protocollText;
    private Vector3 moveTcpTo;
    private JointRotations rotateTo;

    public void ProtocolMessage(string text){
        protocollText.text = text;
        protocollText.GetComponent<AudioSource>().Play();
    }
    public void ClearProtocol(){
        protocollText.text = "";
    }
    public void Stop(){
        ur5eController.Stop();
    }
    public void GripperOpen(){
        ur5eController.GripperOpen();
    }
    public void GripperClose(){
        ur5eController.GripperClose();
    }

    public void HomePosition(){
        ur5eController.HomePosition();
    }
    public void TcpPositionX(float moveX){
        moveTcpTo = dHTransformation.GetTCPPosition();
        moveTcpTo.x += moveX;
        ur5eController.MoveL(moveTcpTo, 0.045f);
    }    
    public void TcpPositionY(float moveY){
        moveTcpTo = dHTransformation.GetTCPPosition();
        moveTcpTo.y += moveY;
        ur5eController.MoveL(moveTcpTo, 0.045f);
    }    
    public void TcpPositionZ(float moveZ){
        moveTcpTo = dHTransformation.GetTCPPosition();
        moveTcpTo.z += moveZ;
        ur5eController.MoveL(moveTcpTo, 0.045f);
    }
    public void RotateBase(float angle)
    {
        rotateTo = jointStatesSubscriber.GetJointStates();
        rotateTo.baseJoint += angle;
        ur5eController.MoveJ(rotateTo);
    }
    public void RotateShoulder(float angle)
    {
        rotateTo = jointStatesSubscriber.GetJointStates();
        rotateTo.shoulderJoint += angle;
        ur5eController.MoveJ(rotateTo);
    }
    public void RotatElbow(float angle)
    {
        rotateTo = jointStatesSubscriber.GetJointStates();
        rotateTo.elbowJoint += angle;
        ur5eController.MoveJ(rotateTo);
    }
    public void RotateWrist1(float angle)
    {
        rotateTo = jointStatesSubscriber.GetJointStates();
        rotateTo.wrist1Joint += angle;
        ur5eController.MoveJ(rotateTo);
    }
    public void RotateWrist2(float angle)
    {
        rotateTo = jointStatesSubscriber.GetJointStates();
        rotateTo.wrist2Joint += angle;
        ur5eController.MoveJ(rotateTo);
    }
    public void RotateWrist3(float angle)
    {
        rotateTo = jointStatesSubscriber.GetJointStates();
        rotateTo.wrist3Joint += angle;
        ur5eController.MoveJ(rotateTo);
    }
}
