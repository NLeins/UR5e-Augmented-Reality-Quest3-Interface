using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ProgramUIController : MonoBehaviour
{
    public Transform contentPanel;
    public GameObject waypointToggleUIPrefab;
    public GameObject waypointPrefab;
    public GameObject gripperOpenUIPrefab;
    public GameObject gripperCloseUIPrefab;
    public ProgramController programController;
    private LineRenderer lineRenderer;

    private void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        UpdateUI();
    }

    public void UpdateUI()
    {
        // delete old entries
        foreach (Transform child in contentPanel)
        {
            Destroy(child.gameObject);
        }
        // delete waypoints
        GameObject[] waypointPrefabs = GameObject.FindGameObjectsWithTag("Waypoint");
        foreach (var waypoint in waypointPrefabs)
        {
            Destroy(waypoint);
        }

        List<Transform> waypointTransforms = new List<Transform>();
        foreach(var step in programController.programSteps)
        {
            GameObject newButtonItem = new GameObject();
            if(step is WayPoint wayPoint)
            {
                //waypoint prefab
                GameObject newWaypointItem = new GameObject();
                newWaypointItem = Instantiate(waypointPrefab, wayPoint.WorldPosition, waypointPrefab.transform.rotation);
                newWaypointItem.GetComponent<WaypointLoader>().SetIndex(wayPoint.WaypoinIndex);

                //Line Renderer
                waypointTransforms.Add(newWaypointItem.transform);

                //waypoint toggle prefab
                newButtonItem = Instantiate(waypointToggleUIPrefab, contentPanel);
                var tmpro = newButtonItem.GetComponentsInChildren<TextMeshProUGUI>();
                tmpro[1].text = wayPoint.WaypoinIndex.ToString();
                newButtonItem.GetComponent<ButtonSpawner>().buttonId = wayPoint.ProgramStepIndex;
            } else if(step is GripperAction gripperAction)
            {
                if(gripperAction.Open)
                {
                    newButtonItem = Instantiate(gripperOpenUIPrefab, contentPanel);
                    newButtonItem.GetComponent<ButtonSpawner>().buttonId = gripperAction.ProgramStepIndex;
                } else if(!gripperAction.Open)
                {
                    newButtonItem = Instantiate(gripperCloseUIPrefab, contentPanel);
                    newButtonItem.GetComponent<ButtonSpawner>().buttonId = gripperAction.ProgramStepIndex;
                }
            } 
        }
        //Update Line Renderer
        lineRenderer.positionCount = waypointTransforms.Count;
        for (int i = 0; i < waypointTransforms.Count; i++)
        {
            lineRenderer.SetPosition(i, waypointTransforms[i].position);
        }
    }
}