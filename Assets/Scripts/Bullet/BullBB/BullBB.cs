using UnityEngine;
using static EventManager;

public class BullBB : Bullet
{
    private float percent, currentDamag;
    int _damage, hashObjectDamagAcceptance;
    private bool isKillObjectAcceptance;
    public override void ReternBullet()
    {
        IsReternBull(this.gameObject.GetHashCode(), hashObjectDamagAcceptance, isKillObjectAcceptance, _damage, Hit);
    }
    public override void SetDamage(int hash)
    {
        _damage = DamagRandom();
        hashObjectDamagAcceptance = hash;
        isKillObjectAcceptance=GetDamage(hashObjectDamagAcceptance, _damage);
        if (isKillObjectAcceptance) { print($"Передаем в {hash} дамаг {_damage}"); }
    }
    private int DamagRandom()
    {
        percent = Random.Range(1, PercentDamage);
        currentDamag = Random.value * Damage * percent;
        return (int)currentDamag;
    }
}
