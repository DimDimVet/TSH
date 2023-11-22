using Codice.Utils;
using System;
using UnityEngine;
using static EventManager;
using static PlasticGui.LaunchDiffParameters;

public class ScanEnemy : MonoBehaviour
{
    [SerializeField] private SphereCollider scanCollider;
    [SerializeField] private ScanEnemySettings scanEnemySettings;
    private bool NotActionClass = false;
    //кэш
    private float dimCollider, kfCollider;
    private int hashGetObject;
    private Construction objectGetScaner;
    private Construction[] players, enemys;

    private bool isRun = false;

    void Start()
    {
        int thisHash = this.gameObject.GetHashCode();
        Construction thisObject = GetObjectHash(thisHash);
        CreatEnemy(thisObject);

        if (scanEnemySettings == null) { print($"Не установлен Settings в {gameObject.name}"); NotActionClass = true; }
        if (NotActionClass) { return; }//Проверка разрешнения
        GetSetting();
        GetIsRun();
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
    private void OnTriggerEnter(Collider other)
    {
        hashGetObject = other.gameObject.GetHashCode();
        BuildScanObject(hashGetObject);
    }
    private void OnTriggerExit(Collider other)
    {
        hashGetObject = other.gameObject.GetHashCode();
        ReBuildScanObject(hashGetObject);
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

        if (players != null) { GetTargetPlayer(players, enemys); }
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
                if (enemys[i].Hash==0)
                {
                    enemys[i] = objectGetScaner;
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
    }
    private void CleanEnemy(Construction objectGetScaner)
    {
        if (enemys != null)
        {
            for (int i = 0; i < enemys.Length; i++)
            {
                if (enemys[i].Hash == objectGetScaner.Hash)
                {
                    enemys[i].Hash = 0;
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
                    players[i].Hash = 0;
                    return;
                }
            }
        }
    }
    private void EnemyScan()
    {
        if (isRun)
        {
            //print($"{gameObject.GetHashCode()} - {scanCollider.GetHashCode()}");
            //print($"{gameObject.GetHashCode()} - {scanCollider.GetHashCode()}");
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
        EnemyScan();
    }
}
