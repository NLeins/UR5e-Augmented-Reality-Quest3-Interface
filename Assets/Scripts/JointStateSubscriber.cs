using UnityEngine;
using RosMessageTypes.Sensor;
using Unity.Robotics.ROSTCPConnector;
using Unity.VisualScripting;
using TMPro;
using System;

public class JointStatesSubscriber : MonoBehaviour
{
    public ROSConnection ros;
    public UR5eController robotController;
    [SerializeField] private ControlUI controlUI;
    private string topicName = "/joint_states";

    public GameObject[] jointObjects;
    private Vector3[] currentRotation;
    private JointRotations jointRotations;

    [SerializeField] private TextMeshProUGUI baseJointText;
    [SerializeField] private TextMeshProUGUI shoulderJointText;
    [SerializeField] private TextMeshProUGUI elbowJointText;
    [SerializeField] private TextMeshProUGUI wrist1JointText;
    [SerializeField] private TextMeshProUGUI wrist2JointText;
    [SerializeField] private TextMeshProUGUI wrist3JointText;
    [SerializeField] private bool limitReached = false;

    void Start()
    {
        currentRotation = new Vector3[jointObjects.Length]; 
        for (int i = 0; i < jointObjects.Length; i++)
        {
            currentRotation[i] = jointObjects[i].transform.localEulerAngles;
        }
        
        // subcribe joint_states topic
        ros.Subscribe<JointStateMsg>(topicName, ReceiveJointStates);
       
    }

    // Callback-Function
    private void ReceiveJointStates(JointStateMsg jointStateMessage)
    {
        var jointStates = new float[6];
        for (int i = 0; i < jointStateMessage.name.Length; i++)
        {
            // get join rotation
            float angleInDegrees = (float)(jointStateMessage.position[i] * (180.0f / Mathf.PI));
            int zRotation = (int)angleInDegrees;
           
            jointStates[i] = (float)jointStateMessage.position[i];
            // set joint rotation 
            jointObjects[i].transform.localRotation = Quaternion.Euler(currentRotation[i].x, currentRotation[i].y,zRotation);
        }

        jointRotations = new JointRotations(jointStates[5], jointStates[0], jointStates[1], jointStates[2], jointStates[3], jointStates[4]);
        
        if(baseJointText != null)
        {
            baseJointText.text = ((int)(jointRotations.baseJoint * (180.0f / Mathf.PI))).ToString();
            shoulderJointText.text = ((int)(jointRotations.shoulderJoint * (180.0f / Mathf.PI))).ToString();
            elbowJointText.text = ((int)(jointRotations.elbowJoint * (180.0f / Mathf.PI))).ToString();
            wrist1JointText.text = ((int)(jointRotations.wrist1Joint * (180.0f / Mathf.PI))).ToString();
            wrist2JointText.text = ((int)(jointRotations.wrist2Joint * (180.0f / Mathf.PI))).ToString();
            wrist3JointText.text = ((int)(jointRotations.wrist3Joint * (180.0f / Mathf.PI))).ToString();
        }

        //Joint limits
        if (controlUI != null){
            if(Mathf.Abs(jointRotations.baseJoint) > 6.1f){
                LimitReached();
            } else if (jointRotations.shoulderJoint < -3f){
                LimitReached();
            } else if (jointRotations.shoulderJoint > -0.1f){
                LimitReached();
            } else if (Mathf.Abs(jointRotations.elbowJoint) > 6.1f){
                LimitReached();
            } else if (Mathf.Abs(jointRotations.wrist1Joint) > 6.1f){
                LimitReached();
            } else if (Mathf.Abs(jointRotations.wrist2Joint) > 6.1f){
                LimitReached();
            } else if (Mathf.Abs(jointRotations.wrist3Joint) > 6.1f){
                LimitReached();
            } else {
                if(limitReached){
                    controlUI.ClearProtocol();
                }
                limitReached = false;
            }
        }
    }
    private void LimitReached(){
        if(!limitReached){
            robotController.LimitStop();
            controlUI.ProtocolMessage("Sicherheitsstopp! Gelenkwinkelgrenze erreicht.");
        }
        limitReached = true;
    }
    public JointRotations GetJointStates(){
        return jointRotations;
    }
}