using Processing.Masiv;
using UnityEngine;
using static EventBus;

public class ScanEnemy : MonoBehaviour
{
    [SerializeField] private ScanEnemySettings scanEnemySettings;
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

    private bool isRun = false, isDead = false;

    void Start()
    {
        if (scanEnemySettings == null) { print($"Не установлен Settings в {gameObject.name}"); }
        GetSetting();
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
        if (!isRun)
        {
            if (scanEnemySettings != null) { isRun = true; }
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
        if (refLength == hitColl.Length ) { return; }
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
        if (!isRun)
        {
            GetIsRun();
            return;
        }
        DetectObject();
    }
}
