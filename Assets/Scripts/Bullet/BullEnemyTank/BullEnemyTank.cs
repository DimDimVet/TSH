using static EventManager;
public class BullEnemyTank : Bullet
{
    public override void ReternBullet()
    {
        IsReternBull(this.gameObject.GetHashCode());
    }
}
