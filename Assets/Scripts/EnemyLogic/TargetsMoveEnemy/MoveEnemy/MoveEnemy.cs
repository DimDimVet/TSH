using UnityEngine;

public class MoveEnemy : TargetsMoveEnemy
{
    [SerializeField] private MoveEnemySettings moveEnemySettings;
    private bool NotActionClass = false;
    //кэш
    private float speedMove, speedAngle, acceleration, stopDistance;
    private int countTarget = 0, countTargetDefault = 0;
    private Vector3 currentTarget;
    private bool isTriger = true;
    private bool isRun = false;
    void Start()
    {
        if (moveEnemySettings == null) { print($"Не установлен Settings в {gameObject.name}"); NotActionClass = true; }
        if (NotActionClass) { return; }//Проверка разрешнения
        GetSetting();
        //GetIsRun();
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
        if (!isRun)//если общее разрешение на запуск false
        {
            if (ThisObject.NavMeshAgent != null) { isRun = true; SetNavComponent(); }
            else { isRun = false; SetTargetDefault(); }
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
        }
    }
    private void FixedUpdate()
    {
        if (IsDead) { ThisObject.NavMeshAgent.isStopped = true; return; }//Проверка разрешнения

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
