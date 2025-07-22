using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class AppManager : MonoBehaviour
{
    void Start()
    {
        CultureInfo.DefaultThreadCurrentCulture = CultureInfo.InvariantCulture;
        CultureInfo.DefaultThreadCurrentUICulture = CultureInfo.InvariantCulture;
    }
}
