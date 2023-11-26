public class BullEnemyTank : Bullet
{
    public override void ReternBullet()
    {
        Pools.BullEnemyTank.ReternObject(gameObject);
    }
}
