public class BullEnemyAvtoSleeve : Bullet
{
    public override void ShootSleeve()
    {
        Pools.BullEnemyAvtoSleeve.ReternObject(gameObject);
    }
}
