using static EventManager;

public class ParticleGunShootPlayer : ParticleControllerShoot
{
    public override void SetEventOnEneble()
    {
        OnIsActivGunPlayerShoot += PartShoot;
        PartSht.Stop();
    }
    public override void SetEventOnDisable()
    {
        OnIsActivGunPlayerShoot -= PartShoot;
    }
}
