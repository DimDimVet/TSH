using UnityEngine;
using static EventBus;

public class CountEnemy : MonoBehaviour
{
    private Construction[] enemys;
    private int countEnemys;

    private bool isRun = false;
    private void OnEnable()
    {
        OnIsDead += DeadEnemys;
    }
    private void OnDisable()
    {
        OnIsDead -= DeadEnemys;
    }
    void Start()
    {
        GetSetting();
    }
    private void GetSetting()
    {
    }
    private void GetIsRun()
    {
        if (!isRun)
        {
            enemys = GetEnemys();
            if (enemys != null)
            {
                isRun = true;
                countEnemys = enemys.Length;
                UICountEnemys(countEnemys);
            }
        }
    }
    private void DeadEnemys(int thisHash, bool isDead, int costObject)
    {
        for (int i = 0; i < enemys.Length; i++)
        {
            if (enemys[i].Hash == thisHash)
            {
                ControlEnemys();
            }
        }
    }
    private void ControlEnemys()
    {
        countEnemys--;
        UICountEnemys(countEnemys);
    }

    private void FixedUpdate()
    {
        if (!isRun)
        {
            GetIsRun();
        }
    }
}
