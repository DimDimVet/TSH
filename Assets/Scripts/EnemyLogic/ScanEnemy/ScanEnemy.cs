using System;
using UnityEngine;
using static EventManager;
using static UnityEditor.Experimental.GraphView.GraphView;

public class ScanEnemy : MonoBehaviour
{
    [SerializeField] private ScanEnemySettings scanEnemySettings;
    private bool NotActionClass = false;
    //кэш
    private int thisHash;
    private Construction thisObject;
    private float diametrCollider, kfCollider;
    private int hashGetObject;
    private Collider[] hitColl;
    //private int[] hashHitColl;
    private Construction[] objectsGetScaner;
    private Construction hitObject;
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
        diametrCollider = scanEnemySettings.DiametrCollider;
        kfCollider = scanEnemySettings.KfCollider;
    }
    private void GetIsRun()
    {
        if (!isRun)//если общее разрешение на запуск false
        {
            isRun = true;
            //if (scanCollider != null) { isRun = true; scanCollider.radius = diametrCollider; }
            //else { isRun = false; print($"Не установлен Collider в {gameObject.name}"); }
        }
    }
    private void SetThisObject()
    {
        thisHash = this.gameObject.GetHashCode();
        thisObject = GetObjectHash(thisHash);
        Creat(thisObject, enemys);
    }
    private void DetectObject()
    {
        hitColl = Physics.OverlapSphere(this.gameObject.transform.position, diametrCollider);

        for (int i = 0; i < hitColl.Length; i++)
        {
            hashGetObject = hitColl[i].gameObject.GetHashCode();
            ScanObject(hashGetObject, hitColl.Length);
        }
    }
    private void ScanObject(int hashGetObject, int countStop)
    {
        hitObject = GetObjectHash(hashGetObject);
        if (hitObject.Hash == 0) { return; }

        if (objectsGetScaner == null || objectsGetScaner.Length < countStop)
        {
            objectsGetScaner = Creat(hitObject, objectsGetScaner);
            return;
        }
        else if (objectsGetScaner.Length > countStop)
        {
            Clean(hitObject, objectsGetScaner);
            Creat(hitObject, objectsGetScaner);
            return;
        }
        else if (objectsGetScaner.Length == countStop)
        {
            SelectObject(objectsGetScaner, objectsGetScaner.Length);
            return;
        }
    }
    private void SelectObject(Construction[] objects, int countStop)
    {
        if (enemys != null)
        {
            for (int y = 0; y < enemys.Length; y++)
            {
                Clean(enemys[y], enemys);
            }
        }
        if (players != null)
        {
            for (int y = 0; y < players.Length; y++)
            {
                Clean(players[y], players);
            }
        }
        //
        for (int i = 0; i < objects.Length; i++)
        {
            if (objects[i].HealtEnemy != null)
            {
                enemys = Creat(objects[i], enemys);
                print($" enemys {enemys.Length}");
            }
            if (objects[i].HealtPlayer != null)
            {
                players = Creat(objects[i], players);
                print($"players {players.Length}");
            }
        }
        EventTarget();
    }
    private void Clean(Construction intObject, Construction[] massivObject)
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
        DetectObject();
    }
}
