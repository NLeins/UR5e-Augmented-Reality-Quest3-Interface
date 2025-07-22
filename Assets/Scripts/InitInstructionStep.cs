using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitInstructionStep : MonoBehaviour
{
    [SerializeField] private VisualizationController visualizationController;
    [SerializeField] private InstructionManager instructionManager;
    [SerializeField] private bool showTcpCover = false;
    [SerializeField] private bool showTCPNameTag = false;
    [SerializeField] private bool showJointNameTags = false;
    [SerializeField] private bool showBaseCoordinateSystem = false;
    [SerializeField] private bool showTCPCoordianteSystem = false;
    [SerializeField] private bool highlightTcpPosition = false;
    [SerializeField] private bool highlightProgrammUI = false;
    [SerializeField] private bool highlightJointPosition = false;
    [SerializeField] private bool highlightGripperButton= false;
    [SerializeField] private bool highlightHomePosition = false;
    
    void OnEnable()
    {
        visualizationController.ShowTcpNameTag(showTCPNameTag);
        visualizationController.ShowJointNameTags(showJointNameTags);
        visualizationController.ShowBaseCoordinateSystem(showBaseCoordinateSystem);
        visualizationController.ShowTcpPositionArrows(showTCPCoordianteSystem);
        instructionManager.ShowTcpPositionBorder(highlightTcpPosition);
        instructionManager.ShowProgramUIBorder(highlightProgrammUI);
        instructionManager.ShowJointPositionBorder(highlightJointPosition);
        instructionManager.ShowGripperActionBorder(highlightGripperButton);
        instructionManager.ShowHomePositionBorder(highlightHomePosition);
        instructionManager.ShowTcpCover(showTcpCover);
    }
}
