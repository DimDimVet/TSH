using UnityEngine;
using UnityEngine.AI;
using static EventManager;

public class LogicMoveEnemy : MonoBehaviour
{
    public GameObject TempTarget;
    [SerializeField] private LogicMoveEnemySettings moveEnemySettings;
    private bool NotActionClass = false;
    //���
    private float agentVelocity;
    public float AgentVelocity { get { return agentVelocity; } }
    private float speedMove, speedAngle, acceleration, stopDistance;
    private Construction thisObject;
    private Vector3 tempPosition;
    private bool isTriger=true;
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
            int hash = this.gameObject.GetHashCode();
            thisObject = GetObjectHash(hash);//�������� ������ �� �����
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
    private void EnemyMove()
    {
        if (isRun)
        {
            {
                //tempPosition = TempTarget.transform.position+new Vector3(Random.value*15,0,Random.value*15);
                
                if (isTriger)
                {
                    thisObject.NavMeshAgent.stoppingDistance = 15;
                    
                    tempPosition = new Vector3(TempTarget.transform.position.x + (Random.value * 15), 0, TempTarget.transform.position.z + (Random.value * 15));
                    thisObject.NavMeshAgent.destination = tempPosition;
                    isTriger = false;
                }
                else
                {
                    if (Mathf.Abs(TempTarget.transform.position.magnitude- tempPosition.magnitude) >=30f && thisObject.NavMeshAgent.velocity.magnitude ==0)
                    {
                        isTriger = true;
                    }
                    else
                    {
                        //thisObject.NavMeshAgent.destination = tempPosition;
                    }
                }

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
        EnemyMove();
    }
}
