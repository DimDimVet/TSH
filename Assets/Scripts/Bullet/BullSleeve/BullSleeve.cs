using static EventManager;
public class BullSleeve : Bullet
{
    public override void ShootSleeve()
    {
        IsReternBull(this.gameObject.GetHashCode());
    }
}
