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
        if (!isRun)//���� ����� ���������� �� ������ false
        {
            if (thisObject.Hash != 0) { isRun = true; }
            else { isRun = false; GetSet(); print($"�� ����������� ���������� � {gameObject.name}"); }
        }
    }
    private void EventVictory()
    {
        isVictory = test;
        if (isVictory) { IsVictory(thisObject.Hash, isVictory); }
    }
    private void FixedUpdate()
    {
        if (!isRun)//���� ����� ���������� �� ������ false
        {
            GetIsRun();
            return;
        }
        EventVictory();
    }
}
