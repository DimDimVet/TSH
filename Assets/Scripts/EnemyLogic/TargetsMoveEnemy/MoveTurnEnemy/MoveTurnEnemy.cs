using UnityEngine;
using static EventBus;

public class MoveTurnEnemy : TargetRotateEnemy
{
    [SerializeField] private TurnSettings turnSettings;
    //кэш
    private Vector3 targetDirection;
    private Quaternion targetRotation;
    private float speedTurn, maxOffSetX;
    private bool isRun = false;
    void Start()
    {
        GetSetting();
        GetIsRun();
        SetTargetDefault();
    }
    private void GetSetting()
    {
        speedTurn = turnSettings.SpeedTurn;
        maxOffSetX= turnSettings.MaxOffSetX;
    }
    private void GetIsRun()
    {
        if (!isRun)//если общее разрешение на запуск false
        {
            if (ThisObject.NavMeshAgent != null) { isRun = true; }
            else { isRun = false; SetTargetDefault(); print($"{gameObject.name} не получил NavMeshAgent"); }
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
        if (targetRotation.x> maxOffSetX){targetRotation.x = maxOffSetX;}
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
        if (IsDead) { return; }

        if (turnSettings.IsUpDate)
        {
            GetSetting();
            turnSettings.IsUpDate = false;
        }
        if (!isRun)//если общее разрешение на запуск false
        {
            GetIsRun();
            return;
        }
        CycleTarget();
    }
}
