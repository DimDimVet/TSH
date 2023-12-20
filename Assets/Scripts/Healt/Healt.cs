using System;
using System.Collections.Generic;
using UnityEngine;
using static EventManager;

public abstract class Healt : MonoBehaviour
{
    [SerializeField] private HealtSetting settingsHealt;
    public int HealtCount { get { return healtCount; } /*set { healtCount = value; }*/ }
    public bool IsDead { get { return isDead; } set { isDead = value; } }
    private int thisHash;
    private int costObject;
    [SerializeField] private int healtCount = 0;
    private Construction thisObject;

    private Construction[] thisObjects;

    private bool isRun = false, isDead = false;
    private void Start()
    {
        thisHash = gameObject.GetHashCode();
        GetSetting();
    }
    private void OnEnable()
    {
        OnGetDamage += ControlDamage;
        isDead = false;
    }
    private void OnDisable()
    {
        OnGetDamage -= ControlDamage;
    }
    private void GetSetting()
    {
        healtCount = settingsHealt.HealtCount;
        costObject = settingsHealt.CostObject;
    }
    private void GetIsRun()
    {
        if (!isRun)//���� ����� ���������� �� ������ false
        {
            thisObject = GetObjectHash(thisHash);
            if (settingsHealt != null & thisObject.Hash!=0) { isRun = true; }
            else { isRun = false; print($"�� ����������� ���������� � {gameObject.name}"); }
        }
    }
    public void ControlDamage(int getHash, int damage)
    {
        if (isDead ) { return; }

        if (thisObjects == null) { thisObjects= SetChildrensObject(); }

        for (int i = 0; i < thisObjects.Length; i++)
        {
            if (thisObjects[i].Hash == getHash || thisObjects[i].ParentHashObject == getHash)
            {
                if (healtCount <= 0) { isDead = true; IsDead(thisHash, isDead, costObject); return; }
                else { healtCount -= damage; }
                GetUIDamage(thisHash, healtCount);
            }
        }
    }
    private Construction[] SetChildrensObject()
    {
        Construction[] tempObject=new Construction[0];
        Clean(tempObject);

        List<Construction> tempList = GetList();
        for (int i = 0; i < tempList.Count; i++)
        {
            if (tempList[i].ParentHashObject == thisObject.Hash)
            {
                tempObject = Creat(tempList[i], tempObject);
            }
        }
        return tempObject;
        ////
        //for (int i = 0; i < thisObjects.Length; i++) { print($"{ThisHash}->{thisObjects[i].Hash}"); }
    }
    private void Clean(Construction[] massivObject)
    {
        if (massivObject != null)
        {
            Array.Clear(massivObject, 0, massivObject.Length);
            return;
        }
    }
    private Construction[] Creat(Construction intObject, Construction[] massivObject)
    {
        bool isStop = false;
        if (massivObject != null)
        {
            for (int i = 0; i < massivObject.Length; i++)
            {
                if (!isStop)
                {
                    if (massivObject[i].Hash == 0)
                    {
                        massivObject[i] = intObject;
                        isStop = true;
                    }
                }
            }
            if (!isStop)
            {
                int newLength = massivObject.Length + 1;
                Array.Resize(ref massivObject, newLength);
                massivObject[newLength - 1] = intObject;
                return massivObject;
            }
        }
        else
        {
            massivObject = new Construction[] { intObject };
            return massivObject;
        }
        return massivObject;
    }
    void Update()
    {
        if (isDead) { return; }
        if (!isRun)//���� ����� ���������� �� ������ false
        {
            GetIsRun();
            return;
        }
    }
}
