using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TCPPose : MonoBehaviour
{
    public Transform tcp;
    private Vector3 basePosition;
    private Vector3 relativeTcpPosition;
    private Quaternion relativeTcpRotation;
    private Vector3 relativeTcpRotationRad;
    public TextMeshProUGUI x;
    public TextMeshProUGUI y;
    public TextMeshProUGUI z;
    public TextMeshProUGUI rx;
    public TextMeshProUGUI ry;
    public TextMeshProUGUI rz;

    void Start()
    {
        basePosition = this.transform.position;
    }    void Update()
    {
        if (basePosition != null && tcp != null)
        {
            // calculate relative position
            relativeTcpPosition = this.transform.InverseTransformPoint(tcp.position);
            relativeTcpPosition.z = relativeTcpPosition.z * -1;
            
            //Rotation
            relativeTcpRotation = Quaternion.Inverse(this.transform.rotation) * tcp.rotation;
            //left to right
            relativeTcpRotation = ConvertCoordinates(relativeTcpRotation);
            relativeTcpRotation = Quaternion.Euler(0, 180, 0) * relativeTcpRotation;
            relativeTcpRotationRad = relativeTcpRotation.eulerAngles * Mathf.Deg2Rad;
         
            // Control UI
            // position
            var positionTrimmed = TrimVector3(relativeTcpPosition * 1000);
            x.text = positionTrimmed.x.ToString();
            y.text = positionTrimmed.y.ToString();
            z.text = positionTrimmed.z.ToString();

            // rotation
            var rotationTrimmed = TrimVector3(relativeTcpRotationRad);
            rx.text = rotationTrimmed.x.ToString();
            ry.text = rotationTrimmed.y.ToString();
            rz.text = rotationTrimmed.z.ToString();
        }
    }
    public Vector3 GetTCPPosition()
    {
        return TrimVector3(relativeTcpPosition);
    }
    public Vector3 GetTCPPositionWorld(){
        return tcp.position;
    }
    public Vector3 GetTCPRotationEuler()
    {
        // no rotation implemented
        return new Vector3(180, 0, 0);
    }
    public Vector3 GetTCPRotationRad()
    {
        // no rotation implemented
        return new Vector3(3.14f, 0, 0);
    }
    public static Vector3 TrimVector3(Vector3 vector)
    {
        return new Vector3(
            Mathf.Round(vector.x * 100f) / 100f,
            Mathf.Round(vector.y * 100f) / 100f,
            Mathf.Round(vector.z * 100f) / 100f
        );
    }
    Quaternion ConvertCoordinates(Quaternion input) {
        return new Quaternion(
            input.y,   // -(  right = -left  )
            -input.z,   // -(     up =  up     )
            -input.x,   // -(forward =  forward)
            input.w
        );
    }
}
