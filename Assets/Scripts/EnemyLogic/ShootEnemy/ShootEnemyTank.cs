using UnityEngine;
using static EventManager;

public class ShootEnemyTank : Shoot
{
    public GameObject _BullEnemyTank; public Transform ContainerBullEnemyTank;
    public GameObject _BullEnemyTankSleeve; public Transform ContainerBullEnemyTankSleeve;
    private Pool bullEnemyTank;
    private Pool bullEnemyTankSleeve;

    public override void Set()
    {
        bullEnemyTank = new Pool(_BullEnemyTank, ContainerBullEnemyTank);
        bullEnemyTankSleeve = new Pool(_BullEnemyTankSleeve, ContainerBullEnemyTankSleeve);
        OnIsReternBull += ReternBullet;
    }
    private void ReternBullet(int hash)
    {
        bullEnemyTank.ReternObject(hash);
        bullEnemyTankSleeve.ReternObject(hash);
    }
    private void OnEnable()
    {
        OnIsReadinessShoot += ReadinessShoot;
    }
    private void OnDisable()
    {
        OnIsReadinessShoot -= ReadinessShoot;
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
