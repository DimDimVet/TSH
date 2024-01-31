using UnityEngine;
using static EventBus;

public class ShootEnemyAvto : Shoot
{
    public GameObject _BullEnemyAvto; public Transform ContainerBullEnemyAvto;
    public GameObject _BullEnemyAvtoSleeve; public Transform ContainerBullEnemyAvtoSleeve;
    public GameObject _BullDecal; public Transform ContainerBullDecal;
    private Pool bullEnemyAvto;
    private Pool bullEnemyAvtoSleeve;
    private Pool bullDecal;
    public override void Set()
    {
        bullEnemyAvto = new Pool(_BullEnemyAvto, ContainerBullEnemyAvto);
        bullEnemyAvtoSleeve = new Pool(_BullEnemyAvtoSleeve, ContainerBullEnemyAvtoSleeve);
        bullDecal = new Pool(_BullDecal, ContainerBullDecal);
        OnIsReternBull += ReternBullet;
    }
    private void ReternBullet(int hash, int hashObjectDamagAcceptance, int costTargetObject, bool isKillObjectAcceptance, int setDamage, RaycastHit hit)
    {
        bullDecal.ReternObject(hash);
        if (hit.collider != null)
        {
            if (bullEnemyAvto.ReternObject(hash)) { bullDecal.GetObjectHit(hit); }
            bullEnemyAvtoSleeve.ReternObject(hash);
        }
        else
        {
            bullEnemyAvto.ReternObject(hash);
            bullEnemyAvtoSleeve.ReternObject(hash);
        }
    }
    private void OnEnable()
    {
        OnIsReadinessShoot += ReadinessShoot;
        IsDead = false;
        OnIsDead += StopRun;
    }
    private void OnDisable()
    {
        OnIsReadinessShoot -= ReadinessShoot;
        OnIsDead -= StopRun;
    }
    private void StopRun(int _thisHash, bool _isDead, int costObject)
    {
        if (ThisHash == _thisHash) { IsDead = _isDead; }
    }
    private void ReadinessShoot(int thisHash, bool isReadinessShoot)
    {
        if (ThisHash == thisHash) { IsScriptAction = isReadinessShoot; }
    }
    public override void ShootBullet()
    {
        bullEnemyAvto.GetObject();
        IsActivGunEnemyShoot(ThisHash, true);
    }
    public override void ShootBulletSleeve()
    {
        bullEnemyAvtoSleeve.GetObject();
    }
}
