using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class AnchorPlacer : MonoBehaviour
{
    private GameObject robot;
    void Start()
    {
        // delayed placement of anchor to avoid bugs
        StartCoroutine(DelayedPlacement());
    }
    private IEnumerator DelayedPlacement()
    {
        yield return new WaitForSeconds(3f); // wait for 0.5 seconds
        // place robot on anchor
        robot = GameObject.FindWithTag("Robot");
        robot.transform.position = this.gameObject.transform.position;
        robot.transform.rotation = this.gameObject.transform.rotation;
    }
}
