using UnityEngine;
using static EventManager;

public class MoveTurnPlayer : GetInputPlayer
{
    [SerializeField] private TurnSettings turnSettings;
    private bool NotActionClass = false;
    //���
    private Construction cameraMain;
    private Vector3 currentMousePosition;
    private Ray ray;
    private Vector3 targetDirection;
    private Quaternion targetRotation;
    private float speedTurn;
    private bool isRun = false;

    void Start()
    {
        if (turnSettings == null) { print($"�� ���������� Settings � MoveTurnPlayer"); NotActionClass = true; }
        if (NotActionClass) { return; }//�������� �����������
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
        if (!isRun)//���� ����� ���������� �� ������ false
        {
            cameraMain = GetCamera();//�������� ������ �� �����
            if (cameraMain.CameraComponent != null) { isRun = true; }
            else { isRun = false; print($"MoveTurnPlayer �� �������� CameraComponent"); }
        }
    }
    private void TurnMove()
    {
        if (isRun)
        {
            if (InputData.MouseLeftButton != 0)
            {
                currentMousePosition = new Vector3(InputData.MousePosition.x, InputData.MousePosition.y, 0);
                ray = cameraMain.CameraComponent.ScreenPointToRay(currentMousePosition);//���...�� �����

                if (Physics.Raycast(ray, out RaycastHit hitInfo))
                {
                    targetDirection = hitInfo.point - gameObject.transform.position;
                    targetRotation = Quaternion.LookRotation(targetDirection);
                    Debug.DrawRay(gameObject.transform.position, targetDirection, Color.blue);
                    gameObject.transform.rotation =
                        Quaternion.Lerp(gameObject.transform.rotation, targetRotation, Time.deltaTime * speedTurn);
                }
            }
        }
    }
    private void FixedUpdate()
    {
        if (NotActionClass) { return; }//�������� �����������

        if (turnSettings.IsUpDate)
        {
            GetSetting();
        }
        TurnMove();
    }

}
