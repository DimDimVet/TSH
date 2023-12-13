using static EventManager;
public class BullEnemyAvto : Bullet
{
    public override void ReternBullet()
    {
        IsReternBull(this.gameObject.GetHashCode());
    }
}
