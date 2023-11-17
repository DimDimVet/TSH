using UnityEngine;
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

                thisObject.NavMeshAgent.destination = TempTarget.transform.position;
                //if dead
                //    agent.enabled = false;
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
