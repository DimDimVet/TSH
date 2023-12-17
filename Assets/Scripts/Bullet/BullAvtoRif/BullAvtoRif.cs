using UnityEngine;
using static EventManager;

public class BullAvtoRif : Bullet
{
    private float percent, currentDamag;
    public override void ReternBullet()
    {
        IsReternBull(this.gameObject.GetHashCode(), Hit);
    }
    public override void SetDamage(int hash)
    {
        int _damage = DamagRandom();
        GetDamage(hash, _damage);
        print($"Передаем в {hash} дамаг {_damage}");
    }
    private int DamagRandom()
    {
        percent = Random.Range(1, PercentDamage);
        currentDamag = Random.value * Damage * percent;
        return (int)currentDamag;
    }
}
