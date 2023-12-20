using UnityEngine;
using static EventManager;

public class AnimControllerMoveEnemyTank : MonoBehaviour
{
    [SerializeField] private AnimControllerMoveEnemyTankSettings animSettings;
    //кэш
    private Animator animator;
    private float currentVelocity;
    private float speedAnim;
    private string tankEnemyTrackRight, tankEnemyTrackForward, tankEnemyTrackLeft, tankEnemyTrackBack;
    private Construction thisObject;
    private int thisHash;

    private bool isRun = false, isDead = false;
    void Start()
    {
        if (animSettings == null) { print($"Ќе установлен Settings в AnimControllerMoveEnemyTank");}
        GetIsRun();
        GetSetting();
    }
    private void OnEnable()
    {
        isDead = false;
        OnIsDead += StopRun;
    }
    private void OnDisable()
    {
        OnIsDead -= StopRun;
    }
    private void StopRun(int _thisHash, bool _isDead, int costObject)
    {
        if (thisHash == _thisHash) { isDead = _isDead; }
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

            thisHash = this.gameObject.GetHashCode();
            thisObject = GetObjectHash(thisHash);//получаем данные из листа
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
        if (isDead) { return; }

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
