using UnityEngine;

public class MoveEnemy : TargetsMoveEnemy
{
    [SerializeField] private MoveEnemySettings moveEnemySettings;
    private bool NotActionClass = false;
    //���
    private float speedMove, speedAngle, acceleration, stopDistance;
    private int countTarget = 0, countTargetDefault = 0;
    private Vector3 currentTarget;
    private bool isTriger = true;
    private bool isRun = false;
    void Start()
    {
        if (moveEnemySettings == null) { print($"�� ���������� Settings � {gameObject.name}"); NotActionClass = true; }
        if (NotActionClass) { return; }//�������� �����������
        GetSetting();
        GetIsRun();
        SetTargetDefault();
    }
    private void GetSetting()
    {
        speedMove = moveEnemySettings.SpeedMove;
        speedAngle = moveEnemySettings.SpeedAngle;
        acceleration = moveEnemySettings.Acceleration;
        stopDistance = moveEnemySettings.StopDistance;
    }
    private void GetIsRun()
    {
        if (!isRun)//���� ����� ���������� �� ������ false
        {
            if (ThisObject.NavMeshAgent != null) { isRun = true; SetNavComponent(); }
            else { isRun = false; SetTargetDefault(); print($"{gameObject.name} �� ������� NavMeshAgent"); }
        }
    }
    private void SetNavComponent()
    {
        ThisObject.NavMeshAgent.speed = speedMove;
        ThisObject.NavMeshAgent.angularSpeed = speedAngle;
        ThisObject.NavMeshAgent.acceleration = acceleration;
        ThisObject.NavMeshAgent.stoppingDistance = stopDistance;
    }
    private void EnemyMove(Vector3 _currentTarget)
    {
        ThisObject.NavMeshAgent.SetDestination(_currentTarget);
    }
    private void DefaultPosition()
    {
        if (DefaultPositionsVector == null) { isTriger = true; return; }
        if (countTargetDefault < DefaultPositionsVector.Length)
        {
            EnemyMove(DefaultPositionsVector[countTargetDefault]);
            countTargetDefault++;
        }
        else { countTargetDefault = 0; }
    }
    private void StepTarget()
    {
        if (Targets == null) { DefaultPosition(); return; }
        if (countTarget < Targets.Length)
        {
            currentTarget = Targets[countTarget];
            if (currentTarget.magnitude != 0) { EnemyMove(currentTarget); }
            else { DefaultPosition(); }
            countTarget++;
        }
        else
        {
            countTarget = 0;
        }
    }
    private void CycleTarget()
    {
        if (isRun)
        {
            if (isTriger)
            {
                StepTarget();
                isTriger = false;
            }
            else
            {
                if (ThisObject.NavMeshAgent.velocity.magnitude <= 0.1f) { isTriger = true; }
            }

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

        if (moveEnemySettings.IsUpDate)
        {
            GetSetting();
            moveEnemySettings.IsUpDate = false;
        }
        if (!isRun)//���� ����� ���������� �� ������ false
        {
            GetIsRun();
            return;
        }
        CycleTarget();
    }
}
