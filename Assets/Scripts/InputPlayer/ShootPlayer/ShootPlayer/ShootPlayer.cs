public class ShootPlayer : Shoot
{
    public override void ShootBullet()
    {
        Pools.BullBB.GetObject();
    }
    public override void ShootBulletSleeve()
    {
        Pools.BullSleeve.GetObject();
    }
}
