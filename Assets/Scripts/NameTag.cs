using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NameTag : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        Quaternion nameTagRotation = Quaternion.LookRotation(this.gameObject.transform.position - Camera.main.transform.position);
        this.gameObject.transform.rotation = nameTagRotation;
    }
}
