public class BullEnemyAvto : Bullet
{
    public override void ReternBullet()
    {
        Pools.BullEnemyAvto.ReternObject(gameObject);
    }
}
