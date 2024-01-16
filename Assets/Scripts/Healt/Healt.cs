using Processing.Masiv;
using System.Collections.Generic;
using UnityEngine;
using static EventManager;

public abstract class Healt : MonoBehaviour
{
    [SerializeField] private HealtSetting settingsHealt;
    public int HealtCount { get { return healtCount; } set { healtCount = value; } }
    public bool IsDead { get { return isDead; } set { isDead = value; } }
    private int thisHash;
    public int ThisHash { get { return thisHash; } }
    private int costObject;
    [SerializeField] private int healtCount = 0, defaultHealtCount;
    private Construction thisObject;
    private Construction[] thisObjects;
    private Masiv<Construction> _masiv = new Masiv<Construction>();

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
        SetEventsEnable();
    }
    private void OnDisable()
    {
        OnGetDamage -= ControlDamage;
        SetEventsDisable();
    }
    public virtual void SetEventsEnable()
    {
        //
    }
    public virtual void SetEventsDisable()
    {
        //
    }
    private void GetSetting()
    {
        healtCount = settingsHealt.HealtCount;
        defaultHealtCount = healtCount;
        costObject = settingsHealt.CostObject;
    }
    private void GetIsRun()
    {
        if (!isRun)//���� ����� ���������� �� ������ false
        {
            thisObject = GetObjectHash(thisHash);
            if (settingsHealt != null & thisObject.Hash != 0) { isRun = true; }
            else { isRun = false; print($"�� ����������� ���������� � {gameObject.name}"); }
        }
    }
    public int ControlDamage(int getHash, int damage)//��������
    {
        if (isDead) { return 0; }
        if (thisObjects == null) { thisObjects = SetChildrensObject(); }

        for (int i = 0; i < thisObjects.Length; i++)
        {
            if (thisObjects[i].Hash == getHash || thisObjects[i].ParentHashObject == getHash)
            {
                print("���������");
                healtCount -= damage;
                GetUIDamage(thisHash, healtCount);
                if (healtCount <= 0) { isDead = true; IsDead(thisHash, isDead, costObject); return thisHash; }
                if (healtCount >= defaultHealtCount) { healtCount= defaultHealtCount; return thisHash; }
            }
        }
        return 0;
    }
    private Construction[] SetChildrensObject()
    {
        Construction[] tempObject = new Construction[0];
        _masiv.Clean(tempObject);

        List<Construction> tempList = GetList();
        for (int i = 0; i < tempList.Count; i++)
        {
            if (tempList[i].ParentHashObject == thisObject.Hash)
            {
                tempObject = _masiv.Creat(tempList[i], tempObject);
            }
        }
        return tempObject;
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
