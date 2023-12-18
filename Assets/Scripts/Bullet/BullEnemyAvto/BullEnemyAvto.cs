using UnityEngine;
using static EventManager;
public class BullEnemyAvto : Bullet
{
    private float percent, currentDamag;
    private int _damage, hashObjectDamagAcceptance;
    private bool isKillObjectAcceptance;
    public override void ReternBullet()
    {
        IsReternBull(this.gameObject.GetHashCode(),hashObjectDamagAcceptance, isKillObjectAcceptance, _damage, Hit);
    }
    public override void SetDamage(int hash)
    {
        _damage = DamagRandom();
        hashObjectDamagAcceptance=hash;
        isKillObjectAcceptance=GetDamage(hashObjectDamagAcceptance, _damage);
        //print($"Передаем в {hash} дамаг {_damage}");
    }
    private int DamagRandom()
    {
        percent = Random.Range(1, PercentDamage);
        currentDamag = Random.value * Damage * percent;
        return (int)currentDamag;
    }
}
