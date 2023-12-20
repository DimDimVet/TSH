using static EventManager;
public class BullSleeveAvtoRif : Bullet
{
    private int _damage = 0, hashObjectDamagAcceptance = 0, costTargetObject = 0;
    private bool isKillObjectAcceptance = false;
    public override void ShootSleeve()
    {
        IsReternBull(this.gameObject.GetHashCode(), hashObjectDamagAcceptance, costTargetObject, isKillObjectAcceptance, _damage, Hit);
    }
}
