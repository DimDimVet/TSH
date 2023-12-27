using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static EventManager;

public class AudioControllerPlayerAvtoRifShoot : AudioControllerShoot
{
    public override void SetEventOnEneble()
    {
        OnIsActivAvtoRifPlayerShoot += AudioShoot;
    }
    public override void SetEventOnDisable()
    {
        OnIsActivAvtoRifPlayerShoot -= AudioShoot;
    }
}
