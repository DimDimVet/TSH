using System;
using UnityEngine;
using static EventBus;

public class TargetsMoveEnemy : MonoBehaviour
{
    [SerializeField] private Transform[] defaultPositions;
    private Vector3[] defaultPositionsVector;
    public Vector3[] DefaultPositionsVector { get { return defaultPositionsVector; } }
    private Vector3[] targets;
    public Vector3[] Targets { get { return targets; } }
    private int thisHash;
    private Construction thisObject;
    public Construction ThisObject { get { return thisObject; } }
    public bool IsDead { get { return isDead; } }
    private bool isDead = false;

    private void OnEnable()
    {
        OnGetTargetPlayer += GetTarget;
        isDead = false;
        OnIsDead += StopRun;
    }
    private void OnDisable()
    {
        OnGetTargetPlayer -= GetTarget;
        OnIsDead -= StopRun;
    }
    private void StopRun(int _thisHash, bool _isDead, int costObject)
    {
        if (thisHash == _thisHash) { isDead = _isDead; }
    }
    public void SetTargetDefault()
    {
        thisHash = this.gameObject.GetHashCode();
        thisObject = GetObjectHash(thisHash);
        if (thisObject.Hash == 0) { return; }

        if (defaultPositions.Length != 0)
        {
            defaultPositionsVector = new Vector3[defaultPositions.Length];
            for (int i = 0; i < defaultPositions.Length; i++) { defaultPositionsVector[i] = defaultPositions[i].position; }
        }
        else
        {
            defaultPositions = new Transform[] { gameObject.transform };
            defaultPositionsVector = new Vector3[] { defaultPositions[0].position };
        }
    }
    private void GetTarget(Construction[] players, Construction[] grupEnemys)
    {
        for (int i = 0; i < grupEnemys.Length; i++)
        {
            if (grupEnemys[i].Hash == thisHash)
            {
                for (int y = 0; y < players.Length; y++)
                {
                    if (players[y].Hash != 0 & players[y].HealtPlayer != null)
                    {
                        CreatTarget(players[y]);
                    }
                    else
                    {
                        ClearTarget();
                    }
                }
            }
        }
    }
    private void CreatTarget(Construction objectTarget)
    {
        if (targets != null)
        {
            for (int i = 0; i < targets.Length; i++)
            {
                if (targets[i] == objectTarget.Transform.position)
                {
                    return;
                }
                if (targets[i].magnitude == 0)
                {
                    targets[i] = objectTarget.Transform.position;
                    return;
                }
            }
            int newLength = targets.Length + 1;
            Array.Resize(ref targets, newLength);
            targets[newLength - 1] = objectTarget.Transform.position;
        }
        else
        {
            targets = new Vector3[] { objectTarget.Transform.position };
        }
    }
    private void ClearTarget()
    {
        if(targets!=null)
        {
            Array.Clear(targets, 0, targets.Length);
            if (targets.Length > 200) { Array.Resize(ref targets, 1); }
        }
    }
}
