using static EventManager;

public class ShootEnemyTank : Shoot
{
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
        Pools.BullEnemyTank.GetObject();
        IsActivGunEnemyShoot(ThisHash, true);
    }
    public override void ShootBulletSleeve()
    {
        Pools.BullEnemyTankSleeve.GetObject();
    }
}
