using UnityEngine;
using static EventBus;
public class BullEnemyAvto : Bullet
{
    private float percent, currentDamag;
    private int _damage, hashObjectDamagAcceptance, costTargetObject;
    private bool isKillObjectAcceptance;
    private int hashTarget;
    private bool isDeadTarget;
    public override void ReternBullet()
    {
        IsReternBull(this.gameObject.GetHashCode(),hashObjectDamagAcceptance, costTargetObject, isKillObjectAcceptance, _damage, Hit);
    }
    public override void SetDamage(int hash)
    {
        _damage = DamagRandom();
        hashObjectDamagAcceptance = hash;
        GetDamage(hashObjectDamagAcceptance, _damage,TypeBullet);
        isKillObjectAcceptance = KillObjectAcceptance(hashObjectDamagAcceptance);
    }
    private bool KillObjectAcceptance(int hashObjectDamagAcceptance)
    {
        if (hashObjectDamagAcceptance == hashTarget) { return isDeadTarget; }
        else { return false; }
    }
    public override void IsDeadTargetObject(int thisHash, bool isDead, int costObject)
    {
        hashTarget = thisHash;
        isDeadTarget = isDead;
        costTargetObject = costObject;
    }
    private int DamagRandom()
    {
        percent = Random.Range(1, PercentDamage);
        currentDamag = Random.value * Damage * percent;
        return (int)currentDamag;
    }
}
