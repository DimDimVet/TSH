using UnityEngine;
using static EventManager;

public class AnimControllerMoveEnemyTank : MonoBehaviour
{
    [SerializeField] private AnimControllerMoveEnemyTankSettings animSettings;
    private bool NotActionClass = false;
    //кэш
    private Animator animator;
    private float currentVelocity;
    private float speedAnim;
    private string tankEnemyTrackRight, tankEnemyTrackForward, tankEnemyTrackLeft, tankEnemyTrackBack;
    private Construction thisObject;

    private bool isRun = false;
    void Start()
    {
        if (animSettings == null) { print($"Не установлен Settings в AnimControllerMoveEnemyTank"); NotActionClass = true; }
        if (NotActionClass) { return; }//Проверка разрешнения
        GetIsRun();
        GetSetting();
    }
    private void GetSetting()
    {
        speedAnim = animSettings.SpeedAnim;
        tankEnemyTrackRight = animSettings.TankEnemyTrackRight;
        tankEnemyTrackLeft = animSettings.TankEnemyTrackLeft;
        tankEnemyTrackForward = animSettings.TankEnemyTrackForward;
        tankEnemyTrackBack = animSettings.TankEnemyTrackBack;
    }
    private void GetIsRun()
    {
        if (!isRun)//если общее разрешение на запуск false
        {
            animator = gameObject.GetComponent<Animator>();
            if (animator != null) { isRun = true; }
            else { isRun = false; print($"{gameObject.name} не получила Animator"); }

            int hash = this.gameObject.GetHashCode();
            thisObject = GetObjectHash(hash);//получаем данные из листа
            if (thisObject.NavMeshAgent != null) { isRun = true; }
            else { isRun = false; print($"{gameObject.name} не получил LogicMoveEnemy"); }
        }
    }
    private void AnimAction()
    {
        if (isRun)
        {
            currentVelocity = Mathf.Abs(thisObject.NavMeshAgent.velocity.magnitude);
            if (currentVelocity > 0.1f)
            {
                animator.SetFloat(tankEnemyTrackForward, 1);
            }
            else
            {
                animator.SetFloat(tankEnemyTrackForward, 0);
            }
        }
    }
    private void FixedUpdate()
    {
        if (NotActionClass) { return; }//Проверка разрешнения

        if (animSettings.IsUpDate)
        {
            GetSetting();
        }
        if (!isRun)//если общее разрешение на запуск false
        {
            GetIsRun();
            return;
        }
        AnimAction();
    }
}
