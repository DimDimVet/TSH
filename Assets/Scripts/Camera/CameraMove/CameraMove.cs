using UnityEngine;
using static EventBus;

public class CameraMove : MonoBehaviour
{
    [SerializeField] private CameraSettings cameraSettings;
    private Vector3 setVector;
    private GameObject cameraTarget;
    private float speedMove;
    private Construction player;
    private Transform cameraTransf;
    private bool isRun = false;

    void Start()
    {
        GetSetting();
    }

    private void GetSetting()
    {
        cameraSettings.IsUpDate = false;
        setVector = cameraSettings.GetAxes();
        speedMove = cameraSettings.SpeedMove;
        //
        cameraTransf = this.gameObject.transform;
        if (cameraTarget != null) { cameraTarget.transform.position = setVector; }
    }
    private void GetIsRun()
    {
        if (!isRun)
        {
            player = GetPlayer();
            if (player.MovePlayer != null)
            {
                cameraTarget = new GameObject("cameraTarget");
                cameraTarget.transform.parent = player.Transform;
                cameraTarget.transform.position = setVector;
                isRun = true;
            }
            else { isRun = false; print($"Камера не получила Player"); }
        }
    }
    private void MoveActiv()
    {
        if (isRun)
        {
            var curPos = cameraTarget.transform.position;
            cameraTransf.position = Vector3.Lerp(a: cameraTransf.position,
                                                 b: curPos,
                                                 t: Time.deltaTime * speedMove);
            var currRot = Quaternion.LookRotation(cameraTarget.transform.position - cameraTransf.position);
            cameraTransf.rotation = Quaternion.Lerp(a: cameraTransf.rotation,
                                                    b: currRot,
                                                    t: Time.deltaTime * speedMove);
            cameraTransf.LookAt(player.Transform.position);
        }
    }
    private void LateUpdate()
    {
        if (cameraSettings.IsUpDate)
        {
            GetSetting();
        }

        if (!isRun)
        {
            GetIsRun();
        }
        else
        {
            MoveActiv();
        }
    }
}
