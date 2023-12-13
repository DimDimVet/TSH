using static EventManager;
public class BullAvtoRif : Bullet
{
    public override void ReternBullet()
    {
        IsReternBull(this.gameObject.GetHashCode());
    }
}
