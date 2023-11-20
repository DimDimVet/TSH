using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using static EventManager;

public class AnimControllerMoveEnemyTank : MonoBehaviour
{
    [SerializeField] private AnimControllerMoveEnemyTankSettings animSettings;
    private bool NotActionClass = false;
    //���
    private Animator animator;
    private float speedAnim;
    private string tankEnemyTrackRight, tankEnemyTrackForward, tankEnemyTrackLeft, tankEnemyTrackBack;

    private NavMeshAgent navMeshAgent;
    private bool isRun = false;
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();    
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

            //int hash = this.gameObject.GetHashCode();
            //thisObject = GetObjectHash(hash);//�������� ������ �� �����
            //if (thisObject.LogicMoveEnemy != null) { isRun = true;}
            //else { isRun = false; print($"{gameObject.name} �� ������� LogicMoveEnemy"); }
        }
    }
    private void AnimAction()
    {
        if (isRun)
        {
            //print(navMeshAgent.velocity.magnitude);
            //print(navMeshAgent.remainingDistance);


            //rigidbodyEnemyTank.velocity

            ////������ � ������
            //if (InputData.Move.y > 0)
            //{
            //    animator.SetFloat(tankPlayerTrackForward, speedAnim);
            //}
            //else
            //{
            //    animator.SetFloat(tankPlayerTrackForward, 0);
            //}
            //if (InputData.Move.y < 0)
            //{
            //    animator.SetFloat(tankPlayerTrackBack, speedAnim);
            //}
            //else
            //{
            //    animator.SetFloat(tankPlayerTrackBack, 0);
            //}

            //if (InputData.Move.x > 0)
            //{
            //    animator.SetFloat(tankPlayerTrackRight, speedAnim);
            //}
            //else
            //{
            //    animator.SetFloat(tankPlayerTrackRight, 0);
            //}
            //if (InputData.Move.x < 0)
            //{
            //    animator.SetFloat(tankPlayerTrackLeft, speedAnim);
            //}
            //else
            //{
            //    animator.SetFloat(tankPlayerTrackLeft, 0);
            //}
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
