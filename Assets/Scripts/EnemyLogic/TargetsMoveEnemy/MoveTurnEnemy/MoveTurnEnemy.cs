using UnityEngine;
using static EventManager;

public class MoveTurnEnemy : TargetRotateEnemy
{
    [SerializeField] private TurnSettings turnSettings;
    private bool NotActionClass = false;
    //���
    private Vector3 targetDirection;
    private Quaternion targetRotation;
    private float speedTurn;
    private bool isRun = false;
    void Start()
    {
        if (turnSettings == null) { print($"�� ���������� Settings � {gameObject.name}"); NotActionClass = true; }
        if (NotActionClass) { return; }//�������� �����������
        GetSetting();
        GetIsRun();
        SetTargetDefault();
    }
    private void GetSetting()
    {
        speedTurn = turnSettings.SpeedTurn;
    }
    private void GetIsRun()
    {
        if (!isRun)//���� ����� ���������� �� ������ false
        {
            if (ThisObject.NavMeshAgent != null) { isRun = true; }
            else { isRun = false; SetTargetDefault(); print($"{gameObject.name} �� ������� NavMeshAgent"); }
        }
    }
    private void DefaultPosition()
    {
        this.gameObject.transform.rotation =
            Quaternion.Lerp(gameObject.transform.rotation, DefaultTransform.rotation, Time.deltaTime * speedTurn);
        IsReadinessShoot(ThisHash,false);
    }
    private void StepTarget()
    {
        if (Target == null) { DefaultPosition(); return; }
        targetDirection = Target.position - gameObject.transform.position;
        targetRotation = Quaternion.LookRotation(targetDirection);
        targetRotation.x = 0;
        targetRotation.z = 0;
        this.gameObject.transform.rotation =
            Quaternion.Lerp(gameObject.transform.rotation, targetRotation, Time.deltaTime * speedTurn);
        IsReadinessShoot(ThisHash, true);
    }
    private void CycleTarget()
    {
        if (isRun)
        {
            StepTarget();
        }
    }
    private void FixedUpdate()
    {
        if (NotActionClass) { return; }//�������� �����������

        if (turnSettings.IsUpDate)
        {
            GetSetting();
            turnSettings.IsUpDate = false;
        }
        if (!isRun)//���� ����� ���������� �� ������ false
        {
            GetIsRun();
            return;
        }
        CycleTarget();
    }
}
