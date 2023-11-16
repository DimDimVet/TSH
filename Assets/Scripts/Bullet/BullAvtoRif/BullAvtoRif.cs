public class BullAvtoRif : Bullet
{
    public override void ReternBullet()
    {
        Pools.BullRif.ReternObject(gameObject);
    }
}
