using static EventManager;

public class ParticleGunShootEnemy : ParticleControllerShoot
{
    public override void SetEventOnEneble()
    {
        OnIsActivGunEnemyShoot += PartShoot;
        PartSht.Stop();
    }
    public override void SetEventOnDisable()
    {
        OnIsActivGunEnemyShoot -= PartShoot;
    }
}
