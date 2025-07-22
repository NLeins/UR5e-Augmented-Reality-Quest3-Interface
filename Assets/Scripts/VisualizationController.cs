using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class VisualizationController : MonoBehaviour
{
    [SerializeField] private GameObject baseRotationArrows;
    [SerializeField] private bool showBaseRotationArrows = true;
    [SerializeField] private GameObject baseNameTag;
    [SerializeField] private bool showBaseNameTag = true;
    [SerializeField] private GameObject baseCoordinateSystem;
    [SerializeField] private bool showBaseCoordinateSystem = true;
    [SerializeField] private GameObject shoulderRotationArrows;
    [SerializeField] private bool showShoulderRotationArrows = true;
    [SerializeField] private GameObject shoulderNameTag;
    [SerializeField] private bool showShoulderNameTag = true;
    [SerializeField] private GameObject elbowRotationArrows;
    [SerializeField] private bool showElbowRotationArrows = true;
    [SerializeField] private GameObject elbowNameTag;
    [SerializeField] private bool showElbowNameTag = true;
    [SerializeField] private GameObject wrist1RotationArrows;
    [SerializeField] private bool showWrist1RotationArrows = true;
    [SerializeField] private GameObject wrist1NameTag;
    [SerializeField] private bool showWrist1NameTag = true;
    [SerializeField] private GameObject wrist2RotationArrows;
    [SerializeField] private bool showWrist2RotationArrows = true;
    [SerializeField] private GameObject wrist2NameTag;
    [SerializeField] private bool showWrist2NameTag = true;
    [SerializeField] private GameObject wrist3RotationArrows;
    [SerializeField] private bool showWrist3RotationArrows = true;
    [SerializeField] private GameObject wrist3NameTag;
    [SerializeField] private bool showWrist3NameTag = true;
    [SerializeField] private GameObject tcpRotationArrows;
    [SerializeField] private bool showTcpRotationArrows = true;
    [SerializeField] private GameObject tcpPositionArrows;
    [SerializeField] private GameObject miniTcpPositionArrows;
    [SerializeField] private bool showTcpPositionArrows = true;
    [SerializeField] private GameObject tcpNameTag;
    [SerializeField] private bool showTCPNameTag = true;
    // Start is called before the first frame update
    private void OnValidate()
    {
        if (baseRotationArrows != null)
        {
            baseRotationArrows.SetActive(showBaseRotationArrows);
        }
        if (shoulderRotationArrows != null)
        {
            shoulderRotationArrows.SetActive(showShoulderRotationArrows);
        }
        if (elbowRotationArrows != null)
        {
            elbowRotationArrows.SetActive(showElbowRotationArrows);
        }
        if (wrist1RotationArrows != null)
        {
            wrist1RotationArrows.SetActive(showWrist1RotationArrows);
        }
        if (wrist2RotationArrows != null)
        {
            wrist2RotationArrows.SetActive(showWrist2RotationArrows);
        }
        if (wrist3RotationArrows != null)
        {
            wrist3RotationArrows.SetActive(showWrist3RotationArrows);
        }
        if (tcpRotationArrows != null)
        {
            tcpRotationArrows.SetActive(showTcpRotationArrows);
        }
        if (tcpPositionArrows != null && miniTcpPositionArrows != null)
        {
            tcpPositionArrows.SetActive(showTcpPositionArrows);
            miniTcpPositionArrows.SetActive(showTcpPositionArrows);
        }
        if (wrist1NameTag != null)
        {
            wrist1NameTag.SetActive(showWrist1NameTag);
        }
        if (wrist2NameTag != null)
        {
            wrist2NameTag.SetActive(showWrist2NameTag);
        }
        if (wrist3NameTag != null)
        {
            wrist3NameTag.SetActive(showWrist3NameTag);
        }
        if (baseNameTag != null)
        {
            baseNameTag.SetActive(showBaseNameTag);
        }
        if (elbowNameTag!= null)
        {
            elbowNameTag.SetActive(showElbowNameTag);
        }
        if (shoulderNameTag!= null)
        {
            shoulderNameTag.SetActive(showShoulderNameTag);
        }
        if (tcpNameTag!= null)
        {
            tcpNameTag.SetActive(showTCPNameTag);
        }
        if (baseCoordinateSystem != null)
        {
            baseCoordinateSystem.SetActive(showBaseCoordinateSystem);
        }
    }
    public void ShowAllArrows(bool show)
    {
        ShowBaseRotationArrows(show);
        ShowShoulderRotationArrows(show);
        ShowElbowRotationArrows(show);
        ShowWrist1RotationArrows(show);
        ShowWrist2RotationArrows(show);
        ShowWrist3RotationArrows(show);
        ShowTcpRotationArrows(show);
        ShowTcpPositionArrows(show);
    }
    public void ShowBaseRotationArrows(bool show)
    {
        showBaseRotationArrows = show;
        baseRotationArrows.SetActive(show);
    }
    public void ShowShoulderRotationArrows(bool show)
    {
        showShoulderRotationArrows = show;
        shoulderRotationArrows.SetActive(show);
    }
    public void ShowElbowRotationArrows(bool show)
    {
        showElbowRotationArrows = show;
        elbowRotationArrows.SetActive(show);
    }
    public void ShowWrist1RotationArrows(bool show)
    {
        showWrist1RotationArrows = show;
        wrist1RotationArrows.SetActive(show);
    }
    public void ShowWrist2RotationArrows(bool show)
    {
        showWrist2RotationArrows = show;
        wrist2RotationArrows.SetActive(show);
    }
    public void ShowWrist3RotationArrows(bool show)
    {
        showWrist3RotationArrows = show;
        wrist3RotationArrows.SetActive(show);
    }
    public void ShowTcpRotationArrows(bool show)
    {
        showTcpRotationArrows = show;
        tcpRotationArrows.SetActive(show);
    }
    public void ShowTcpPositionArrows(bool show)
    {
        showTcpPositionArrows = show;
        tcpPositionArrows.SetActive(show);
        miniTcpPositionArrows.SetActive(show);
    }
    public void ShowJointNameTags(bool show)
    {
        showBaseNameTag = show;
        showShoulderNameTag = show;
        showElbowNameTag = show;
        showWrist1NameTag = show;
        showWrist2NameTag = show;
        showWrist3NameTag = show;
        baseNameTag.SetActive(show);
        shoulderNameTag.SetActive(show);
        elbowNameTag.SetActive(show);
        wrist1NameTag.SetActive(show);
        wrist2NameTag.SetActive(show);
        wrist3NameTag.SetActive(show);
    }
    public void ShowTcpNameTag(bool show)
    {
        showTCPNameTag = show;
        tcpNameTag.SetActive(show);
    }
    public void ShowBaseCoordinateSystem(bool show)
    {
        showBaseCoordinateSystem = show;
        baseCoordinateSystem.SetActive(show);
    }
}
