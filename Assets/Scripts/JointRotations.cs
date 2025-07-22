using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct JointRotations{
    public float baseJoint;
    public float shoulderJoint;
    public float elbowJoint;
    public float wrist1Joint;
    public float wrist2Joint;
    public float wrist3Joint;
    
    public JointRotations(float base_joint, float shoulder, float elbow, float wrist1, float wrist2, float wrist3) : this()
    {
        baseJoint = base_joint;
        shoulderJoint = shoulder;
        elbowJoint = elbow;
        wrist1Joint = wrist1;
        wrist2Joint = wrist2;
        wrist3Joint = wrist3;
    }
    public override string ToString()
    {
    return $"Base: {baseJoint}, Shoulder: {shoulderJoint}, Elbow: {elbowJoint}, Wrist 1: {wrist1Joint}, Wrist 2: {wrist2Joint}, Wrist 3: {wrist3Joint}";
    }

    public string ToURScript()
    {
        return $"[{baseJoint},{shoulderJoint},{elbowJoint},{wrist1Joint},{wrist2Joint},{wrist3Joint}]";
    }
}
