using Processing.Masiv;
using System;
using UnityEngine;
using static EventManager;

public class ScanEnemy : MonoBehaviour
{
    [SerializeField] private ScanEnemySettings scanEnemySettings;
    //кэш
    private int thisHash;
    private Construction thisObject;
    private float diametrCollider, kfCollider;
    private int hashGetObject;
    private Collider[] hitColl;
    private int refLength;
    private Construction[] objectsGetScaner;
    private Construction hitObject;
    private Construction[] players, enemys;
    private Masiv<Construction> _masiv = new Masiv<Construction>();

    private bool isRun = false,isDead = false;

    void Start()
    {
        if (scanEnemySettings == null) { print($"Не установлен Settings в {gameObject.name}"); }
        GetSetting();
        GetIsRun();
        SetThisObject();
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
        diametrCollider = scanEnemySettings.DiametrCollider;
        kfCollider = scanEnemySettings.KfCollider;
    }
    private void GetIsRun()
    {
        if (!isRun)//если общее разрешение на запуск false
        {
            if (scanEnemySettings != null) { isRun = true;  }
            else { isRun = false; print($"Не установлен scanEnemySettings в {gameObject.name}"); }
        }
    }
    private void SetThisObject()
    {
        thisHash = this.gameObject.GetHashCode();
        thisObject = GetObjectHash(thisHash);
        _masiv.Creat(thisObject, enemys);
    }

    private void DetectObject()
    {
        hitColl = Physics.OverlapSphere(this.gameObject.transform.position, diametrCollider);
        if (refLength == hitColl.Length) { return; }
        ScanObject(hitColl);
        refLength = hitColl.Length;
    }
    private void ScanObject(Collider[] hitColl)
    {
        _masiv.Clean(objectsGetScaner);
        for (int i = 0; i < hitColl.Length; i++)
        {
            hashGetObject = hitColl[i].gameObject.GetHashCode();
            hitObject = GetObjectHash(hashGetObject);

            if (hitObject.Hash != 0 & (hitObject.HealtEnemy || hitObject.HealtPlayer))
            {
                if (objectsGetScaner == null)
                {
                    objectsGetScaner = _masiv.Creat(hitObject, objectsGetScaner);
                }
                else
                {
                    objectsGetScaner = _masiv.Creat(hitObject, objectsGetScaner);
                }
            }
        }

        SelectObject(objectsGetScaner);
    }
    private void SelectObject(Construction[] objects)
    {
        if (enemys != null)
        {
            for (int y = 0; y < enemys.Length; y++)
            {
                _masiv.Clean(enemys);
            }
        }
        if (players != null)
        {
            for (int y = 0; y < players.Length; y++)
            {
                _masiv.Clean(players);
            }
        }
        //
        for (int i = 0; i < objects.Length; i++)
        {
            if (objects[i].HealtEnemy != null)
            {
                enemys = _masiv.Creat(objects[i], enemys);
            }
            if (objects[i].HealtPlayer != null)
            {
                players = _masiv.Creat(objects[i], players);
            }
        }
        EventTarget();
    }
    //private void Clean(Construction[] massivObject)
    //{
    //    if (massivObject != null)
    //    {
    //        Array.Clear(massivObject, 0, massivObject.Length);
    //        return;
    //    }
    //}
    //private Construction[] Creat(Construction intObject, Construction[] massivObject)
    //{
    //    bool isStop = false;
    //    if (massivObject != null)
    //    {
    //        for (int i = 0; i < massivObject.Length; i++)
    //        {
    //            if (!isStop)
    //            {
    //                if (massivObject[i].Hash == 0)
    //                {
    //                    massivObject[i] = intObject;
    //                    isStop = true;
    //                }
    //            }
    //        }
    //        if (!isStop)
    //        {
    //            int newLength = massivObject.Length + 1;
    //            Array.Resize(ref massivObject, newLength);
    //            massivObject[newLength - 1] = intObject;
    //            return massivObject;
    //        }
    //    }
    //    else
    //    {
    //        massivObject = new Construction[] { intObject };
    //        return massivObject;
    //    }
    //    return massivObject;
    //}
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(this.gameObject.transform.position, diametrCollider);
    }
    private void EventTarget()
    {
        if (players != null) { GetTargetPlayer(players, enemys); }
    }
    private void FixedUpdate()
    {
        if (isDead) { return; }
        if (scanEnemySettings.IsUpDate)
        {
            GetSetting();
            scanEnemySettings.IsUpDate = false;
        }
        if (!isRun)//если общее разрешение на запуск false
        {
            GetIsRun();
            return;
        }
        DetectObject();
    }
}
