using UnityEngine;
using static EventManager;

public class MoveTurnPlayer : GetInputPlayer
{
    [SerializeField] private TurnSettings turnSettings;
    [SerializeField] GameObject objectMaus;
    private Mode mode = Mode.Turn;
    //кэш
    private Construction cameraMain;
    private Vector3 currentMousePosition;
    private Ray ray;
    private Vector3 targetDirection;
    private Quaternion targetRotation;
    private float speedTurn;
    private Construction parentObject;
    private bool isRun = false, isDead=false;

    void Start()
    {
        if (turnSettings == null) { print($"Не установлен Settings в MoveTurnPlayer"); }
        GetIsRun();
        GetSetting();
    }
    private void GetSetting()
    {
        speedTurn = turnSettings.SpeedTurn;//
        turnSettings.IsUpDate = false;
    }
    private void GetIsRun()
    {
        if (!isRun)//если общее разрешение на запуск false
        {
            parentObject = OnGetPlayer();
            cameraMain = GetCamera();//получаем данные из листа
            if (cameraMain.CameraComponent != null & parentObject.Hash!=0) { isRun = true; }
            else { isRun = false; print($"MoveTurnPlayer не получила CameraComponent");return; }
            
        }
    }
    private void TurnMove()
    {
        isDead = parentObject.HealtPlayer.IsDead;
        if (isRun)
        {
            if (InputData.MouseRightButton != 0 && InputData.ModeAction == mode)
            {
                currentMousePosition = (Vector2)InputData.MousePosition;
                ray = cameraMain.CameraComponent.ScreenPointToRay(currentMousePosition);//луч...до мышки
                if (Physics.Raycast(ray, out RaycastHit hitInfo))
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
    private void FixedUpdate()
    {
        if (isDead) { return; }

        if (turnSettings.IsUpDate)
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
