using System;
using UnityEngine;
using static EventBus;

public enum TypeBullet
{
    Sleeve,
    PlayerBull,
    PlayerRif,
    EnemyBull,
    EnemyRif
}
public class Bullet : MonoBehaviour
{
    [SerializeField] private BulletSettings bullSettings;
    [SerializeField] private bool typeSleeve = false;
    [SerializeField] private Rigidbody body;
    public float Damage { get { return damage; } }
    public float PercentDamage { get { return percentDamage; } }
    public RaycastHit Hit { get { return hit; } }
    //кэш
    private float speedBullet;
    private Construction hitObject;
    private bool isHealt;
    private int hashGetObject;
    private float killTime, defaultTime;
    private float damage, percentDamage;
    public TypeBullet TypeBullet { get { return typeBullet; } }
    private TypeBullet typeBullet;

    public int ControlHash { get { return contorlHash; } }
    private int contorlHash;
    private Vector3 startPos;
    private RaycastHit hit;

    private bool isBullKill = true, isShootTriger = true;
    private bool isRun = false;

    void Start()
    {
        if (bullSettings == null) { print($"Не установлен {bullSettings.name} в Bullet"); }
        //GetIsRun();
        GetSetting();
    }
    private void OnEnable()
    {
        startPos = transform.position;
        killTime = defaultTime;
        OnIsDead += IsDeadTargetObject;
        OnControlHashDamage += ControlHashTarget;
    }

    private void GetSetting()
    {
        typeBullet = bullSettings.TypeBullet;
        speedBullet = bullSettings.SpeedBullet;
        killTime = bullSettings.KillTime;
        defaultTime = killTime;
        isHealt = bullSettings.IsHealt;//true-триггер по HealtPlayer, false-триггер по HealtEnemy
        damage = bullSettings.Damage;
        percentDamage = bullSettings.PercentDamage;
        bullSettings.IsUpDate = false;
    }
    private void GetIsRun()
    {
        if (!isRun)//если общее разрешение на запуск false
        {
            isRun = true;
        }
    }

    private void ControlHashTarget(int _contorlHash)
    {
        contorlHash = _contorlHash;
    }
    public virtual void IsDeadTargetObject(int thisHash, bool isDead, int costObject)
    {
        //
    }
    private bool DetectObject()
    {
        if (Physics.Linecast(startPos, transform.position, out hit))
        {
            hashGetObject = hit.collider.gameObject.GetHashCode();
            hitObject = GetObjectHash(hashGetObject);

            if (hitObject.Hash == 0)
            {
                SetDamage(hitObject.Hash);
                return true;
            }
            else if (hitObject.HealtEnemy != null & isHealt == false)
            {
                SetDamage(hitObject.Hash);
                return true;
            }
            else if (hitObject.HealtPlayer != null & isHealt == true)
            {
                SetDamage(hitObject.Hash);
                return true;
            }
        }
        return false;
    }
    public virtual void SetDamage(int hash)
    {
        //
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(startPos, transform.position);
    }
    private bool ConnectObject()
    {
        return DetectObject();
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
            body.velocity = transform.forward * speedBullet;
            isBullKill = true;
            if (ConnectObject())
            { ReternBullet();}
            if (KillTimeBullet())
            { ReternBullet(); }
        }
        else if (typeSleeve)
        {
            if (isShootTriger) { body.AddForce(Vector3.up * speedBullet, ForceMode.Impulse); }

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
