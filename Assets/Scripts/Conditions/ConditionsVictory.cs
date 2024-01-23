using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static EventManager;

public class ConditionsVictory : MonoBehaviour
{
    private Construction thisObject;
    public bool test;

    private bool isVictory = false;
    private bool isRun = false;
    private void Start()
    {
        
    }
    private void OnEnable()
    {

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
            else { isRun = false; GetSet(); print($"Ќе установлены компоненты в {gameObject.name}"); }
        }
    }
    private void EventVictory()
    {
        isVictory = test;
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
