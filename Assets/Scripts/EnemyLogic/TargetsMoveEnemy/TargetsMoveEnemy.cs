using System;
using UnityEngine;
using static EventManager;

public class TargetsMoveEnemy : MonoBehaviour
{
    //êýø
    private int thisHash;
    public int ThisHash { get { return thisHash; } }
    private Transform[] targets;
    public Transform[] Targets { get { return targets; }set { targets = value; } }

    private void OnEnable()
    {
        thisHash=this.gameObject.GetHashCode();
        OnGetTargetPlayer += GetTarget;
    }
    private void OnDisable()
    {
        OnGetTargetPlayer -= GetTarget;
    }
    private void GetTarget(Construction[] players, Construction[] grupEnemys)
    {
        for (int i = 0; i < grupEnemys.Length; i++)
        {
           
            if (grupEnemys[i].Hash == thisHash)
            {
                for (int y = 0; y < players.Length; y++)
                {
                    if (players[y].Hash != 0)
                    {
                        CreatTarget(players[y]);
                        print(players[y].Hash);
                    }
                    else
                    {
                        ClearTarget();
                        DefaultTarget();
                        print(players[y].Hash);
                    }
                }
                //break;
            }
            //else
            //{
            //    ClearTarget();
            //    DefaultTarget();
            //}
        }
    }
    private void CreatTarget(Construction objectTarget)
    {
        if (targets != null)
        {
            int newLength = targets.Length + 1;
            Array.Resize(ref targets, newLength);
            targets[newLength - 1] = objectTarget.Transform;
        }
        else
        {
            targets = new Transform[] { objectTarget.Transform };
        }
    }
    private void ClearTarget()
    {
        Array.Clear(targets, 0, targets.Length);
    }
    public virtual void DefaultTarget()
    {
        //targets = new Transform[] { defaultPosition };
    }
}
