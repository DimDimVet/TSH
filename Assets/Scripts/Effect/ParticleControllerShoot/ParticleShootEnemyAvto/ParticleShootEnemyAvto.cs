using static EventManager;

public class ParticleShootEnemyAvto : ParticleControllerShoot
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
