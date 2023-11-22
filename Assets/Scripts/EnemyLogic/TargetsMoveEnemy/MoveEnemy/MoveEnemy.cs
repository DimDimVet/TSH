using UnityEngine;
using static EventManager;
using static UnityEngine.GraphicsBuffer;

public class MoveEnemy : TargetsMoveEnemy
{
    [SerializeField] private MoveEnemySettings moveEnemySettings;
    private bool NotActionClass = false;
    //���
    private float speedMove, speedAngle, acceleration, stopDistance;
    private int countTarget=0;
    private Transform currentTarget;
    private Construction thisObject;

    private float agentVelocity;
    public float AgentVelocity { get { return agentVelocity; } }
    
    
    private Vector3 tempPosition;
    private bool isTriger = true,gg;
    private bool isRun = false;


    void Start()
    {
        if (moveEnemySettings == null) { print($"�� ���������� Settings � {gameObject.name}"); NotActionClass = true; }
        if (NotActionClass) { return; }//�������� �����������
        GetSetting();
        GetIsRun();
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
            thisObject = GetObjectHash(ThisHash);//�������� ������ �� �����
            if (thisObject.NavMeshAgent != null) { isRun = true; SetNavComponent(); }
            else { isRun = false; print($"{gameObject.name} �� ������� NavMeshAgent"); }
        }
    }
    private void SetNavComponent()
    {
        thisObject.NavMeshAgent.speed = speedMove;
        thisObject.NavMeshAgent.angularSpeed = speedAngle;
        thisObject.NavMeshAgent.acceleration = acceleration;
        thisObject.NavMeshAgent.stoppingDistance = stopDistance;
    }
    private void EnemyMove(Transform _currentTarget)
    {
        isTriger = false;
        Transform target = _currentTarget;
        //thisObject.NavMeshAgent.destination = currentTarget.position;
        var tt=thisObject.NavMeshAgent.SetDestination(target.position);
        
        float distanceToTarget = Vector3.Distance(this.gameObject.transform.position, target.position);
        //print($"{distanceToTarget} {tt}");
        //if (distanceToTarget <= stopDistance)
        //{
        //    isTriger = true;
        //}
    }
    private void StepTarget()
    {
        if (Targets == null) { isTriger = true; return; }
        currentTarget = Targets[countTarget];
        EnemyMove(currentTarget);
        countTarget++;
    }
    private void CycleTarget()
    {
        if (isRun)
        {
            if (isTriger)
            {
                StepTarget();
                //if (countTarget >= Targets.Length) { countTarget = 0; }
            }
            //print($"{currentTarget.position} {Targets[countTarget].position}");
            


            {
                //if (isTriger)
                //{
                //    thisObject.NavMeshAgent.stoppingDistance = 15;

                //    tempPosition = new Vector3(TempTarget.transform.position.x + (UnityEngine.Random.value * 15), 0, TempTarget.transform.position.z + (UnityEngine.Random.value * 15));
                    
                //    isTriger = false;
                //}
                //else
                //{
                //    if (Mathf.Abs(TempTarget.transform.position.magnitude - tempPosition.magnitude) >= 30f && thisObject.NavMeshAgent.velocity.magnitude == 0)
                //    {
                //        isTriger = true;
                //    }
                //    else
                //    {
                //        //thisObject.NavMeshAgent.destination = tempPosition;
                //    }
                //}

                //print($"{thisObject.NavMeshAgent.remainingDistance} " +
                //    $"{tempPosition.magnitude} {TempTarget.transform.position.magnitude}");

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
