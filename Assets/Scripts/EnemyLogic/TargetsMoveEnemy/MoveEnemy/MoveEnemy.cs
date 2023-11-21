using UnityEngine;
using static EventManager;
using static UnityEngine.GraphicsBuffer;

public class MoveEnemy : TargetsMoveEnemy
{
    [SerializeField] private MoveEnemySettings moveEnemySettings;
    private bool NotActionClass = false;
    //кэш
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
            thisObject = GetObjectHash(ThisHash);//получаем данные из листа
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
    private void EnemyMove(Transform currentTarget)
    {
        //thisObject.NavMeshAgent.destination = currentTarget.position;
        thisObject.NavMeshAgent.SetDestination(currentTarget.position);
    }
    private void CycleTarget()
    {
        if (isRun)
        {
            
            if (isTriger)
            {
                if (Targets == null) { return; }
                currentTarget = Targets[countTarget];
                EnemyMove(currentTarget);
                countTarget++;
                if (countTarget >= Targets.Length) { countTarget = 0; }
                isTriger = false;
            }

            float distanceToTarget = Vector3.Distance(this.gameObject.transform.position, currentTarget.position);
            if (distanceToTarget <= stopDistance)
            {
                isTriger = true;
            }


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
        CycleTarget();
    }
}
