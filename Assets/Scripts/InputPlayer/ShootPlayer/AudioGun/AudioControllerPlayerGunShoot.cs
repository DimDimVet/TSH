using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static EventManager;

public class AudioControllerPlayerGunShoot : AudioControllerShoot
{
    public override void SetEventOnEneble()
    {
        OnIsActivGunPlayerShoot += AudioShoot;
    }
    public override void SetEventOnDisable()
    {
        OnIsActivGunPlayerShoot -= AudioShoot;
    }
}
