using UnityEngine;
using static EventManager;

public class Bullet : MonoBehaviour
{
    //[SerializeField] private ParticleSystem particle;
    //[SerializeField] private GameObject decalGO;
    //[SerializeField] private TrailRenderer trailRender;
    [SerializeField] private BulletSettings bullSettings;
    [SerializeField] private bool typeSleeve = false;
    [SerializeField] private Rigidbody body;
    public float Damage { get { return damage; } }
    public float PercentDamage { get { return percentDamage; } }
    public RaycastHit Hit { get { return hit; } }
    //кэш
    private float speedBullet;
    private float diametrCollider;
    private Construction hitObject;
    private bool isHealt;
    private int hashGetObject;
    private float killTime, defaultTime;
    private float damage, percentDamage;

    private Vector3 startPos;
    private RaycastHit hit;

    private bool isBullKill = true, isShootTriger = true;
    private bool isRun = false;

    void Awake()
    {
        if (bullSettings == null) { print($"Не установлен {bullSettings.name} в Bullet"); }
        GetIsRun();
        GetSetting();
    }
    private void OnEnable()
    {
        startPos = transform.position;
        killTime = defaultTime;
    }
    private void GetSetting()
    {
        speedBullet = bullSettings.SpeedBullet;
        killTime = bullSettings.KillTime;
        defaultTime = killTime;
        diametrCollider = bullSettings.DiametrCollider;
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
        Gizmos.DrawWireSphere(this.gameObject.transform.position, diametrCollider);
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
            gameObject.transform.Translate(Vector3.forward * speedBullet * Time.deltaTime);
            isBullKill = true;
            if (KillTimeBullet())
            { ReternBullet(); }
            if (ConnectObject())
            { ReternBullet(); }
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
