using static EventManager;
public class BullBB : Bullet
{
    public override void ReternBullet()
    {
        IsReternBull(this.gameObject.GetHashCode());
    }
}
