public class BullBB : Bullet
{
    public override void ReternBullet()
    {
        Pools.BullBB.ReternObject(gameObject);
    }
}
