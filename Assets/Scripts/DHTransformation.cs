using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DHTransformation : MonoBehaviour
{
    public JointStatesSubscriber jointStatesSubscriber;
    private Matrix4x4 T1;
    private Matrix4x4 T2;
    private Matrix4x4 T3;
    private Matrix4x4 T4;
    private Matrix4x4 T5;
    private Matrix4x4 T6;
    private Matrix4x4 Ttool;
    private Matrix4x4 Ttcp;

    private float[] jointParameters1;
    private float[] jointParameters2;
    private float[] jointParameters3;
    private float[] jointParameters4;
    private float[] jointParameters5;
    private float[] jointParameters6;
    // Start is called before the first frame update
    void Start()
    {
        jointStatesSubscriber = jointStatesSubscriber.GetComponent<JointStatesSubscriber>();

        T1 = new Matrix4x4();
        T2 = new Matrix4x4();
        T3 = new Matrix4x4();
        T4 = new Matrix4x4();
        T5 = new Matrix4x4();
        T6 = new Matrix4x4();
        
        jointParameters1 = new float[] {0.00000f, 0.1625f, 1.57079633f};
        jointParameters2 = new float[] {-0.4250f, 0f, 0f};
        jointParameters3 = new float[] {-0.3922f, 0f, 0f};
        jointParameters4 = new float[] {0f, 0.1333f, 1.57079633f};
        jointParameters5 = new float[] {0f, 0.0997f, -1.57079633f};
        jointParameters6 = new float[] {0f, 0.0996f, 0f};
    }

    void Update()
    {
        var jointRotations = jointStatesSubscriber.GetJointStates();
        
        //T1
        T1.SetRow(0, new Vector4( Mathf.Cos(jointRotations.baseJoint),  -(Mathf.Sin(jointRotations.baseJoint)*Mathf.Cos(jointParameters1[2])),  Mathf.Sin(jointRotations.baseJoint)*Mathf.Sin(jointParameters1[2]),  jointParameters1[0]*Mathf.Cos(jointRotations.baseJoint)));
        T1.SetRow(1, new Vector4( Mathf.Sin(jointRotations.baseJoint), Mathf.Cos(jointRotations.baseJoint)*Mathf.Cos(jointParameters1[2]), -(Mathf.Cos(jointRotations.baseJoint))*Mathf.Sin(jointParameters1[2]), jointParameters1[0]*Mathf.Sin(jointRotations.baseJoint)));
        T1.SetRow(2, new Vector4( 0f, Mathf.Sin(jointParameters1[2]), Mathf.Cos(jointParameters1[2]), jointParameters1[1]));
        T1.SetRow(3, new Vector4( 0.00000f,  0.00000f,  0.00000f,  1.00000f ));
        //T1
        T2.SetRow(0, new Vector4( Mathf.Cos(jointRotations.shoulderJoint),  -(Mathf.Sin(jointRotations.shoulderJoint)*Mathf.Cos(jointParameters2[2])),  Mathf.Sin(jointRotations.shoulderJoint)*Mathf.Sin(jointParameters2[2]),  jointParameters2[0]*Mathf.Cos(jointRotations.shoulderJoint)));
        T2.SetRow(1, new Vector4( Mathf.Sin(jointRotations.shoulderJoint), Mathf.Cos(jointRotations.shoulderJoint)*Mathf.Cos(jointParameters2[2]), -(Mathf.Cos(jointRotations.shoulderJoint))*Mathf.Sin(jointParameters2[2]), jointParameters2[0]*Mathf.Sin(jointRotations.shoulderJoint)));
        T2.SetRow(2, new Vector4( 0f, Mathf.Sin(jointParameters2[2]), Mathf.Cos(jointParameters2[2]), jointParameters2[1]));
        T2.SetRow(3, new Vector4( 0.00000f,  0.00000f,  0.00000f,  1.00000f ));
        //T1
        T3.SetRow(0, new Vector4( Mathf.Cos(jointRotations.elbowJoint),  -(Mathf.Sin(jointRotations.elbowJoint)*Mathf.Cos(jointParameters3[2])),  Mathf.Sin(jointRotations.elbowJoint)*Mathf.Sin(jointParameters3[2]),  jointParameters3[0]*Mathf.Cos(jointRotations.elbowJoint)));
        T3.SetRow(1, new Vector4( Mathf.Sin(jointRotations.elbowJoint), Mathf.Cos(jointRotations.elbowJoint)*Mathf.Cos(jointParameters3[2]), -(Mathf.Cos(jointRotations.elbowJoint))*Mathf.Sin(jointParameters3[2]), jointParameters3[0]*Mathf.Sin(jointRotations.elbowJoint)));
        T3.SetRow(2, new Vector4( 0f, Mathf.Sin(jointParameters3[2]), Mathf.Cos(jointParameters3[2]), jointParameters3[1]));
        T3.SetRow(3, new Vector4( 0.00000f,  0.00000f,  0.00000f,  1.00000f ));
        //T1
        T4.SetRow(0, new Vector4( Mathf.Cos(jointRotations.wrist1Joint),  -(Mathf.Sin(jointRotations.wrist1Joint)*Mathf.Cos(jointParameters4[2])),  Mathf.Sin(jointRotations.wrist1Joint)*Mathf.Sin(jointParameters4[2]),  jointParameters4[0]*Mathf.Cos(jointRotations.wrist1Joint)));
        T4.SetRow(1, new Vector4( Mathf.Sin(jointRotations.wrist1Joint), Mathf.Cos(jointRotations.wrist1Joint)*Mathf.Cos(jointParameters4[2]), -(Mathf.Cos(jointRotations.wrist1Joint))*Mathf.Sin(jointParameters4[2]), jointParameters4[0]*Mathf.Sin(jointRotations.wrist1Joint)));
        T4.SetRow(2, new Vector4( 0f, Mathf.Sin(jointParameters4[2]), Mathf.Cos(jointParameters4[2]), jointParameters4[1]));
        T4.SetRow(3, new Vector4( 0.00000f,  0.00000f,  0.00000f,  1.00000f ));
        //T1
        T5.SetRow(0, new Vector4( Mathf.Cos(jointRotations.wrist2Joint),  -(Mathf.Sin(jointRotations.wrist2Joint)*Mathf.Cos(jointParameters5[2])),  Mathf.Sin(jointRotations.wrist2Joint)*Mathf.Sin(jointParameters5[2]),  jointParameters5[0]*Mathf.Cos(jointRotations.wrist2Joint)));
        T5.SetRow(1, new Vector4( Mathf.Sin(jointRotations.wrist2Joint), Mathf.Cos(jointRotations.wrist2Joint)*Mathf.Cos(jointParameters5[2]), -(Mathf.Cos(jointRotations.wrist2Joint))*Mathf.Sin(jointParameters5[2]), jointParameters5[0]*Mathf.Sin(jointRotations.wrist2Joint)));
        T5.SetRow(2, new Vector4( 0f, Mathf.Sin(jointParameters5[2]), Mathf.Cos(jointParameters5[2]), jointParameters5[1]));
        T5.SetRow(3, new Vector4( 0.00000f,  0.00000f,  0.00000f,  1.00000f ));
        //T1
        T6.SetRow(0, new Vector4( Mathf.Cos(jointRotations.wrist3Joint),  -(Mathf.Sin(jointRotations.wrist3Joint)*Mathf.Cos(jointParameters6[2])),  Mathf.Sin(jointRotations.wrist3Joint)*Mathf.Sin(jointParameters6[2]),  jointParameters6[0]*Mathf.Cos(jointRotations.wrist3Joint)));
        T6.SetRow(1, new Vector4( Mathf.Sin(jointRotations.wrist3Joint), Mathf.Cos(jointRotations.wrist3Joint)*Mathf.Cos(jointParameters6[2]), -(Mathf.Cos(jointRotations.wrist3Joint))*Mathf.Sin(jointParameters6[2]), jointParameters6[0]*Mathf.Sin(jointRotations.wrist3Joint)));
        T6.SetRow(2, new Vector4( 0f, Mathf.Sin(jointParameters6[2]), Mathf.Cos(jointParameters6[2]), jointParameters6[1]));
        T6.SetRow(3, new Vector4( 0.00000f,  0.00000f,  0.00000f,  1.00000f ));

        // TCP offset
        Ttool.SetRow(0, new Vector4(1,0,0,0));
        Ttool.SetRow(1, new Vector4(0,1,0,0));
        Ttool.SetRow(2, new Vector4(0,0,1,0.2286f));
        Ttool.SetRow(3, new Vector4(0,0,0,1));

        Ttcp = T1 * T2 * T3 * T4 * T5 * T6 * Ttool;    
    }
    public Vector3 GetTCPPosition()
    {
        return Ttcp.GetPosition();
    } 
    public Quaternion GetTCPRotation()
    {
        // no rotation implemented
        return Quaternion.Euler(180, 0, 0);
    }
}
