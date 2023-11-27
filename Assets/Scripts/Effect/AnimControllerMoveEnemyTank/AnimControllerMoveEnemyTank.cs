using UnityEngine;
using static EventManager;

public class AnimControllerMoveEnemyTank : MonoBehaviour
{
    [SerializeField] private AnimControllerMoveEnemyTankSettings animSettings;
    private bool NotActionClass = false;
    //���
    private Animator animator;
    private float currentVelocity;
    private float speedAnim;
    private string tankEnemyTrackRight, tankEnemyTrackForward, tankEnemyTrackLeft, tankEnemyTrackBack;
    private Construction thisObject;

    private bool isRun = false;
    void Start()
    {
        if (animSettings == null) { print($"�� ���������� Settings � AnimControllerMoveEnemyTank"); NotActionClass = true; }
        if (NotActionClass) { return; }//�������� �����������
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
        if (!isRun)//���� ����� ���������� �� ������ false
        {
            animator = gameObject.GetComponent<Animator>();
            if (animator != null) { isRun = true; }
            else { isRun = false; print($"{gameObject.name} �� �������� Animator"); }

            int hash = this.gameObject.GetHashCode();
            thisObject = GetObjectHash(hash);//�������� ������ �� �����
            if (thisObject.NavMeshAgent != null) { isRun = true; }
            else { isRun = false; print($"{gameObject.name} �� ������� LogicMoveEnemy"); }
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
        if (NotActionClass) { return; }//�������� �����������

        if (animSettings.IsUpDate)
        {
            GetSetting();
        }
        if (!isRun)//���� ����� ���������� �� ������ false
        {
            GetIsRun();
            return;
        }
        AnimAction();
    }
}
