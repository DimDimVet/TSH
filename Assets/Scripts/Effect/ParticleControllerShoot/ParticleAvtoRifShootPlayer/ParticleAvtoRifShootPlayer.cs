using static EventManager;

public class ParticleAvtoRifShootPlayer : ParticleControllerShoot
{
    public override void SetEventOnEneble()
    {
        OnIsActivAvtoRifPlayerShoot += PartShoot;
        PartSht.Stop();
    }
    public override void SetEventOnDisable()
    {
        OnIsActivAvtoRifPlayerShoot -= PartShoot;
    }
}
