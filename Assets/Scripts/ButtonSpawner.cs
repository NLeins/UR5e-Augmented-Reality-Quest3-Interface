using System.Collections;
using System.Collections.Generic;
using RosMessageTypes.UrDashboard;
using UnityEngine;
using UnityEngine.UI;
public class ButtonSpawner : MonoBehaviour
{
    public int buttonId { get; set; }
    private ProgramController programController;
    private Toggle toggle;

    void Start()
    {
        programController = GameObject.Find("RobotController").GetComponent<ProgramController>();
        toggle = GetComponentInChildren<Toggle>();
    }
    public void ButtonSelected(){
        if(toggle.isOn){
            programController.SelectButton(buttonId);
        }
        else{
            programController.DeselectButton(buttonId);
        }
    }
}