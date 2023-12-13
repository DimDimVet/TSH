using UnityEngine;
using static EventManager;
public class ShootGunPlayer : Shoot
{
    public GameObject _BullBB; public Transform ContainerBullBB;
    public GameObject _BullSleeve; public Transform ContainerBullSleeve;
    private Pool bullBB;
    private Pool bullSleeve;
    
    private Mode mode = Mode.Turn;
    public override void Set()
    {
        bullBB = new Pool(_BullBB, ContainerBullBB);
        bullSleeve = new Pool(_BullSleeve, ContainerBullSleeve);
        OnIsReternBull += ReternBullet;
    }
    private void ReternBullet(int hash)
    {
        bullBB.ReternObject(hash);
        bullSleeve.ReternObject(hash);
    }
    public override void ShootBullet()
    {
        if (InputData.ModeAction == mode)
        {
            bullBB.GetObject();
            IsActivGunPlayerShoot(ThisHash, true);
        }
    }
    public override void ShootBulletSleeve()
    {
        if (InputData.ModeAction == mode)
        {
            bullSleeve.GetObject();
        }
    }
}
