using UnityEngine;
using static EventBus;

public class BullAvtoRif : Bullet
{
    private float percent, currentDamag;
    private int _damage, hashObjectDamagAcceptance, costTargetObject;
    private bool isKillObjectAcceptance;
    private int hashTarget;
    private int tempHash;
    private bool isDeadTarget;
    
    public override void ReternBullet()
    {
        IsReternBull(this.gameObject.GetHashCode(), hashObjectDamagAcceptance, costTargetObject, isKillObjectAcceptance, _damage, Hit);
    }
    public override void SetDamage(int hash)
    {
        _damage = DamagRandom();
        GetDamage(hash, _damage,TypeBullet);
        tempHash = ControlHash;

        if (tempHash != 0) { hashObjectDamagAcceptance = tempHash; }
        else { hashObjectDamagAcceptance = hash; }
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
