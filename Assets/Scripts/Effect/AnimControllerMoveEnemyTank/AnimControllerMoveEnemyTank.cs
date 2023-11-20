using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using static EventManager;

public class AnimControllerMoveEnemyTank : MonoBehaviour
{
    [SerializeField] private AnimControllerMoveEnemyTankSettings animSettings;
    private bool NotActionClass = false;
    //кэш
    private Animator animator;
    private float speedAnim;
    private string tankEnemyTrackRight, tankEnemyTrackForward, tankEnemyTrackLeft, tankEnemyTrackBack;

    private NavMeshAgent navMeshAgent;
    private bool isRun = false;
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();    
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

            //int hash = this.gameObject.GetHashCode();
            //thisObject = GetObjectHash(hash);//получаем данные из листа
            //if (thisObject.LogicMoveEnemy != null) { isRun = true;}
            //else { isRun = false; print($"{gameObject.name} не получил LogicMoveEnemy"); }
        }
    }
    private void AnimAction()
    {
        if (isRun)
        {
            //print(navMeshAgent.velocity.magnitude);
            //print(navMeshAgent.remainingDistance);


            //rigidbodyEnemyTank.velocity

            ////кнопки и канвас
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
