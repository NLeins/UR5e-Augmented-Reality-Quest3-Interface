using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WaypointLoader : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI textIndex;
    public void SetIndex(int index)
    {
        textIndex.text = "Wegpunkt " + index.ToString();
    }
}
