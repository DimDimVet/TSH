using static EventBus;

public class AudioControllerEnemyGunShoot : AudioControllerShoot
{
    public override void SetEventOnEneble()
    {
        OnIsActivGunEnemyShoot += AudioShoot;
    }
    public override void SetEventOnDisable()
    {
        OnIsActivGunEnemyShoot -= AudioShoot;
    }
}
