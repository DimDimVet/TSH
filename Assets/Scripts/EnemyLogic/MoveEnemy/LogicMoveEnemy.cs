using UnityEngine;
using static EventManager;

public class LogicMoveEnemy : MonoBehaviour
{
    public GameObject TempTarget;
    [SerializeField] private LogicMoveEnemySettings moveEnemySettings;
    private bool NotActionClass = false;
    //кэш
    private float agentVelocity;
    public float AgentVelocity { get { return agentVelocity; } }
    private float speedMove, speedAngle, acceleration, stopDistance;
    private Construction thisObject;
    private bool isRun = false;
    void Start()
    {
        if (moveEnemySettings == null) { print($"Ќе установлен Settings в {gameObject.name}"); NotActionClass = true; }
        if (NotActionClass) { return; }//ѕроверка разрешнени€
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
        if (!isRun)//если общее разрешение на запуск false
        {
            int hash = this.gameObject.GetHashCode();
            thisObject = GetObjectHash(hash);//получаем данные из листа
            if (thisObject.NavMeshAgent != null) { isRun = true; SetNavComponent(); }
            else { isRun = false; print($"{gameObject.name} не получил NavMeshAgent"); }
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
                //–азворот к цели
                //target = HealtComponent.transform.position;//Player запишем в цель
                //currentPosition = this.gameObject.transform.position;//проверим текущию позицию Gun
                //distanceVector = target - currentPosition;//вычислим вектор между Gun-target
                //rezulAxisY = Mathf.Atan2(distanceVector.x, distanceVector.z) * Mathf.Rad2Deg * polyrAngle;//вычислим угол вектора в градусах
                //this.gameObject.transform.rotation = Quaternion.Euler(0, (rezulAxisY + correctivAngle), 0);//повернем Gun angleX
            }

            {
                //контроль движени€ объекта и запуск анимации
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
        if (NotActionClass) { return; }//ѕроверка разрешнени€

        if (moveEnemySettings.IsUpDate)
        {
            GetSetting();
            moveEnemySettings.IsUpDate = false;
        }
        if (!isRun)//если общее разрешение на запуск false
        {
            GetIsRun();
            return;
        }
        EnemyMove();
    }
}
