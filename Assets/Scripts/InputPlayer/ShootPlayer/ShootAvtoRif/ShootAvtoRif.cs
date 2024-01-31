using UnityEngine;
using static EventBus;
public class ShootAvtoRif : Shoot
{
    public GameObject _BullRif; public Transform ContainerBullRif;
    public GameObject _BullRifSleeve; public Transform ContainerBullRifSleeve;
    public GameObject _BullDecal; public Transform ContainerBullDecal;
    private Pool bullRif;
    private Pool bullRifSleeve;
    private Pool bullDecal;

    private Mode mode = Mode.AvtoRif;

    public override void Set()
    {
        bullRif = new Pool(_BullRif, ContainerBullRif);
        bullRifSleeve = new Pool(_BullRifSleeve, ContainerBullRifSleeve);
        bullDecal = new Pool(_BullDecal, ContainerBullDecal);
        OnIsReternBull += ReternBullet;
    }
    private void ReternBullet(int hash, int hashObjectDamagAcceptance, int costTargetObject, bool isKillObjectAcceptance, int setDamage, RaycastHit hit)
    {
        if (hashObjectDamagAcceptance != 0 & isKillObjectAcceptance) { ShootStaisticPlayer(hashObjectDamagAcceptance, costTargetObject, isKillObjectAcceptance); }
        bullDecal.ReternObject(hash);
        if (hit.collider != null)
        {
            if (bullRif.ReternObject(hash)) { bullDecal.GetObjectHit(hit); }
            bullRifSleeve.ReternObject(hash);
        }
        else
        {
            bullRif.ReternObject(hash);
            bullRifSleeve.ReternObject(hash);
        }
    }
    public override void ShootBullet()
    {
        if (InputData.ModeAction == mode)
        {
            CurrentCountClip--;
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
    private void Update()
    {
        ChargingParametr(mode, IsClipReLoad, CurrentCountClip);
    }
}
