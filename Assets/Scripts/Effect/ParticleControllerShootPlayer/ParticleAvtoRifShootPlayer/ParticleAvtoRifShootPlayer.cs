using static EventManager;

public class ParticleAvtoRifShootPlayer : ParticleControllerShootPlayer 
{
public override void SetEventOnEneble()
    {
        OnIsActivAvtoRifPlayerShoot += PartShoot;
        PartSht.Stop();
    }
    public override void SetEventOnDisable()
    {
        OnIsActivAvtoRifPlayerShoot-= PartShoot;
    }
}
