using UnityEngine;
using static EventManager;
public class BullEnemyAvto : Bullet
{
    private float percent, currentDamag;
    private int _damage, hashObjectDamagAcceptance;
    private bool isKillObjectAcceptance;
    private int hashTarget;
    private bool isDeadTarget;
    public override void ReternBullet()
    {
        IsReternBull(this.gameObject.GetHashCode(),hashObjectDamagAcceptance, isKillObjectAcceptance, _damage, Hit);
    }
    public override void SetDamage(int hash)
    {
        _damage = DamagRandom();
        hashObjectDamagAcceptance = hash;
        GetDamage(hashObjectDamagAcceptance, _damage);
        isKillObjectAcceptance = KillObjectAcceptance(hashObjectDamagAcceptance);
    }
    private bool KillObjectAcceptance(int hashObjectDamagAcceptance)
    {
        if (hashObjectDamagAcceptance == hashTarget) { return isDeadTarget; }
        else { return false; }
    }
    public override void IsDeadTargetObject(int thisHash, bool isDead)
    {
        hashTarget = thisHash;
        isDeadTarget = isDead;
    }
    private int DamagRandom()
    {
        percent = Random.Range(1, PercentDamage);
        currentDamag = Random.value * Damage * percent;
        return (int)currentDamag;
    }
}
