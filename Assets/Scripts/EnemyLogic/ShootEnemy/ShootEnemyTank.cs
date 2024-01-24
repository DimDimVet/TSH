using UnityEngine;
using static EventBus;

public class ShootEnemyTank : Shoot
{
    public GameObject _BullEnemyTank; public Transform ContainerBullEnemyTank;
    public GameObject _BullEnemyTankSleeve; public Transform ContainerBullEnemyTankSleeve;
    public GameObject _BullDecal; public Transform ContainerBullDecal;
    private Pool bullEnemyTank;
    private Pool bullEnemyTankSleeve;
    private Pool bullDecal;

    public override void Set()
    {
        bullEnemyTank = new Pool(_BullEnemyTank, ContainerBullEnemyTank);
        bullEnemyTankSleeve = new Pool(_BullEnemyTankSleeve, ContainerBullEnemyTankSleeve);
        bullDecal = new Pool(_BullDecal, ContainerBullDecal);
        OnIsReternBull += ReternBullet;
    }
    private void ReternBullet(int hash,int hashObjectDamagAcceptance,int costTargetObject, bool isKillObjectAcceptance, int setDamage, RaycastHit hit)
    {
        bullDecal.ReternObject(hash);
        if (hit.collider != null)
        {
            if (bullEnemyTank.ReternObject(hash)) { bullDecal.GetObjectHit(hit); }
            if (bullEnemyTankSleeve.ReternObject(hash)) { bullDecal.GetObjectHit(hit); }
        }
        else
        {
            bullEnemyTank.ReternObject(hash);
            bullEnemyTankSleeve.ReternObject(hash);
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
        bullEnemyTank.GetObject();
        IsActivGunEnemyShoot(ThisHash, true);
    }
    public override void ShootBulletSleeve()
    {
        bullEnemyTankSleeve.GetObject();
    }
}
