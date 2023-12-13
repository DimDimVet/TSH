using UnityEngine;
using static EventManager;
public class ShootAvtoRif : Shoot
{
    public GameObject _BullRif; public Transform ContainerBullRif;
    public GameObject _BullRifSleeve; public Transform ContainerBullRifSleeve;
    private Pool bullRif;
    private Pool bullRifSleeve;

    private Mode mode = Mode.AvtoRif;

    public override void Set()
    {
        bullRif = new Pool(_BullRif, ContainerBullRif);
        bullRifSleeve = new Pool(_BullRifSleeve, ContainerBullRifSleeve);
        OnIsReternBull += ReternBullet;
    }
    private void ReternBullet(int hash)
    {
        bullRif.ReternObject(hash);
        bullRifSleeve.ReternObject(hash);
    }
    public override void ShootBullet()
    {
        if (InputData.ModeAction == mode)
        {
            bullRif.GetObject();
            IsActivAvtoRifPlayerShoot(ThisHash, true);
        }
    }
    public override void ShootBulletSleeve()
    {
        if (InputData.ModeAction == mode)
        {
            bullRifSleeve.GetObject();
        }
    }
}
