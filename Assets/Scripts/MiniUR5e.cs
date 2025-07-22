using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniUR5e : MonoBehaviour
{
    [SerializeField] private GameObject UR5e;

    void Update()
    {
        this.gameObject.transform.rotation = UR5e.transform.rotation;
    }
}
