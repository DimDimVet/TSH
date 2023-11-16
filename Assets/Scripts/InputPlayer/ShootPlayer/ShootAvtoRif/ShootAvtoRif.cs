using static EventManager;
public class ShootAvtoRif : Shoot
{
    private Mode mode = Mode.AvtoRif;
    public override void ShootBullet()
    {
        if (InputData.ModeAction == mode)
        {
            Pools.BullRif.GetObject();
        }
    }
    public override void ShootBulletSleeve()
    {
        if (InputData.ModeAction == mode)
        {
            Pools.BullRifSleeve.GetObject();
        }
    }
}
