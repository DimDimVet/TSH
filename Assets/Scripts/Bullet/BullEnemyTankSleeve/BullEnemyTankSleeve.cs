using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BullEnemyTankSleeve : Bullet
{
    public override void ShootSleeve()
    {
        Pools.BullEnemyTankSleeve.ReternObject(gameObject);
    }
}
