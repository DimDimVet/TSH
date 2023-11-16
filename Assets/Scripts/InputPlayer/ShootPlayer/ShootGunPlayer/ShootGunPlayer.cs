using static EventManager;
public class ShootGunPlayer : Shoot
{
    private Mode mode = Mode.Turn;
    public override void ShootBullet()
    {
        if (InputData.ModeAction == mode)
        {
            Pools.BullBB.GetObject();
            IsActivGunPlayerShoot(true);
        }
    }
    public override void ShootBulletSleeve()
    {
        if (InputData.ModeAction == mode)
        {
            Pools.BullSleeve.GetObject();
        }
    }
}
