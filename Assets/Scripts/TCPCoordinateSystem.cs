using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TCPCoordinateSystem : MonoBehaviour
{
    private GameObject robot;
    void Start()
    {
        robot = GameObject.FindWithTag("Robot");
    }
    void Update()
    {
        this.gameObject.transform.rotation = robot.transform.rotation;
    }
}
