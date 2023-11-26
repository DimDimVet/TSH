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
        if (Target.magnitude == 0) { DefaultPosition(); return; }
        targetDirection = Target - gameObject.transform.position;
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

            {
                //�������� � ����
                //target = HealtComponent.transform.position;//Player ������� � ����
                //currentPosition = this.gameObject.transform.position;//�������� ������� ������� Gun
                //distanceVector = target - currentPosition;//�������� ������ ����� Gun-target
                //rezulAxisY = Mathf.Atan2(distanceVector.x, distanceVector.z) * Mathf.Rad2Deg * polyrAngle;//�������� ���� ������� � ��������
                //this.gameObject.transform.rotation = Quaternion.Euler(0, (rezulAxisY + correctivAngle), 0);//�������� Gun angleX
            }

            {
                //�������� �������� ������� � ������ ��������
                //currentVelocity = Mathf.Abs(agent.velocity.magnitude);
                //if (currentVelocity > 0.1f)
                //{
                //    animator.SetFloat("SpeedEnemy", 1);
                //}
                //else
                //{
                //    animator.SetFloat("SpeedEnemy", 0);
                //}
            }
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
