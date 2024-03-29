using UnityEngine;
using static EventBus;

public class MoveTurnPlayer : GetInputPlayer
{
    [SerializeField] private TurnSettings turnSettings;
    [SerializeField] GameObject objectMaus;
    private Mode mode = Mode.Turn;
    private Construction cameraMain;
    private Construction parentObject, tempTarget;
    private Vector3 currentMousePosition;
    private Ray ray;
    private Vector3 targetDirection;
    private Quaternion targetRotation;
    private float speedTurn;
    private int tempHash;
    private bool isRun = false;

    void Start()
    {
        if (turnSettings == null) { print($"�� ���������� Settings � MoveTurnPlayer"); }
        GetSetting();
    }
    private void GetSetting()
    {
        speedTurn = turnSettings.SpeedTurn;
        turnSettings.IsUpDate = false;
    }
    private void GetIsRun()
    {
        if (!isRun)
        {
            parentObject = OnGetPlayer();
            cameraMain = GetCamera();
            if (cameraMain.CameraComponent != null & parentObject.Hash != 0) { isRun = true; }
            else { isRun = false; return; }

        }
    }
    private void TurnMove()
    {
        IsDead = parentObject.HealtPlayer.IsDead;
        if (isRun)
        {
            if (InputData.ModeAction == mode)
            {
                currentMousePosition = (Vector2)InputData.MousePosition;
                ray = cameraMain.CameraComponent.ScreenPointToRay(currentMousePosition);//���...�� �����
                if (Physics.Raycast(ray, out RaycastHit hitInfo))
                {
                    if (TargetObjectEnemy(hitInfo))
                    {
                        SelectCursor(true);
                        targetDirection = hitInfo.point - gameObject.transform.position;
                        targetRotation = Quaternion.LookRotation(targetDirection);
                        Debug.DrawRay(gameObject.transform.position, targetDirection, Color.blue);
                        gameObject.transform.rotation =
                            Quaternion.Lerp(gameObject.transform.rotation, targetRotation, Time.deltaTime * speedTurn);
                    }
                    else
                    {
                        SelectCursor(false);
                        targetDirection = hitInfo.point - gameObject.transform.position;
                        targetRotation = Quaternion.LookRotation(targetDirection);
                        targetRotation.x = 0;
                        targetRotation.z = 0;
                        Debug.DrawRay(gameObject.transform.position, targetDirection, Color.blue);
                        gameObject.transform.rotation =
                           Quaternion.Lerp(gameObject.transform.rotation, targetRotation, Time.deltaTime * speedTurn);
                    }

                }
            }
        }
    }
    private bool TargetObjectEnemy(RaycastHit hitInfo)
    {
        if (hitInfo.collider != null)
        {
            tempHash = hitInfo.collider.gameObject.GetHashCode();
            tempTarget = GetObjectHash(tempHash);
            if (tempTarget.HealtEnemy != null)
            {
                if (tempTarget.HealtEnemy.IsDead == false) { return true; }
            }
        }
        return false;
    }
    private void FixedUpdate()
    {
        if (IsDead) { return; }

        if (turnSettings.IsUpDate)
        {
            GetSetting();
        }
        if (!isRun)
        {
            GetIsRun();
            return;
        }
        TurnMove();
    }

}
