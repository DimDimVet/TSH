using static EventManager;

public class ShootEnemyAvto : Shoot
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
        Pools.BullEnemyAvto.GetObject();
        IsActivGunEnemyShoot(ThisHash, true);
    }
    public override void ShootBulletSleeve()
    {
        Pools.BullEnemyAvtoSleeve.GetObject();
    }
}
