using System;
using UnityEngine;
using static EventManager;

public class ScanEnemy : MonoBehaviour
{
    [SerializeField] private SphereCollider scanCollider;
    [SerializeField] private ScanEnemySettings scanEnemySettings;
    private bool NotActionClass = false;
    //кэш
    private int thisHash;
    private Construction thisObject;
    private float dimCollider, kfCollider;
    private int hashGetObject;
    private Construction objectGetScaner;
    private Construction[] players, enemys;

    private bool isRun = false;

    void Start()
    {
        if (scanEnemySettings == null) { print($"Не установлен Settings в {gameObject.name}"); NotActionClass = true; }
        if (NotActionClass) { return; }//Проверка разрешнения
        GetSetting();
        GetIsRun();
        SetThisObject();
    }
    private void GetSetting()
    {
        dimCollider = scanEnemySettings.DimCollider;
        kfCollider = scanEnemySettings.KfCollider;
    }
    private void GetIsRun()
    {
        if (!isRun)//если общее разрешение на запуск false
        {
            if (scanCollider != null) { isRun = true; scanCollider.radius = dimCollider; }
            else { isRun = false; print($"Не установлен Collider в {gameObject.name}"); }
        }
    }
    private void SetThisObject()
    {
        thisHash = this.gameObject.GetHashCode();
        thisObject = GetObjectHash(thisHash);
        CreatEnemy(thisObject);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (isRun)
        {
            hashGetObject = other.gameObject.GetHashCode();
            BuildScanObject(hashGetObject);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (isRun)
        {
            //EventTarget();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (isRun)
        {
            hashGetObject = other.gameObject.GetHashCode();
            ReBuildScanObject(hashGetObject);
        }
    }
    private void BuildScanObject(int hashGetObject)
    {
        objectGetScaner = GetObjectHash(hashGetObject);
        if (objectGetScaner.HealtPlayer != null)
        {
            ProcessingPlayer(objectGetScaner);
        }
        if (objectGetScaner.HealtEnemy != null)
        {
            ProcessingEnemy(objectGetScaner);
        }
    }
    private void ReBuildScanObject(int hashGetObject)
    {
        objectGetScaner = GetObjectHash(hashGetObject);
        if (objectGetScaner.HealtPlayer != null)
        {
            CleanPlayer(objectGetScaner);
        }
        if (objectGetScaner.HealtEnemy != null)
        {
            CleanEnemy(objectGetScaner);
        }
    }
    private void EventTarget()
    {
        if (players != null) { GetTargetPlayer(players, enemys); }
    }
    private void ProcessingEnemy(Construction objectGetScaner)
    {
        if (enemys != null)
        {
            for (int i = 0; i < enemys.Length; i++)
            {
                if (enemys[i].Hash == objectGetScaner.Hash)
                {
                    return;
                }
            }
            CreatEnemy(objectGetScaner);
        }
        else { CreatEnemy(objectGetScaner); }
    }
    private void ProcessingPlayer(Construction objectGetScaner)
    {
        if (players != null)
        {
            for (int i = 0; i < players.Length; i++)
            {
                if (players[i].Hash == objectGetScaner.Hash)
                {
                    return;
                }
            }
            CreatPlayer(objectGetScaner);
        }
        else { CreatPlayer(objectGetScaner); }
    }
    private void CreatEnemy(Construction objectGetScaner)
    {
        if (enemys != null)
        {
            for (int i = 0; i < enemys.Length; i++)
            {
                if (enemys[i].Hash == 0)
                {
                    enemys[i] = objectGetScaner;
                    EventTarget();
                    return;
                }
            }

            int newLength = enemys.Length + 1;
            Array.Resize(ref enemys, newLength);
            enemys[newLength - 1] = objectGetScaner;
        }
        else
        {
            enemys = new Construction[] { objectGetScaner };
        }
        EventTarget();
    }
    private void CreatPlayer(Construction objectGetScaner)
    {
        if (players != null)
        {
            for (int i = 0; i < players.Length; i++)
            {
                if (players[i].Hash == 0)
                {
                    players[i] = objectGetScaner;
                    EventTarget();
                    return;
                }
            }

            int newLength = players.Length + 1;
            Array.Resize(ref players, newLength);
            players[newLength - 1] = objectGetScaner;
        }
        else
        {
            players = new Construction[] { objectGetScaner };
        }
        EventTarget();
    }
    private void CleanEnemy(Construction objectGetScaner)
    {
        if (enemys != null)
        {
            for (int i = 0; i < enemys.Length; i++)
            {
                if (enemys[i].Hash == objectGetScaner.Hash)
                {
                    Array.Clear(enemys, i, 1);
                    EventTarget();
                    return;
                }
            }
        }
    }
    private void CleanPlayer(Construction objectGetScaner)
    {
        if (players != null)
        {
            for (int i = 0; i < players.Length; i++)
            {
                if (players[i].Hash == objectGetScaner.Hash)
                {
                    Array.Clear(players, i, players.Length);
                    EventTarget();
                    return;
                }
            }
        }
    }
    private void FixedUpdate()
    {
        if (NotActionClass) { return; }//Проверка разрешнения

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
    }
}
