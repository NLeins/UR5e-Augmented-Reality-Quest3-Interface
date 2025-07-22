using UnityEngine;

public class RobotLimitTrigger : MonoBehaviour
{
    public UR5eController robotController;
    [SerializeField] private ControlUI controlUI;
    private GameObject limitVisualization;
    void Start()
    {
        limitVisualization = transform.GetChild(0).gameObject;
    }
    void OnTriggerEnter(Collider other)
    {
        robotController.LimitStop();
        controlUI.ProtocolMessage("Sicherheitsstopp! Roboter hat Begrenzung erreicht.");
        if(limitVisualization != null){
            limitVisualization.SetActive(true);
        }
    }
    void OnTriggerExit(Collider other){
        robotController.LimitReached(false);
        controlUI.ClearProtocol();
        if(limitVisualization != null){
            limitVisualization.SetActive(false);
        }
    }
}
