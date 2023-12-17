using static EventManager;
public class BullEnemyTankSleeve : Bullet
{
    public override void ShootSleeve()
    {
        IsReternBull(this.gameObject.GetHashCode(), Hit);
    }
}
