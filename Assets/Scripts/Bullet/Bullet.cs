using System;
using UnityEngine;
using static EventManager;
using static UnityEditor.Experimental.GraphView.GraphView;

public class Bullet : MonoBehaviour
{
    //[SerializeField] private ParticleSystem particle;
    //[SerializeField] private TrailRenderer trailRender;
    [SerializeField] private BulletSettings bullSettings;
    [SerializeField] private bool typeSleeve = false;
    [SerializeField] private Rigidbody body;
    private bool NotActionClass = false;
    //кэш
    private float speedBullet;
    private float diametrCollider;
    private Collider[] hitColl;
    private Construction[] objectsGetScaner;
    private Construction hitObject;
    private Construction[] players, enemys;
    private int hashGetObject;
    private float killTime, defaultTime;
    private bool isBullKill = true, isShootTriger = true;
    private bool isRun = false;

    void Awake()
    {
        if (bullSettings == null) { print($"Не установлен {bullSettings.name} в Bullet"); NotActionClass = true; }
        if (NotActionClass) { return; }//Проверка разрешнения
        GetIsRun();
        GetSetting();
    }
    private void GetSetting()
    {
        speedBullet = bullSettings.SpeedBullet;
        killTime = bullSettings.KillTime;
        defaultTime = killTime;
        diametrCollider=bullSettings.DiametrCollider;
        bullSettings.IsUpDate = false;
    }
    private void GetIsRun()
    {
        if (!isRun)//если общее разрешение на запуск false
        {
            isRun = true;
            ///
        }
    }
    private void DetectObject()
    {
        hitColl = Physics.OverlapSphere(this.gameObject.transform.position, diametrCollider);
        ScanObject(hitColl);
    }
    private void ScanObject(Collider[] hitColl)
    {
        Clean(objectsGetScaner);
        for (int i = 0; i < hitColl.Length; i++)
        {
            hashGetObject = hitColl[i].gameObject.GetHashCode();
            hitObject = GetObjectHash(hashGetObject);
            if (hitObject.Hash != 0)
            {
                if (objectsGetScaner == null)
                {
                    objectsGetScaner = Creat(hitObject, objectsGetScaner);
                }
                else
                {
                    objectsGetScaner = Creat(hitObject, objectsGetScaner);
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
                Clean(enemys);
            }
        }
        if (players != null)
        {
            for (int y = 0; y < players.Length; y++)
            {
                Clean(players);
            }
        }
        //
        for (int i = 0; i < objects.Length; i++)
        {
            if (objects[i].HealtEnemy != null)
            {
                print($"Попадание {objects[i].Hash}");
                //enemys = Creat(objects[i], enemys);//
            }
            if (objects[i].HealtPlayer != null)
            {
                print($"Попадание {objects[i].Hash}");
                //players = Creat(objects[i], players);//
            }
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(this.gameObject.transform.position, diametrCollider);
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
    private bool ConnectObject()
    {

        return false;
    }
    private bool KillTimeBullet()
    {
        if (isBullKill)
        {
            killTime -= Time.deltaTime;
            if (killTime <= 0)
            {
                killTime = defaultTime; isBullKill = false; return true;
            }
            return false;
        }
        return false;
    }
    private void RunBullet()
    {
        if (isRun && !typeSleeve)
        {
            gameObject.transform.Translate(Vector3.forward * speedBullet * Time.deltaTime);

            isBullKill = true;
            if (KillTimeBullet())
            { ReternBullet(); }
            if (ConnectObject())
            {ReternBullet();}
        }
        else if (typeSleeve)
        {
            if (isShootTriger) { body.AddForce(body.position * speedBullet, ForceMode.Acceleration); }

            isShootTriger = false;
            isBullKill = true;
            if (KillTimeBullet())
            { isShootTriger = true; ShootSleeve(); }
        }
    }
    public virtual void ReternBullet()
    {
        //
    }
    public virtual void ShootSleeve()
    {
        //
    }
    private void FixedUpdate()
    {
        if (NotActionClass) { return; }//Проверка разрешнения

        if (bullSettings.IsUpDate)
        {
            GetSetting();
            bullSettings.IsUpDate = false;
        }
        if (!isRun)//если общее разрешение на запуск false
        {
            GetIsRun();
            return;
        }
        RunBullet();
    }
}
