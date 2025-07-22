using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;

public class ProgramController : MonoBehaviour
{
    private UR5eController robotController;
    public ProgramUIController programUIController;
    public List<object> programSteps = new List<object>();
    private int waypointIndex = 1;
    private int programStepIndex = 0;
    private List<int> selectedButton = new List<int>();
    public GameObject robotTcp;
    private Coroutine programCoroutine;

    private void Start()
    {
        robotController = this.gameObject.GetComponent<UR5eController>();
    }
    public void AddWayPointAtCurrentPosition()
    {
        AddWayPoint(robotController.GetTCPPosition(), robotTcp.transform.position, robotController.GetTCPRotation());
    }
    public void AddWayPoint(Vector3 robotPosition, Vector3 worldPosition, Quaternion rotation)
    {
        WayPoint newWayPoint = new WayPoint(robotPosition, worldPosition, rotation, waypointIndex, programStepIndex);
        programSteps.Add(newWayPoint);
        programUIController.UpdateUI();
        waypointIndex++;
        programStepIndex++;
        Debug.Log("Waypoint Added " + newWayPoint.RobotPosition);
    }
    public void AddGripperAction(bool open)
    {
        GripperAction newGripperAction = new GripperAction(open, programStepIndex);
        programSteps.Add(newGripperAction);
        programUIController.UpdateUI();
        programStepIndex++;

        //execute gripper action
        if(open){
            robotController.GripperOpen();
        } else { robotController.GripperClose(); }
    }
    public void PlayProgram()
    {
        Debug.Log("Play");
        programCoroutine = StartCoroutine(ExecuteProgram());
    }
    public void StopProgramm()
    {
        StopCoroutine(programCoroutine);
        programCoroutine = null;
        Debug.Log("Coroutine Stop");
    }
    private IEnumerator ExecuteProgram()
    {
        foreach (var step in programSteps)
        {
            if (step is WayPoint)
            {
                WayPoint wp = step as WayPoint;
                yield return MoveToWayPoint(wp);
                yield return new WaitForSeconds(0.5f);
            }
            else if (step is GripperAction)
            {
                GripperAction ga = step as GripperAction;
                yield return SetGripper(ga);
                yield return new WaitForSeconds(2.5f);
            }
        }
    }
    private IEnumerator MoveToWayPoint(WayPoint wp)
    {
        robotController.MoveL(wp.RobotPosition, velocity: 1.45f, acceleration: 0.3f);
        StartCoroutine(robotController.PositionReachedCoroutine(wp.RobotPosition));
        while(robotController.IsMoving()){
            yield return null;
        }
    }
    private IEnumerator SetGripper(GripperAction ga)
    {
        if(ga.Open)
        {
            robotController.GripperOpen();
        } else
        {
            robotController.GripperClose();
        }
        yield return null;
    }
    public void DeleteProgramStep(int index)
    {
        programSteps.RemoveAll(step => step is WayPoint && (step as WayPoint).ProgramStepIndex == index);
        programSteps.RemoveAll(step => step is GripperAction && (step as GripperAction).ProgramStepIndex == index);

        programUIController.UpdateUI();
    }
    public void ResetProgram()
    {
        programSteps.Clear();
        programUIController.UpdateUI();
        waypointIndex = 1;
    }
    public void SelectButton(int index){
        selectedButton.Add(index);
    }
    public void DeselectButton(int index){
        selectedButton.Remove(index);
    }
    public void DeleteSelectedButton(){
        if(selectedButton.Count == 0){
            ResetProgram();
        } else {
            foreach (var index in selectedButton)
            {
                DeleteProgramStep(index);
            }
            selectedButton.Clear();
        }
    }
}
