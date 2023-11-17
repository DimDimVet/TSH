using static EventManager;

public class ParticleGunShootPlayer : ParticleControllerShootPlayer 
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
