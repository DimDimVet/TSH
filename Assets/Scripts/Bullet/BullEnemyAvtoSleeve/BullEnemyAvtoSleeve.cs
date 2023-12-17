using static EventManager;
public class BullEnemyAvtoSleeve : Bullet
{
    public override void ShootSleeve()
    {
        IsReternBull(this.gameObject.GetHashCode(), Hit);
    }
}
