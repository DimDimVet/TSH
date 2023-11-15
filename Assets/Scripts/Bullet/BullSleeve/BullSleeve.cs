public class BullSleeve : Bullet
{
    public override void ShootSleeve()
    {
        Pools.BullSleeve.ReternObject(gameObject);
    }
}
