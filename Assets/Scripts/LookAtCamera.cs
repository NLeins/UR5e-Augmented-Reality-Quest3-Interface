using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
    void Update()
    {
        this.gameObject.transform.rotation = Quaternion.LookRotation(this.gameObject.transform.position - Camera.main.transform.position);
    }
}
