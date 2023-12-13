using UnityEngine;
using static EventManager;

public class ShootEnemyAvto : Shoot
{
    public GameObject _BullEnemyAvto; public Transform ContainerBullEnemyAvto;
    public GameObject _BullEnemyAvtoSleeve; public Transform ContainerBullEnemyAvtoSleeve;
    private Pool bullEnemyAvto;
    private Pool bullEnemyAvtoSleeve;
    public override void Set()
    {
        bullEnemyAvto = new Pool(_BullEnemyAvto, ContainerBullEnemyAvto);
        bullEnemyAvtoSleeve = new Pool(_BullEnemyAvtoSleeve, ContainerBullEnemyAvtoSleeve);
        OnIsReternBull += ReternBullet;
    }
    private void ReternBullet(int hash)
    {
        bullEnemyAvto.ReternObject(hash);
        bullEnemyAvtoSleeve.ReternObject(hash);
    }
    private void OnEnable()
    {
        OnIsReadinessShoot += ReadinessShoot;
    }
    private void OnDisable()
    {
        OnIsReadinessShoot -= ReadinessShoot;
    }
    private void ReadinessShoot(int thisHash, bool isReadinessShoot)
    {
        if (ThisHash == thisHash) { IsScriptAction = isReadinessShoot; }
    }
    public override void ShootBullet()
    {
        bullEnemyAvto.GetObject();
        IsActivGunEnemyShoot(ThisHash, true);
    }
    public override void ShootBulletSleeve()
    {
        bullEnemyAvtoSleeve.GetObject();
    }
}
