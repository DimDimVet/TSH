using UnityEngine;
using static EventManager;

public class MoveAvtoRifPlayer : GetInputPlayer
{
    [SerializeField] private TurnSettings avtoRifSettings;
    private Mode mode = Mode.AvtoRif;
    //���
    private Construction cameraMain;
    private Construction parentObject;
    private Vector3 currentMousePosition;
    private Ray ray;
    private Vector3 targetDirection;
    private Quaternion targetRotation;
    private float speedTurn;
    private bool isRun = false;

    void Start()
    {
        if (avtoRifSettings == null) { print($"�� ���������� Settings � MoveTurnPlayer"); }
        GetIsRun();
        GetSetting();
    }
    private void GetSetting()
    {
        speedTurn = avtoRifSettings.SpeedTurn;//
        avtoRifSettings.IsUpDate = false;
    }
    private void GetIsRun()
    {
        if (!isRun)//���� ����� ���������� �� ������ false
        {
            parentObject = OnGetPlayer();
            cameraMain = GetCamera();//�������� ������ �� �����
            if (cameraMain.CameraComponent != null & parentObject.Hash != 0) { isRun = true; }
            else { isRun = false; print($"MoveTurnPlayer �� �������� CameraComponent"); }
        }
    }
    private void TurnMove()
    {
        IsDead = parentObject.HealtPlayer.IsDead;
        if (isRun)
        {
            if (InputData.MouseRightButton != 0 && InputData.ModeAction == mode)
            {
                currentMousePosition = new Vector3(InputData.MousePosition.x, InputData.MousePosition.y, 0);
                ray = cameraMain.CameraComponent.ScreenPointToRay(currentMousePosition);//���...�� �����

                if (Physics.Raycast(ray, out RaycastHit hitInfo))
                {
                    if (TargetObjectEnemy(hitInfo))
                    {
                        targetDirection = hitInfo.point - gameObject.transform.position;
                        targetRotation = Quaternion.LookRotation(targetDirection);
                        Debug.DrawRay(gameObject.transform.position, targetDirection, Color.blue);
                        gameObject.transform.rotation =
                            Quaternion.Lerp(gameObject.transform.rotation, targetRotation, Time.deltaTime * speedTurn);
                    }
                    else
                    {
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
            var tt = hitInfo.collider.gameObject.GetHashCode();
            var temp = GetObjectHash(tt);
            if (temp.HealtEnemy != null) { return true; }
        }
        return false;
    }
    private void FixedUpdate()
    {
        if (IsDead) { return; }

        if (avtoRifSettings.IsUpDate)
        {
            GetSetting();
        }
        if (!isRun)//���� ����� ���������� �� ������ false
        {
            GetIsRun();
            return;
        }
        TurnMove();
    }
}
