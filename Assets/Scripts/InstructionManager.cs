using UnityEngine;
using UnityEngine.UI;

public class InstructionManager : MonoBehaviour
{
    public GameObject tcpCover;
    public GameObject[] instructionSteps;
    public GameObject tcpPositionBorder;
    public bool showTcpPositionBorder = false;
    public GameObject jointPositionBorder;
    public bool showJointPositionBorder = false;
    public GameObject programUIBorder;
    public bool showProgramUIBorder = false;
    public GameObject homePositionBorder;
    public bool showHomePositionBorder = false;
    public GameObject gripperActionBorder;
    public bool showGripperActionBorder = false;
    private int currentPage = 0;

    void Start()
    {
        ShowPage(currentPage);
    }
    private void OnValidate()
    {
        if(tcpPositionBorder != null)
        {
            tcpPositionBorder.SetActive(showTcpPositionBorder);
        }
        if (jointPositionBorder != null)
        {
            jointPositionBorder.SetActive(showJointPositionBorder);
        }
        if (programUIBorder != null)
        {
            programUIBorder.SetActive(showProgramUIBorder);
        }
        if (homePositionBorder != null)
        {
            homePositionBorder.SetActive(showHomePositionBorder);
        }
        if (gripperActionBorder != null)
        {
            gripperActionBorder.SetActive(showGripperActionBorder);
        }
    }

    public void NextPage()
    {
        if (currentPage < instructionSteps.Length - 1)
        {
            currentPage++;
            ShowPage(currentPage);
        }
    }

    public void PreviousPage()
    {
        if (currentPage > 0)
        {
            currentPage--;
            ShowPage(currentPage);
        }
    }

    void ShowPage(int pageIndex)
    {
        for (int i = 0; i < instructionSteps.Length; i++)
        {
            instructionSteps[i].SetActive(i == pageIndex);
        }
    }
    public void ShowTcpPositionBorder(bool show)
    {
        showTcpPositionBorder = show;
        tcpPositionBorder.SetActive(show);
    }
    public void ShowJointPositionBorder(bool show)
    {
        showJointPositionBorder = show;
        jointPositionBorder.SetActive(show);
    } 
    public void ShowProgramUIBorder(bool show)
    {
        showProgramUIBorder = show;
        programUIBorder.SetActive(show);
    }
    public void ShowHomePositionBorder(bool show)
    {
        showHomePositionBorder = show;
        homePositionBorder.SetActive(show);
    }
    public void ShowGripperActionBorder(bool show)
    {
        showGripperActionBorder = show;
        gripperActionBorder.SetActive(show);
    }
    public void ShowTcpCover(bool show)
    {
        tcpCover.SetActive(show);
    }
}
