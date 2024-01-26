using UnityEngine;
using static EventBus;

public class MoveAvtoRifPlayer : GetInputPlayer
{
    [SerializeField] private TurnSettings avtoRifSettings;
    private Mode mode = Mode.AvtoRif;
    //кэш
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
        if (avtoRifSettings == null) { print($"Не установлен Settings в MoveTurnPlayer"); }
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
        if (!isRun)//если общее разрешение на запуск false
        {
            parentObject = OnGetPlayer();
            cameraMain = GetCamera();//получаем данные из листа
            if (cameraMain.CameraComponent != null & parentObject.Hash != 0) { isRun = true; }
            else { isRun = false; }
        }
    }
    private void TurnMove()
    {
        IsDead = parentObject.HealtPlayer.IsDead;
        if (isRun)
        {
            if (/*InputData.MouseRightButton != 0 &&*/ InputData.ModeAction == mode)
            {
                currentMousePosition = new Vector3(InputData.MousePosition.x, InputData.MousePosition.y, 0);
                ray = cameraMain.CameraComponent.ScreenPointToRay(currentMousePosition);//луч...до мышки

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
        return false;
    }
    private void FixedUpdate()
    {
        if (IsDead) { return; }

        if (avtoRifSettings.IsUpDate)
        {
            GetSetting();
        }
        if (!isRun)//если общее разрешение на запуск false
        {
            GetIsRun();
            return;
        }
        TurnMove();
    }
}
