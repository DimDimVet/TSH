public class BullSleeveAvtoRif : Bullet
{
    public override void ShootSleeve()
    {
        Pools.BullRifSleeve.ReternObject(gameObject);
    }
}
