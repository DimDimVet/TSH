using static EventManager;
public class BullSleeve : Bullet
{
    private int _damage = 0, hashObjectDamagAcceptance = 0;
    private bool isKillObjectAcceptance=false;
    public override void ShootSleeve()
    {
        IsReternBull(this.gameObject.GetHashCode(),hashObjectDamagAcceptance, isKillObjectAcceptance, _damage, Hit);
    }
}
