using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static EventManager;
public class HealtEnemy : Healt
{
    //private int healtCount = 100;
    //public override bool ControlDamage(int getHash, int damage)
    //{
    //    if (getHash == ThisHash)
    //    {
    //        if (IsDead) { return IsDead; }
    //        if (ThisObjects == null) { SetChildrensObject(); return false; }

    //        for (int i = 0; i < ThisObjects.Length; i++)
    //        {
    //            if (ThisObjects[i].Hash == getHash || ThisObjects[i].ParentHashObject == getHash)
    //            {
    //                if (healtCount <= 0) { IsDead = true; IsDead(ThisHash, IsDead); return IsDead; }
    //                else { healtCount -= damage; }
    //                GetUIDamage(ThisHash, healtCount);
    //            }
    //        }
    //    }
    //    return IsDead;
    //}
}
