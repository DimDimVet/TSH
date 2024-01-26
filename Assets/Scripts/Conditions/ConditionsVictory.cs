using UnityEngine;
using static EventBus;

public class ConditionsVictory : MonoBehaviour
{
    private Construction thisObject;
    private bool isVictory = false;
    private bool isRun = false;
    private void OnEnable()
    {
        OnUICountEnemys += GetEnemys;
    }
    private void GetSet()
    {
        thisObject = GetPlayer();
    }
    private void GetIsRun()
    {
        if (!isRun)//если общее разрешение на запуск false
        {
            if (thisObject.Hash != 0) { isRun = true; }
            else { isRun = false; GetSet(); }
        }
    }
    private void GetEnemys(int enemys)
    {
        if (enemys == 0) { isVictory = true; }
    }
    private void EventVictory()
    {
        if (isVictory) { IsVictory(thisObject.Hash, isVictory); }
    }
    private void FixedUpdate()
    {
        if (!isRun)//если общее разрешение на запуск false
        {
            GetIsRun();
            return;
        }
        EventVictory();
    }
}
