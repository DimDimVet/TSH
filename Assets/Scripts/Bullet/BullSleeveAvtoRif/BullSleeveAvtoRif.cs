using static EventManager;
public class BullSleeveAvtoRif : Bullet
{
    public override void ShootSleeve()
    {
        IsReternBull(this.gameObject.GetHashCode());
    }
}
