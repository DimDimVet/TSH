using UnityEngine;
using static EventManager;
public class ShootGunPlayer : Shoot
{
    public GameObject _BullBB; public Transform ContainerBullBB;
    public GameObject _BullSleeve; public Transform ContainerBullSleeve;
    public GameObject _BullDecal; public Transform ContainerBullDecal;
    private Pool bullBB;
    private Pool bullSleeve;
    private Pool bullDecal;

    private Mode mode = Mode.Turn;
    public override void Set()
    {
        bullBB = new Pool(_BullBB,ContainerBullBB);
        bullSleeve = new Pool(_BullSleeve, ContainerBullSleeve);
        bullDecal = new Pool(_BullDecal, ContainerBullDecal);
        OnIsReternBull += ReternBullet;
    }
    private void ReternBullet(int hash, int hashObjectDamagAcceptance, bool isKillObjectAcceptance, int setDamage, RaycastHit hit)
    {
        if (hashObjectDamagAcceptance != 0) { print($"������� ���� {hash} c ������� {setDamage} � ������ {hashObjectDamagAcceptance}/ ������ ���������{isKillObjectAcceptance}"); }
        bullDecal.ReternObject(hash);
        if (hit.collider != null)
        {
            if (bullBB.ReternObject(hash)) { bullDecal.GetObjectHit(hit); }
            bullSleeve.ReternObject(hash);
        }
        else
        {
            bullBB.ReternObject(hash);
            bullSleeve.ReternObject(hash);
        }
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
